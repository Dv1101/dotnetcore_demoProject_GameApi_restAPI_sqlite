namespace GameStore.Api.DtoS;

public record class CreateGameDto(
    string Name, 
    string Genere, 
    decimal Price, 
    DateOnly ReleaseDate
);
