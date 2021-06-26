using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using mas_project.Models;
using mas_project.Models.DTOs;
using mas_project.Models.DTOs.Responses;
using mas_project.Models.DTOs.Requests;
using System.Collections.Generic;

namespace mas_project.Controllers
{
    [Route("api/offers")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private MainDbContext _context;

        public OffersController(MainDbContext context)
        {
            this._context = context;
        }

        [HttpPost()]
        public async Task<IActionResult> GetOffers(GetOffersRequestDTO body) {
            List<Advert> adverts = await this._context.Adverts
                .Where(ad => ad.IdSeller == body.IdSeller)
                .Include(ad => ad.TradeOffers)
                    .ThenInclude(ags => ags.Buyer)
                .Include(ad => ad.TradeOffers)
                    .ThenInclude(ags => ags.ProposedGames)
                    .ThenInclude(pg => pg.Game)
                .Include(ad => ad.BuyoutOffers)
                    .ThenInclude(ags => ags.Buyer)
                .Include(ad => ad.AdvertGameSubjects)
                    .ThenInclude(ags => ags.Game)
                .Include(ad => ad.Seller)
                .ToListAsync();

            var dtoTradeOffers = new List<GetOffersResponseDTOTradeOffers>();
            var dtoBuyoutOffers = new List<GetOffersResponseDTOBuyoutOffers>();

            foreach (var advert in adverts)
            {
                var dtoAdvertGames = new List<GameDTO>();

                foreach (var game in advert.AdvertGameSubjects)
                {
                    dtoAdvertGames.Add(new GameDTO {
                        IdGame = game.Game.IdGame,
                        Title = game.Game.Title,
                        Description = game.Game.Description,
                        CoverPhoto = game.Game.CoverPhoto,
                    });
                }

                var dtoAdvert = new GetOffersResponseDTOAdvert {
                    IdAdvert = advert.IdAdvert,
                    GameCondition = advert.GameCondition,
                    Category = advert.Category,
                    Description = advert.Description,
                    CreationDate = advert.CreationDate,
                    IsActive = advert.IsActive,
                    Games = dtoAdvertGames,
                };

                foreach (var offer in advert.TradeOffers)
                {
                    var dtoProposedGames = new List<GameDTO>();

                    foreach (var proposedGame in offer.ProposedGames)
                    {
                        dtoProposedGames.Add(new GameDTO {
                            IdGame = proposedGame.Game.IdGame,
                            Title = proposedGame.Game.Title,
                            Description = proposedGame.Game.Description,
                            CoverPhoto = proposedGame.Game.CoverPhoto,
                        });
                    }

                    dtoTradeOffers.Add(new GetOffersResponseDTOTradeOffers {
                        IdOffer = offer.IdOffer,
                        Advert = dtoAdvert,
                        Buyer = new GetOffersResponseDTOBuyer {
                            IdUser = offer.Buyer.IdUser,
                            FirstName = offer.Buyer.FirstName,
                            UserName = offer.Buyer.UserName,
                        },
                        CreationDate = offer.CreationDate,
                        Status = offer.Status,
                        ProposedGames = dtoProposedGames
                    });
                }

                foreach (var offer in advert.BuyoutOffers)
                {
                    dtoBuyoutOffers.Add(new GetOffersResponseDTOBuyoutOffers {
                        IdOffer = offer.IdOffer,
                        Advert = dtoAdvert,
                        Buyer = new GetOffersResponseDTOBuyer {
                            IdUser = offer.Buyer.IdUser,
                            FirstName = offer.Buyer.FirstName,
                            UserName = offer.Buyer.UserName,
                        },
                        CreationDate = offer.CreationDate,
                        Status = offer.Status,
                        Price = offer.Price
                    });
                }
            }

            var dto = new GetOffersResponseDTO {
                TradeOffers = dtoTradeOffers,
                BuyoutOffers = dtoBuyoutOffers
            };

            return Ok(dto);
        }
    }
}
