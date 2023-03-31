using Core.DataAccess;
using Core.Entities.Concrete;
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
        //Kullanıcının Claimlerini çekeceğim metot (OperationClaims-UserOperationClaims tablolarını Joinleyerek)
        List<OperationClaim> GetClaims(User user);

        List<UserDetailDto> GetUserDetails();
        UserDetailDto GetUserDetailsByEmail(string email);    
    }
}
