using System;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using CarProject.Business.Abstract;
using CarProject.Business.Utilities;
using CarProject.Business.ValidationRules.FluentValidation.UserValidator;
using CarProject.Data.Concrete.EntityFramework.DatabaseContext;
using CarProject.Entities.Concrete;
using CarProject.Entities.Dtos.AuthDtos;
using CarProject.Shared.Entities.Concrete;
using CarProject.Shared.Results.ComplexTypes;
using CarProject.Shared.Results.Concrete;
using CarProject.Shared.Utilities.Exceptions;
using CarProject.Shared.Utilities.Hashing;
using CarProject.Shared.Utilities.Results.Abstract;
using CarProject.Shared.Utilities.Security.Jwt;
using CarProject.Shared.Utilities.Validation.FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CarProject.Business.Concrete
{
    public class AuthManager : ManagerBase, IAuthService
    {
        IJwtHelper _jwtHelper;
        public AuthManager(Context Context, IMapper mapper, IJwtHelper jwtHelper) : base(Context, mapper)
        {
            _jwtHelper = jwtHelper;
        }

        public async Task<IDataResult> LoginAsync(UserLoginDto userLoginDto)
        {
            //This method is validating the dto
            ValidationTool.Validate(new UserLoginDtoValidator(), userLoginDto);

            //this line is query to database
            var user = await Context.Users.AsNoTracking().SingleOrDefaultAsync(u => u.EmailAddress == userLoginDto.EmailAddress);
            if (user == null)
                throw new NotFoundArgumentException(Messages.General.ValidationError(),
                    new Error("Lütfen E-Posta adresinizi veya Şifrenizi kontrol ediniz", "EmailAddress & Password"));

            if (HashingHelper.VerifyPasswordHash(userLoginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                if (!user.IsActive)
                    throw new NotFoundArgumentException(Messages.General.ValidationError(), new Error("Giriş  yapabilmek için hesabınızın aktif olması gereklidir", "IsActive"));

                var accessToken = _jwtHelper.CreateToken(user);
                UserToken userToken = new UserToken
                {
                    UserId = user.Id,
                    Token = accessToken.Token,
                    TokenExpiration = accessToken.TokenExpiration,
                    RefreshToken = accessToken.RefreshToken,
                    RefreshTokenExpiration = accessToken.RefreshTokenExpiration,
                    CreatedByUserId = user.Id,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    ModifiedByUserId = null,
                    IpAddress = userLoginDto.IpAddress,
                    IsActive = true,
                    IsDeleted = false,
                };
                user.LastLogin = DateTime.Now;
                using (TransactionScope transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    Context.Users.Update(user);
                    await Context.SaveChangesAsync();
                    transactionScope.Complete();
                }
                return new DataResult(ResultStatus.Success, $"{user.FirstName} " + $"{user.LastName} hoş geldiniz.", new
                {
                    User = user,
                    UserToken = Mapper.Map<AccessToken>(userToken)
                });
            }
            throw new NotFoundArgumentException(Messages.General.ValidationError(),
                new Error("Lütfen e-posta adresinizi ve şifrenizi kontrol edin.", "EmailAddress & Password"));
        }
        public async Task<IDataResult> RegisterAsync(UserRegisterDto userRegisterDto)
        {
            ValidationTool.Validate(new UserRegisterDtoValidator(), userRegisterDto);

            if (await Context.Users.AnyAsync(u => u.EmailAddress == userRegisterDto.EmailAddress))
                throw new NotFoundArgumentException(Messages.General.ValidationError(), new Error("Bu e-posta adresine kayıtlı bir kullanıcı mevcut.", "EmailAddress"));

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = Mapper.Map<User>(userRegisterDto);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            var accessToken = _jwtHelper.CreateToken(user);
            UserToken userToken = new UserToken
            {
                UserId = user.Id,
                Token = accessToken.Token,
                TokenExpiration = accessToken.TokenExpiration,
                RefreshToken = accessToken.RefreshToken,
                RefreshTokenExpiration = accessToken.RefreshTokenExpiration,
                CreatedByUserId = user.Id,
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
                ModifiedByUserId = null,
                IpAddress = userRegisterDto.IpAddress,
                IsActive = true,
                IsDeleted = false
            };
            UserPicture userPicture = null;
            if (userRegisterDto.File != null)
            {
                userPicture = new UserPicture
                {
                    File = userRegisterDto.File,
                    UserId = user.Id,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByUserId = user.Id,
                    CreatedDate = DateTime.Now,
                    ModifiedByUserId = null,
                    ModifiedDate = null
                };
            }
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await Context.Users.AddAsync(user);
                if (userPicture is not null)
                    await Context.UserPictures.AddAsync(userPicture);

                await Context.SaveChangesAsync();
                transactionScope.Complete();
            };

            return new DataResult(ResultStatus.Success,
                $"{user.FirstName} {user.LastName} hoş geldiniz.", new
                {
                    User = user,
                    UserToken = Mapper.Map<AccessToken>(userToken)
                });
        }
    }
}

