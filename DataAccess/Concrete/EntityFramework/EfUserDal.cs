using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, MovieStoreDbContext>, IUserDal
    {
        public List<User> GetAllUsersByClaim(int claimId)
        {
            using (MovieStoreDbContext context = new MovieStoreDbContext())
            {
                var users = context.Users
                    .Include(u=>u.UserOperationClaims)
                    .Where(u=>u.UserOperationClaims.Select(uoc=>uoc.OperationClaimId).Contains(claimId))
                    .ToList();

                return users;
            }
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (MovieStoreDbContext context=new MovieStoreDbContext())
            {
                var operationClaims = context.OperationClaims
                    .Include(oc => oc.UserOperationClaims.Where(uoc => uoc.User == user))
                    .OrderBy(oc => oc.Id)
                    .ToList();

                return operationClaims;                                        
            }
        }

        public User GetUserById(int id)
        {
            using (MovieStoreDbContext context = new MovieStoreDbContext())
            {
                var user = context.Users
                    .SingleOrDefault(u => u.Id == id);

                return user;
            }
        }
    }
}
