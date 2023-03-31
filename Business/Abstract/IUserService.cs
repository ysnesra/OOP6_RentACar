using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);


        IDataResult<List<OperationClaim>> GetClaims(User user);  //Kullanıcının Claimlerini (rollerini) getirir
        IDataResult<User> GetByEmail(string email);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);      //tek bir kullanıcının detayını getirir
        IDataResult<List<UserDetailDto>> GetUserDetails();    //User-Customer Join
        IDataResult<UserDetailDto> GetUserDetailsByEmail(string email);  //Maile göre kullanıcıyı şirketbilgisiyle birlikte getirir 1-1 ilişki
        
    }
}
