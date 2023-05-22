using UsuariosApp.API.Extensions;
using UsuariosApp.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddRouting( options => options.LowercaseUrls = true );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEntityFramework(builder.Configuration);
builder.Services.AddSwaggerDoc();
//Automapper precisa ser injetado após o AddServices
builder.Services.AddServices(builder.Configuration);
builder.Services.AddAutoMapper();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwaggeDoc();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionMiddleware>();

app.Run();


/*Define a classe program como publica para poder ser utilizada em outro lugar
  (como será utilizada no xUnit) */
public partial class Program { }