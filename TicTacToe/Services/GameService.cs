using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using TicTacToe.Mappers;
using TicTacToe.Models;
using TicTacToe.Repositories;

namespace TicTacToe.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;

    public GameService(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<CreateGameResponse> CreateGame()
    {
        var gameEntity = new GameEntity
        {
            GameId = Guid.NewGuid().ToString(),
            Board = JsonConvert.SerializeObject(GenerateEmptyBoard()),
            PlayedMoves = 0,
            NextMove = GamePlayer.X
        };
        await _gameRepository.CreateGame(gameEntity);
        var response = new CreateGameResponse
        {
            GameId = gameEntity.GameId
        };
        return response;
    }

    public async Task<Game> GetGame(string gameId)
    {
        var gameEntity = await _gameRepository.GetGame(gameId);
        if (gameEntity == null)
            return null;
        var game = gameEntity.ToGame();
        return game;
    }

    public async Task<Game> UpdateGame(Game game, PlayMoveRequest playMoveRequest)
    {
        game.PlayedMoves++;
        game.NextMove = GamePlayer.GetNextPlayer(playMoveRequest.Player);
        game.Board[playMoveRequest.Position.Row][playMoveRequest.Position.Column] = playMoveRequest.Player;

        var gameEntity = game.ToGameEntity();
        await _gameRepository.UpdateGame(gameEntity);
        return game;
    }

    private static string[][] GenerateEmptyBoard()
    {
        var board = new string[3][];
        board[0] = new string[3] { GamePlayer.None, GamePlayer.None, GamePlayer.None };
        board[1] = new string[3] { GamePlayer.None, GamePlayer.None, GamePlayer.None };
        board[2] = new string[3] { GamePlayer.None, GamePlayer.None, GamePlayer.None };
        return board;
    }
}