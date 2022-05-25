using TicTacToe.Models;

namespace TicTacToe.Services;

public class GameValidator : IGameValidator
{
    public ValidationStatus ValidateGame(Game game, PlayMoveRequest playMoveRequest)
    {
        if (game.GameStatus != GameStatus.Active)
            return ValidationStatus.GameEnded;

        var position = playMoveRequest.Position;
        if (!IsPositionValid(position))
            return ValidationStatus.InvalidPosition;

        if (game.Board[position.Row][position.Column] != GamePlayer.None)
            return ValidationStatus.PostionNotEmpty;

        if (game.NextMove != playMoveRequest.Player)
            return ValidationStatus.InvalidPlayerTurn;

        return ValidationStatus.Valid;
    }

    private static bool IsPositionValid(PlayPosition position)
        => 0 <= position.Row && position.Row <= 2 &&
            0 <= position.Column && position.Column <= 2;
}
