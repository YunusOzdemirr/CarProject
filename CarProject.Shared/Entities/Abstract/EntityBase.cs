using System;
namespace CarProject.Shared.Entities.Abstract
{
    public abstract class EntityBase<T> where T : struct
    {
        public virtual T Id { get; set; }
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool IsActive { get; set; } = true;
        public virtual int? CreatedByUserId { get; set; }
        public virtual int? ModifiedByUserId { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
    }
}
