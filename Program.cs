using GameStore_API.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


List<GameDtos> games = [
    new (
        1,
        "PUBG Mobile",
        "Fighting",
        20.20M,
        new DateOnly(1992, 5, 5)
    ),
      new (
        2,
        "PUBG Mobil2",
        "Fighting",
        20.20M,
        new DateOnly(1992, 5, 5)
    ),
       new (
        3,
        "PUBG Mobile3",
        "Fighting",
        20.20M,
        new DateOnly(1992, 5, 5)
    ),
       new (
        4,
        "PUBG Mobile4",
        "Fighting",
        20.20M,
        new DateOnly(1992, 5, 5)
    ),

];

string GETGameEndPointName = "GETGame";

// GET / All Games
app.MapGet("games", () => games);

// GET / A Specific Game
app.MapGet("games/{id}", (int id) =>
    {
        GameDtos? game = games.Find(game => game.Id == id);
        return game is null ? Results.NotFound() : Results.Ok(game);
        })
        .WithName(GETGameEndPointName);

// POST / Posting A Game
app.MapPost("games", (CreateGameDto newGame) => {

    GameDtos game = new (
        games.Count +1 ,
        newGame.Name,                       
        newGame.Genre,
        newGame.Price,
        newGame.RelaseDate);

    games.Add(game);

    return Results.CreatedAtRoute(GETGameEndPointName, new {id = game.Id}, game);
});

// PUT / Updating A Game
app.MapPut("games/{id}", (int id,UpdateGameDto updateGame) =>
{
    var index = games.FindIndex(game => game.Id == id);
    games[index] = new GameDtos(
        id,
        updateGame.Name,
        updateGame.Genre,
        updateGame.Price,
        updateGame.RelaseDate
    );
    return Results.NoContent();
});

// DELETE / Deleting A Game
app.MapDelete("games/{id}", (int id) =>
{
    games.RemoveAll(game => game.Id == id);

    return Results.NoContent();
}
);

// GET / the depault URL
app.MapGet("/", () => "Hello World!");

app.Run();
