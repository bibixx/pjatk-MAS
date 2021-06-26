using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mas_project.Models;
using mas_project.Models.DTOs;
using System.Collections.Generic;

namespace mas_project.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private MainDbContext _context;

        public GamesController(MainDbContext context)
        {
            this._context = context;
        }

        [HttpGet()]
        public async Task<IActionResult> GetGames()
        {
            var games = await this._context.Games.ToListAsync();

            var dtoGamesList = new List<GameDTO>();

            foreach (var game in games)
            {
                dtoGamesList.Add(new GameDTO {
                    IdGame = game.IdGame,
                    Title = game.Title,
                    Description = game.Description,
                    CoverPhoto = game.CoverPhoto,
                });
            }

            return Ok(dtoGamesList);
        }
    }
}
