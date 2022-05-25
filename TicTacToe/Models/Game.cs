using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TicTacToe.Models;

public record Game
{
    public string GameId { get; set; }
    public string[][] Board { get; set; }
    public int PlayedMoves { get; set; }
    public string NextMove { get; set; }
    [JsonConverter(typeof(StringEnumConverter))]
    public GameStatus GameStatus
    {
        get
        {
            if (PlayedMoves % 2 == 0)
            {
                return IsWinner(GamePlayer.O) ? GameStatus.WinnerO : GameStatus.Active;
            }
            else
            {
                return IsWinner(GamePlayer.X) ? GameStatus.WinnerX :
                    PlayedMoves == 9 ? GameStatus.Draw : GameStatus.Active;
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
}