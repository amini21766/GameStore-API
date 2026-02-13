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

// GET / All Games
app.MapGet("games", () => games);

// GET / A Specific Game
app.MapGet("games/{id}", (int id) => games.Find(games => games.Id == id));


// GET / the depault URL
app.MapGet("/", () => "Hello World!");

app.Run();
