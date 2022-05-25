using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TicTacToe.Models;
using TicTacToe.Services;

namespace TicTacToe.Controllers;

[Produces("application/json")]
[Route("game")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;
    private readonly IGameValidator _gameValidator;

    public GameController(IGameService gameService, IGameValidator gameValidator)
    {
        _gameService = gameService;
        _gameValidator = gameValidator;
    }

    // POST /game
    [HttpPost]
    public async Task<ActionResult<CreateGameResponse>> CreateGame()
    {
        var response = await _gameService.CreateGame();
        return Ok(response);
    }

    // GET /game/{gameId}
    [HttpGet("{gameId}")]
    public async Task<ActionResult<Game>> GetGame([FromRoute] string gameId)
    {
        var game = await _gameService.GetGame(gameId);
        return game == null ? NotFound() : Ok(game);
    }

    // POST /game/{gameId}
    [HttpPost("{gameId}")]
    public async Task<ActionResult<Game>> PlayMove([FromRoute] string gameId, [FromBody] PlayMoveRequest playMoveRequest)
    {
        var game = await _gameService.GetGame(gameId);
        if (game == null)
            return NotFound();

        switch (_gameValidator.ValidateGame(game, playMoveRequest))
        {
            case ValidationStatus.GameEnded:
                return BadRequest("Game has ended");
            case ValidationStatus.InvalidPlayerTurn:
                return BadRequest("Invalid player turn");
            case ValidationStatus.InvalidPosition:
                return BadRequest("Invalid position on the board");
            case ValidationStatus.PostionNotEmpty:
                return BadRequest("Position already filled");
        }

        game = await _gameService.UpdateGame(game, playMoveRequest);

        return Ok(game);
    }
}

