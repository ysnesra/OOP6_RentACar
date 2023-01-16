using Core.Utilities.Results;
using Entities.Concrete;
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

        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);      //tek bir kullanıcının detayını getirir
        IDataResult<List<UserDetailDto>> GetUserDetails();    //User-Customer Join
        IDataResult<UserDetailDto> GetUserDetailsByEmail(string email);  //Maile göre şirketbilgisini getirir 1-1 ilişki
    }
}
