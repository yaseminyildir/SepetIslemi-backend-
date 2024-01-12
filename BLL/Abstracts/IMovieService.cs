using BLL.DTO;
using DAL.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstracts
{
    public interface IMovieService
    {
        List<MovieDTO> GetMovies();
        List<MovieDTO> GetMovieByName(string name);

        Task<ResultDTO> CreateMovie(MovieDTO movie);

        Task<ResultDTO> UpdateMovie(MovieDTO movie);

        Task<ResultDTO> DeleteMovie(int id);


      
    }
}
