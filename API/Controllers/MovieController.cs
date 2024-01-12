using BLL.Abstracts;
using BLL.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok(_movieService.GetMovies());
        }

        [HttpGet("{name}")]
        public IActionResult GetMovieByName(string name)
        {
            return Ok(_movieService.GetMovieByName(name));
        }

        [HttpPost]
        public async Task<IActionResult> PostMovieCreate (MovieDTO movie)
        {
            var result = await _movieService.CreateMovie(movie);
            if (result.Status)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPut]
        public async Task<IActionResult> PutMovieUpdate(MovieDTO movie)
        {
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            return Ok();
        }
    }
}
