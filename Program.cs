var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/hola", () => "¡Hola, mundo desde ASP.NET Core!");

app.MapGet("/saludo/{nombre}", (string nombre) =>
    $"¡Hola, {nombre}! Bienvenido a Desarrollo Web 2.");

app.MapGet("/suma", (int a, int b) =>
    Results.Ok(new { a, b, suma = a + b }));

app.MapGet("/edad/{anio}", (int anio) =>
{
    var actual = DateTime.Now.Year;

    if (anio > actual || anio < 1900)
        return Results.BadRequest(new { error = "Año no válido." });

    var edad = actual - anio;
    return Results.Ok(new { anio, edad, mayorDeEdad = edad >= 18 });
});


app.Run();
