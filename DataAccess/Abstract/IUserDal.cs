using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityReporsitory<User>
    {
        List<UserDetailDto> GetUserDetails();
        UserDetailDto GetUserDetailsByEmail(string email);
    }
}
