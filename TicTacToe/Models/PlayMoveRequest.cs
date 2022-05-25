namespace TicTacToe.Models;

public class PlayMoveRequest
{
    public string Player { get; set; }
    public PlayPosition Position { get; set; }
}