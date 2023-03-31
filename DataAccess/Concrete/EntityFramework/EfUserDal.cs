using Core.DataAccess.Entityframework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
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
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new DbRentACarContext())
            {
                var result = (from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             }).ToList();
                return result;

            }
        }

        public List<UserDetailDto> GetUserDetails()
        {
            using (DbRentACarContext context = new DbRentACarContext())
            {
                var result = (from u in context.Users
                             join c in context.Customers on u.UserId equals c.UserId
                             select new UserDetailDto
                             {
                                 UserFirstName = u.FirstName, UserLastName=u.LastName,
                                 Email= u.Email, CompanyName= c.CompanyName
                             }).ToList();

                return result;
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
