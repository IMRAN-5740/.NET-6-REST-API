var builder=WebApplication.CreateBuilder(args);
var app=builder.Build();
app.MapGet("/",()=>
{
    return "Call Get Method";
}
);


app.MapPost("/", () =>
{
    return Results.Ok("Call Post Method");
});

app.MapPut("/", () =>
{
    return Results.Ok("Call Put Method");
});
app.MapDelete("/", () =>
{
    return Results.Ok("Call Delete Method");
});


app.Run();