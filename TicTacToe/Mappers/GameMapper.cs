using Newtonsoft.Json;
using TicTacToe.Models;
using TicTacToe.Repositories;

namespace TicTacToe.Mappers;

public static class GameMappers
{
    public static GameEntity ToGameEntity(this Game game)
    {
        var gameEntity = new GameEntity();
        gameEntity.GameId = game.GameId;
        gameEntity.Board = JsonConvert.SerializeObject(game.Board);
        gameEntity.PlayedMoves = game.PlayedMoves;
        gameEntity.NextMove = game.NextMove;
        return gameEntity;
    }

    public static Game ToGame(this GameEntity gameEntity)
    {
        var game = new Game();
        game.GameId = gameEntity.GameId;
        game.Board = JsonConvert.DeserializeObject<string[][]>(gameEntity.Board);
        game.PlayedMoves = gameEntity.PlayedMoves;
        game.NextMove = gameEntity.NextMove;
        return game;
    }
}