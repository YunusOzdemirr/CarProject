using System;
using CarProject.Shared.Entities.Abstract;

namespace CarProject.Entities.Concrete
{
    public class UserPicture : EntityBase<int>, IEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public byte[] File { get; set; }
    }
}

