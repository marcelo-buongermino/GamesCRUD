using AutoMapper;
using FluentAssertions;
using GamesCRUD.Controllers;
using GamesCRUD.Data.DTO;
using GamesCRUD.Data.DTO.Mappings;
using GamesCRUD.Models;
using GamesCRUD.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTestsGamesAPI;

public class GamesUnitTestController
{
    // Automapper config
    private readonly IMapper mapper;
    public GamesUnitTestController()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingProfile());
        });
        mapper = config.CreateMapper();
    }

    [Fact]
    public async Task CreateGame_ReturnCreatedResult()
    {
        //Arrange  
        IGameRepository fakeRepo = null!;
        var controller = new GameController(fakeRepo, mapper);

        var game = new GameDTO() {
            //Id = 1,
            Name = "Objeto de teste 1",
            Description = "Descricao de teste 1",
            Category = "Categoria de teste 1",
            Price = 129.20m,
            Platform = "Plataforma teste 1",
            ReleaseDate = new DateTime(2022, 03, 14),
        };

        //Act  
        var data = await controller.AddGame(game);

        //Assert  
        Assert.IsType<CreatedAtActionResult>(data);
    }

    [Fact]
    public async Task ListGames_Return_OKResult()
    {
        //Arrange
        var gamesList = GetTestObjects();
        var repositoryMock = new Mock<IGameRepository>();
        repositoryMock
            .Setup(m => m.ListAllGamesAsync())
            .ReturnsAsync(gamesList);
        var controller = new GameController(repositoryMock.Object, mapper);

        //Act
        var result = await controller.ListAllGames();

        //Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    //[Fact]
    //public async Task ListGames_MatchObjects()
    //{
       
    //}

    //List de objetos mocks
    private static List<Game> GetTestObjects()
    {
        var mockObjects = new List<Game>
        {
            new Game
            {
                Id = 1,
                Name = "Objeto de teste 1",
                Description = "Descricao de teste 1",
                Category = "Categoria de teste 1",
                Price = 129.20m,
                Platform = "Plataforma teste 1",
                ReleaseDate = new DateTime(2022, 03, 14),
                //CreatedAt = new DateTime(2022, 03, 14),
                UpdatedAt = new DateTime(2022, 03, 14),
            },
            new Game
            {
                Id = 2,
                Name = "Objeto de teste 2",
                Description = "Descricao de teste 2",
                Category = "Categoria de teste 2",
                Price = 129.20m,
                Platform = "Plataforma teste 3",
                ReleaseDate = new DateTime(2022, 03, 14),
                //CreatedAt = new DateTime(2022, 03, 14),
                UpdatedAt = new DateTime(2022, 03, 14),
            },
            new Game
            {
                Id = 3,
                Name = "Objeto de teste 3",
                Description = "Descricao de teste 3",
                Category = "Categoria de teste 3",
                Price = 129.20m,
                Platform = "Plataforma teste 3",
                ReleaseDate = new DateTime(2022, 03, 14),
                //CreatedAt = new DateTime(2022, 03, 14),
                UpdatedAt = new DateTime(2022, 03, 14),
            }
        };
        return mockObjects;
    }

}