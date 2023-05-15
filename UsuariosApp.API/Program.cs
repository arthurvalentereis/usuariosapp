using UsuariosApp.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddRouting( options => options.LowercaseUrls = true );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEntityFramework(builder.Configuration);
builder.Services.AddSwaggerDoc();
builder.Services.AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwaggeDoc();

app.UseAuthorization();

app.MapControllers();

app.Run();


/*Define a classe program como publica para poder ser utilizada em outro lugar
  (como será utilizada no xUnit) */
public partial class Program { }