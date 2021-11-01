using Core.Entities;
using Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class AddMovieModel:IModel
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public string ReleaseDate { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }      
    }
}
