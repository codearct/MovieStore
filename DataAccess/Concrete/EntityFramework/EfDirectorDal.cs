using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDirectorDal : EfEntityRepositoryBase<Director, MovieStoreDbContext>,IDirectorDal
    {
        public List<Director> GetAll() 
        {
            using (MovieStoreDbContext context =new MovieStoreDbContext())
            {
                var directors = context.Directors
                    .Include(d => d.DirectedMovies)
                    .OrderBy(d => d.Id)
                    .ToList();

                return directors;
            }
        }

        public Director Get(int id)
        {
            using (MovieStoreDbContext context = new MovieStoreDbContext())
            {
                var director = context.Directors
                    .Include(d => d.DirectedMovies)
                    .SingleOrDefault(d => d.Id == id);

                return director;
            }
        }

    }
}
