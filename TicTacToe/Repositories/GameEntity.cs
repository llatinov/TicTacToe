namespace TicTacToe.Repositories;

public record GameEntity
{
    public int Id { get; set; }
    public string GameId { get; set; }
    public int PlayedMoves { get; set; }
    public string NextMove { get; set; }
    public string Board { get; set; }
}