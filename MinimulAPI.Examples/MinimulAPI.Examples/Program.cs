using MinimulAPI.Examples.Data;
using MinimulAPI.Examples.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

var builder=WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseInMemoryDatabase("TestDB");
});
var app=builder.Build();

app.MapGet("/posts",(ApplicationDbContext _context)=>
{
    var posts= _context.PostModels.ToList();
    return  Results.Ok(posts);
});
app.MapPost("/posts",(PostModel posts, ApplicationDbContext _context) =>
{
    _context.PostModels.Add(posts);
    bool isSaved = _context.SaveChanges() > 0;
    if(isSaved)
    {
        return Results.Ok("Post Model has been Saved Successfully");
    }
    return Results.BadRequest("Post Model Not Saved");
});

app.MapPut("/posts",(int Id, PostModel postModel, ApplicationDbContext _context)=>
{
    var data=_context.PostModels.FirstOrDefault(c=>c.Id==postModel.Id);
    if(data==null)
    {
        return Results.NotFound();
    }
    if(Id!=data.Id)
    {
        return Results.BadRequest("Searching Data not Matched");
    }
    data.Id=postModel.Id;
    data.Title = postModel.Title;
    data.Description = postModel.Description;
  bool isUpdated=  _context.SaveChanges()>0;
    if(isUpdated)
    {
        return Results.Ok("Post Model has been Updated");
    }
    return Results.BadRequest("Post Model Not Updated");
});

app.MapDelete("/posts",(int Id,ApplicationDbContext _context) =>
{
    var data=_context.PostModels.FirstOrDefault(c=>c.Id==Id);
    if(data==null)
    {
        return Results.NotFound();

    }
    _context.PostModels.Remove(data);
    bool isDeleted = _context.SaveChanges() > 0;
    if(isDeleted)
    {
        return Results.Ok("Post Model Has been Deleted");
    }
    return Results.BadRequest("Post Model has Dot Removed");
});

app.MapPost("api/post", (PostModel postModel) =>
{
    string messge="";
    messge += $"Name : {postModel.Title}";
    
    messge += $"Description : {postModel.Description}";
    return Results.Ok(messge);
});

app.MapPut("/", (string name) =>
{
    return Results.Ok("Call Put Method"+name);
});
app.MapDelete("/", () =>
{
    return Results.Ok("Call Delete Method");
});


app.Run();