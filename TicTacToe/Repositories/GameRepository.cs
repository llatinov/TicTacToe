using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace TicTacToe.Repositories;

public class GameRepository : IGameRepository
{
    private static readonly ConcurrentDictionary<string, GameEntity> GameTable = new();

    public Task CreateGame(GameEntity gameEntity)
    {
        GameTable.TryAdd(gameEntity.GameId, gameEntity);
        // TODO: Switch to EntityFramework async
        return Task.CompletedTask;
    }

    public Task<GameEntity> GetGame(string gameId)
    {
        GameTable.TryGetValue(gameId, out var value);
        // TODO: Switch to EntityFramework async
        return Task.FromResult(value);
    }

    public Task UpdateGame(GameEntity gameEntity)
    {
        GameTable.TryRemove(gameEntity.GameId, out _);
        GameTable.TryAdd(gameEntity.GameId, gameEntity);
        // TODO: Switch to EntityFramework async
        return Task.CompletedTask;
    }
}