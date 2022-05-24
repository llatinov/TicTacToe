using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
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
        var gameId = Guid.NewGuid().ToString();
        var gameEntity = new GameEntity
        {
            GameId = gameId,
            Board = JsonConvert.SerializeObject(GenerateEmptyBoard())
        };
        await _gameRepository.CreateGame(gameEntity);
        var response = new CreateGameResponse
        {
            GameId = gameId
        };
        return response;
    }

    public async Task<Game> GetGame(string gameId)
    {
        var gameEntity = await _gameRepository.GetGame(gameId);
        var game = new Game
        {
            GameId = gameEntity.GameId,
            Board = JsonConvert.DeserializeObject<string[][]>(gameEntity.Board)
        };
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