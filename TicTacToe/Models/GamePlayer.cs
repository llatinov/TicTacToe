namespace TicTacToe.Models;

public static class GamePlayer
{
    public static string None = "-";
    public static string X = "X";
    public static string O = "O";

    public static string GetNextPlayer(string player) => player == O ? X : O;
}