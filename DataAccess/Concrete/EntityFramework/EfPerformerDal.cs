using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPerformerDal : EfEntityRepositoryBase<Performer, MovieStoreDbContext>, IPerformerDal
    {
        public List<Performer> GetAll()
        {
            using (MovieStoreDbContext context =new MovieStoreDbContext())
            {
                var performers = context.Performers
                    .Include(p=>p.StarringMovies)
                        .ThenInclude(mp=>mp.Movie)
                    .OrderBy(p => p.Id)
                    .ToList();


                return performers;
                    
            }
        }

        public Performer GetById(int id)
        {
            using (MovieStoreDbContext context = new MovieStoreDbContext())
            {
                var performer = context.Performers
                    .Include(p => p.StarringMovies)
                        .ThenInclude(mp => mp.Movie)
                    .SingleOrDefault(p => p.Id == id);


                return performer;

            }
        }
    }
}
