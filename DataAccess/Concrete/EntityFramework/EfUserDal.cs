using Core.DataAccess.Entityframework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User,DbRentACarContext>, IUserDal
    {
        public List<UserDetailDto> GetUserDetails()
        {
            using (DbRentACarContext context = new DbRentACarContext())
            {
                var result = from u in context.Users
                             join c in context.Customers on u.UserId equals c.UserId
                             select new UserDetailDto
                             {
                                 UserFirstName = u.FirstName, UserLastName=u.LastName,
                                 Email= u.Email, CompanyName= c.CompanyName
                             };
                            
                return result.ToList();
            }
        }

        public UserDetailDto GetUserDetailsByEmail(string email)
        {
            using (DbRentACarContext context = new DbRentACarContext())
            {
                var result = (from u in context.Users
                             join c in context.Customers on u.UserId equals c.UserId
                             where u.Email == email
                             select new UserDetailDto
                             {
                                 UserFirstName = u.FirstName,
                                 UserLastName = u.LastName,
                                 Email = u.Email,
                                 CompanyName = c.CompanyName
                             }).FirstOrDefault();

                if (result != null)
                {
                    return result;
                }
                return null;

            }
        }
    }
}
