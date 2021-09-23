using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Model;
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
    public class EfMovieDal : EfEntityRepositoryBase<Movie, MovieStoreDbContext>, IMovieDal
    {

        public List<Movie> GetAll()
        {
            using (MovieStoreDbContext context = new MovieStoreDbContext())
            {
                var movies = context.Movies
                    .Include(m => m.Genre)
                    .Include(m => m.Director)
                    .Include(m => m.Performers)
                        .ThenInclude(mp => mp.Performer)
                    .OrderBy(m => m.Id)
                    .ToList();

                return movies;
            }
        }

        public Movie Get(int id)
        {
            using (MovieStoreDbContext context = new MovieStoreDbContext())
            {
                var movie = context.Movies
                    .Include(m => m.Genre)
                    .Include(m => m.Director)
                    .Include(m => m.Performers)
                        .ThenInclude(mp => mp.Performer)
                    .SingleOrDefault(m => m.Id == id);

                return movie;
            }
        }
    }
}
