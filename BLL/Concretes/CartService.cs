using BLL.Abstracts;
using BLL.DTO;
using DAL.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concretes
{
    public class CartService : ICartService
    {
        private readonly ImdbdataContext _context;

        public CartService(ImdbdataContext context)
        {
            _context = context;
        }
        public  async Task<ResultDTO> AddToCart(int movieId)
        {
            try
            {
                var movie =await _context.Movies.FirstOrDefaultAsync(x=>x.Id==movieId); 
                if (movie == null)
                {
                    return new ResultDTO
                    {
                        Status = false,
                        StatusCode = 404,
                        Message = "Film bulunamadı."
                    };
                }
                return new ResultDTO
                {
                    Status = true,
                    StatusCode = 200,
                    Message = $"{movie.Title} sepete eklendi."
                };
            }
            catch (Exception ex)
            {

                return new ResultDTO
                {
                    Status = false,
                    StatusCode = 500,
                    Message = ex.Message
                };
            }
        }

        public async Task<List<MovieDTO>> GetCartItems()
        {
            var cartItems = await _context.Movies.Select(x => new MovieDTO
            {
                ID = x.Id,
                MovieName = x.Title,
                Description = x.Description,
                StatusCode = 200,
                Status = true,
                Message = "Listeleme başarılı"

            }).ToListAsync();
            return cartItems;   
        }

        public async Task<ResultDTO> RemoveFromCart(int movieId)
        {
            try
            {
                var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == movieId);
                if(movie==null)
                {
                    return new ResultDTO
                    {
                        Status = false,
                        StatusCode = 404,
                        Message = "Film bulunamadı."
                    };
                }
                return new ResultDTO
                {
                    Status = true,
                    StatusCode = 200,
                    Message = $"{movie.Title} sepetten kaldırıldı."
                };
            }
            catch (Exception ex)
            {

                return new ResultDTO
                {
                    Status = false,
                    StatusCode = 500,
                    Message = ex.Message
                };
            }
        }
    }
}
