using GameStore.Api.DtoS;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndPointName = "GetGame";

List<GameDto> gameDtos = new()
{
    new GameDto(
        1,
        "Street Fighter II",
        "Fighting",
        19.99M,
        new DateOnly(1992, 7, 15)
    ),
    new GameDto(
        2,
        "Final Fantasy XIV",
        "RolePlay",
        59.99M,
        new DateOnly(2010, 9, 15)
    ),
    new GameDto(
        3,
        "Fifa 2023",
        "Sports",
        110.99M,
        new DateOnly(2023, 7, 15)
    )
};

// GET endpoint to retrieve all games
app.MapGet("/games", () => gameDtos);

// GET endpoint to retrieve a specific game by ID
app.MapGet("/games/{id}", (int id) => gameDtos.Find(game => game.Id == id))
    .WithName(GetGameEndPointName);

// POST endpoint to create a new game
app.MapPost("/games/create", (CreateGameDto newGame) =>
{
    GameDto game = new(
        gameDtos.Count + 1,
        newGame.Name,
        newGame.Genere,
        newGame.Price,
        newGame.ReleaseDate
    );

    gameDtos.Add(game);

    // Send to client
    return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id }, game);
});


//app.MapGet("/", () => "Hello World!");

app.Run();
