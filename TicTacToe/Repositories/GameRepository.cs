using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace TicTacToe.Repositories;

public class GameRepository : IGameRepository
{
    private static readonly ConcurrentDictionary<Guid, GameEntity> GameTable = new();

    public Task<Guid> CreateGame()
    {
        var gameId = Guid.NewGuid();
        GameTable.TryAdd(gameId, new GameEntity());
        return Task.FromResult(gameId);
    }
}