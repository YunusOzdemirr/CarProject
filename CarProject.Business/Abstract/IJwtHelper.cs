using System;
using System.Collections.Generic;
using CarProject.Entities.Concrete;
using CarProject.Shared.Utilities.Security.Jwt;

namespace CarProject.Business.Abstract
{
    public interface IJwtHelper
    {
        AccessToken CreateToken(User user);
    }
}

