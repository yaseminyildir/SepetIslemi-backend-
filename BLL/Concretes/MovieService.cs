using BLL.Abstracts;
using BLL.DTO;
using DAL.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Concretes
{
    public class MovieService : IMovieService
    {
        private readonly ImdbdataContext _context;

        public MovieService(ImdbdataContext context)
        {
            _context = context;
        }

        public List<MovieDTO> GetMovies()
        {
            return _context.Movies.Select(x => new MovieDTO
            {
                ID = x.Id,
                MovieName = x.Title,
                Description = x.Description,
                StatusCode = 200,
                Status = true,
                Message = "Listeleme başarılı"

            }).ToList();
        }

        
        public List<MovieDTO> GetMovieByName(string name)
        {
         
              var m=  _context.Movies.Where(x => x.Title.Contains(name)).Select(x => new MovieDTO
                {
                    ID = x.Id,
                    MovieName = x.Title,
                    Description = x.Description,
                    StatusCode = 200,
                    Status = true,
                    Message="başarılı"
                }).ToList();
                return m;
          
        }

        public async Task<ResultDTO> CreateMovie(MovieDTO movie)
        {
            try
            {
                Movie m = new Movie
                {
                    Id = movie.ID,
                    Title = movie.MovieName,
                    Description = movie.Description,
                    DirectorId= movie.DirectorId,
                };
                await _context.Movies.AddAsync(m);
                await _context.SaveChangesAsync();
                return new ResultDTO
                {
                    Status = true,
                    StatusCode = 200,
                    Message = "Film oluşturuldu!"
                };
            }
            catch (Exception ex)
            {
                return new ResultDTO
                {
                    Status = false,
                    StatusCode = 400,
                    Message = ex.Message
                };
            }
           
        }

        public async Task<ResultDTO> UpdateMovie(MovieDTO movie)
        {
            try
            {
                var updated = _context.Movies.FirstOrDefault(x => x.Id == movie.ID);


                updated.Title = movie.MovieName;
                updated.Description = movie.Description;


                _context.Movies.Update(updated);
                await _context.SaveChangesAsync();
                return new ResultDTO
                {
                    Status = true,
                    StatusCode = 200,
                    Message = "Film güncellendi"
                };
            }
            catch (Exception ex)
            {

                return new ResultDTO
                {
                    Status = false,
                    StatusCode = 400,
                    Message = ex.Message
                };
            }

        }

        public async Task<ResultDTO> DeleteMovie(int id)
        {
            try
            {
                var deleted = _context.Movies.FirstOrDefault(x => x.Id == id);
                _context.Movies.Remove(deleted);

                await _context.SaveChangesAsync();
                return new ResultDTO
                {
                    Status = true,
                    StatusCode = 200,
                    Message = "Film Silindi!"
                };
            }
            catch (Exception ex)
            {

                return new ResultDTO
                {
                    Status = false,
                    StatusCode = 400,
                    Message = ex.Message
                };
            }
        

        }

        
    }
}
