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

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }

    // POST /game/create
    [HttpPost("create")]
    public async Task<ActionResult<CreateGameResponse>> CreateGame()
    {
        var response = await _gameService.CreateGame();
        return Ok(response);
    }

    // GET /game/{gameId}
    [HttpGet("{gameId}")]
    public async Task<ActionResult<Game>> CreateGame([FromRoute] string gameId)
    {
        var response = await _gameService.GetGame(gameId);
        return Ok(response);
    }
}

