using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstracts
{
    public interface ICartService
    {
        public Task<ResultDTO> AddToCart(int movieId);
        public Task<List<MovieDTO>> GetCartItems();
        public Task<ResultDTO> RemoveFromCart(int movieId);

    }
}
