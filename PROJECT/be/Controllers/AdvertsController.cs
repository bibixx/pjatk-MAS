using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using mas_project.Models;
using mas_project.Models.DTOs;
using mas_project.Models.DTOs.Responses;
using mas_project.Models.DTOs.Requests;
using System.Collections.Generic;
using System;

namespace mas_project.Controllers
{
    [Route("api/adverts")]
    [ApiController]
    public class AdvertsController : ControllerBase
    {
        private MainDbContext _context;

        public AdvertsController(MainDbContext context)
        {
            this._context = context;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAdverts()
        {
            ICollection<Advert> adverts = await this._context.Adverts
                .Where(ad => ad.IsActive)
                .Include(ad => ad.Seller)
                .Include(ad => ad.AdvertGameSubjects)
                .ThenInclude(ags => ags.Game)
                .ToListAsync();

            var dtoAdverts = new List<GetAdvertsDTOAdvert>();

            foreach (var advert in adverts)
            {
                var dtoGames = new List<GameDTO>();

                foreach (var game in advert.AdvertGameSubjects)
                {
                    var dtoGame = new GameDTO {
                        IdGame = game.Game.IdGame,
                        Title = game.Game.Title,
                        Description = game.Game.Description,
                        CoverPhoto = game.Game.CoverPhoto,
                    };

                    dtoGames.Add(dtoGame);
                }

                GetAdvertsDTOAdvert dtoAdvert = new GetAdvertsDTOAdvert {
                    IdAdvert = advert.IdAdvert,
                    GameCondition = advert.GameCondition,
                    Category = advert.Category,
                    Games = dtoGames,
                };

                dtoAdverts.Add(dtoAdvert);
            }

            return Ok(dtoAdverts);
        }

        [HttpGet("{idAdvert}")]
        public async Task<IActionResult> GetAdvert(int idAdvert)
        {
            Advert advert = await this._context.Adverts
                .Where(ad => ad.IdAdvert == idAdvert)
                .Include(ad => ad.Seller)
                .Include(ad => ad.AdvertGameSubjects)
                    .ThenInclude(ags => ags.Game)
                .Include(ad => ad.AdvertGamesCanBeTradedFor)
                    .ThenInclude(ags => ags.Game)
                .FirstOrDefaultAsync();

            if (advert == null) {
                return NotFound();
            }

            var dtoGames = new List<GameDTO>();

            foreach (var game in advert.AdvertGameSubjects)
            {
                var dtoGame = new GameDTO {
                    IdGame = game.Game.IdGame,
                    Title = game.Game.Title,
                    Description = game.Game.Description,
                    CoverPhoto = game.Game.CoverPhoto,
                };

                dtoGames.Add(dtoGame);
            }

            var dtoGamesThatCanBeTraded = new List<GameDTO>();

            foreach (var game in advert.AdvertGamesCanBeTradedFor)
            {
                var dtoGame = new GameDTO {
                    IdGame = game.Game.IdGame,
                    Title = game.Game.Title,
                    Description = game.Game.Description,
                    CoverPhoto = game.Game.CoverPhoto,
                };

                dtoGamesThatCanBeTraded.Add(dtoGame);
            }

            var dtoSeller = new GetAdvertDTOSeller {
                IdUser = advert.Seller.IdUser,
                FirstName = advert.Seller.FirstName,
                LastName = advert.Seller.LastName,
                UserName = advert.Seller.UserName,
                Email = advert.Seller.Email,
                SelfPickupAddress = advert.Seller.SelfPickupAddress,
                PhoneNumber = advert.Seller.PhoneNumber,
            };

            GetAdvertDTO dtoAdvert = new GetAdvertDTO {
                IdAdvert = advert.IdAdvert,
                GameCondition = advert.GameCondition,
                Category = advert.Category,
                Description = advert.Description,
                CreationDate = advert.CreationDate,
                IsActive = advert.IsActive,
                Games = dtoGames,
                Seller = dtoSeller,
                GamesThatCanBeTraded = dtoGamesThatCanBeTraded,
            };

            return Ok(dtoAdvert);
        }

        private async Task<IActionResult> ValidateOfferAdvert(int IdAdvert) {
            Advert advert = await this._context.Adverts
                .Where(ad => ad.IdAdvert == IdAdvert)
                .FirstOrDefaultAsync();

            if (advert == null) {
                return NotFound("Advert doesn't exist");
            }

            if (!advert.IsActive) {
                return UnprocessableEntity("Advert is no longer active");
            }

            return null;
        }

        private async Task<IActionResult> ValidateOfferBuyer(int IdBuyer) {
            User buyer = await this._context.Users
                .Where(user => user.IdUser == IdBuyer)
                .FirstOrDefaultAsync();

            if (buyer == null) {
                return NotFound("Buyer doesn't exist");
            }

            if (!buyer.IsBuyer) {
                return UnprocessableEntity("Provider user is not a buyer");
            }

            return null;
        }

        private async Task<IActionResult> ValidateOfferGames(List<int> gameIds) {
            var games = await this._context.Games
                .Where(game => gameIds.Contains(game.IdGame))
                .Select(game => game.IdGame)
                .ToListAsync();

            foreach (var gameId in gameIds)
            {
                if (!games.Contains(gameId)) {
                    return UnprocessableEntity("Game with id " + gameId.ToString() + " doesn't exist.");
                }
            }

            return null;
        }

        [HttpPost("{idAdvert}/offers/trade")]
        public async Task<IActionResult> CreateTradeOffer(int idAdvert, CreateTradeOfferDTO body) {
            var advertValidationResult = await this.ValidateOfferAdvert(idAdvert);
            if (advertValidationResult != null) {
                return advertValidationResult;
            }

            var buyerValidationResult = await this.ValidateOfferBuyer(body.IdBuyer);
            if (buyerValidationResult != null) {
                return buyerValidationResult;
            }

            var gamesValidationResult = await this.ValidateOfferGames(body.GameIds);
            if (gamesValidationResult != null) {
                return gamesValidationResult;
            }

            var newTradeOffer = new TradeOffer {
                IdBuyer = body.IdBuyer,
                CreationDate = DateTime.Now,
                Status = OfferStatus.Open,
                IdAdvert = idAdvert,
            };

            this._context.TradeOffers.Add(newTradeOffer);

            await this._context.SaveChangesAsync();

            foreach (var gameId in body.GameIds)
            {
                this._context.TradeOfferGames.Add(new TradeOfferGame {
                    IdGame = gameId,
                    IdOffer = newTradeOffer.IdOffer
                });
            }

            await this._context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("{idAdvert}/offers/buyout")]
        public async Task<IActionResult> CreateBuyoutOffer(int idAdvert, CreateBuyoutOfferDTO body) {
            var advertValidationResult = await this.ValidateOfferAdvert(idAdvert);
            if (advertValidationResult != null) {
                return advertValidationResult;
            }

            var buyerValidationResult = await this.ValidateOfferBuyer(body.IdBuyer);
            if (buyerValidationResult != null) {
                return buyerValidationResult;
            }

            var newBuyoutOffer = new BuyoutOffer {
                IdBuyer = body.IdBuyer,
                CreationDate = DateTime.Now,
                Status = OfferStatus.Open,
                IdAdvert = idAdvert,
                Price = body.Price
            };

            this._context.BuyoutOffers.Add(newBuyoutOffer);

            await this._context.SaveChangesAsync();

            return Ok();
        }
    }
}
