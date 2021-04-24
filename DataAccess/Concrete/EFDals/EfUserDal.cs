using Core.DataAccess.Repositories;
using Core.Entities.Concrete;
using DataAccess.Abstract.Dals;
using DataAccess.Concrete.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EFDals
{
    public class EfUserDal : EntityRepository<User, DBContext>, IUserDal
    {
        public void AddUserClaim(UserOperationClaim entity)
        {
            using (var context = new DBContext())
            {
                context.Entry(entity).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new DBContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.ClaimId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}