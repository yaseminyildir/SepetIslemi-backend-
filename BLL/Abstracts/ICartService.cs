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
        //public Task<ResultDTO> AddToCart(MovieDTO movie);
        //public Task<List<MovieDTO>> GetCartItems();
        //public Task<ResultDTO> RemoveFromCart(MovieDTO movie);








        
            Task<ResultDTO> AddToCart(MovieDTO movie);
            Task<List<MovieDTO>> GetCartItems( );
            Task<ResultDTO> RemoveFromCart(MovieDTO movie);
        
    }
}
