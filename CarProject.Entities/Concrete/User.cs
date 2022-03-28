using System;
using System.Collections.Generic;
using CarProject.Shared.Entities.Abstract;

namespace CarProject.Entities.Concrete
{
    public class User : EntityBase<int>, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte PhoneNumber { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string EmailAddress { get; set; }
        public ICollection<UserPicture> UserPictures { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}

