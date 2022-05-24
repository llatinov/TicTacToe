using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TicTacToe.Models;
using TicTacToe.Repositories;

namespace TicTacToe.Controllers;

[Produces("application/json")]
[Route("game")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly IGameRepository _gameRepository;

    public GameController(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    // POST /game/create
    [HttpPost("create")]
    public async Task<ActionResult<Guid>> CreateGame()
    {
        var gameId = await _gameRepository.CreateGame();
        var response = new CreateGameResponse
        {
            GameId = gameId
        };
        return Ok(response);
    }
}

