using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Services;

public interface IGameService
{
    Task<CreateGameResponse> CreateGame();
    Task<Game> GetGame(string gameId);
    Task<Game> UpdateGame(Game game, PlayMoveRequest playMoveRequest);
}