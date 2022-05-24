using System.Threading.Tasks;

namespace TicTacToe.Repositories;

public interface IGameRepository
{
    Task CreateGame(GameEntity gameEntity);
    Task<GameEntity> GetGame(string gameId);
}
