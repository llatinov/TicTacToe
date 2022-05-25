using TicTacToe.Models;

namespace TicTacToe.Services;

public interface IGameValidator
{
    ValidationStatus ValidateGame(Game game, PlayMoveRequest playMoveRequest);
}
