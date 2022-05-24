using System;
using System.Threading.Tasks;

namespace TicTacToe.Repositories;

public interface IGameRepository
{
    public Task<Guid> CreateGame();
}
