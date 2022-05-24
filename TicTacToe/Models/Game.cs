using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TicTacToe.Models;

public record Game
{
    public string GameId { get; set; }

    public string[][] Board { get; set; }

    public int PlayedMoves => GetPlayedMoves();

    [JsonConverter(typeof(StringEnumConverter))]
    public GameStatus GameStatus
    {
        get
        {
            var playedMoves = PlayedMoves;
            if (playedMoves % 2 == 0)
            {
                return IsWinner(GamePlayer.O) ? GameStatus.WinnerO : GameStatus.Active;
            }
            else
            {
                return IsWinner(GamePlayer.X) ?
                    GameStatus.WinnerX :
                    playedMoves == 9 ? GameStatus.Draw : GameStatus.Active;
            }
        }
    }

    private bool IsWinner(string player)
    {
        return Board[0][0] == player && Board[0][1] == player && Board[0][2] == player ||
            Board[1][0] == player && Board[1][1] == player && Board[1][2] == player ||
            Board[2][0] == player && Board[2][1] == player && Board[2][2] == player ||
            Board[0][0] == player && Board[1][0] == player && Board[2][0] == player ||
            Board[0][1] == player && Board[1][1] == player && Board[2][1] == player ||
            Board[0][2] == player && Board[1][2] == player && Board[2][2] == player ||
            Board[0][0] == player && Board[1][1] == player && Board[2][2] == player ||
            Board[2][0] == player && Board[1][1] == player && Board[0][2] == player;
    }

    private int GetPlayedMoves()
    {
        var result = 0;
        foreach (var line in Board)
        {
            foreach (var cell in line)
            {
                if (cell == GamePlayer.X || cell == GamePlayer.O)
                {
                    result++;
                };
            }
        }
        return result;
    }
}