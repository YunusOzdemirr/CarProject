using System;
using AutoMapper;
using CarProject.Data.Concrete.EntityFramework.DatabaseContext;

namespace CarProject.Business.Concrete
{
    public class ManagerBase
    {
        public Context Context { get; }
        protected IMapper Mapper { get; }
        public ManagerBase(Context dbContext, IMapper mapper)
        {
            Context = dbContext;
            Mapper = mapper;
        }
    }
}

