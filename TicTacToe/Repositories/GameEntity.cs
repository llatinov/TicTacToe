namespace TicTacToe.Repositories;

public record GameEntity
{
    public int Id { get; set; }
    public string GameId { get; set; }
    public string Board { get; set; }
}