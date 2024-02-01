using Microsoft.EntityFrameworkCore;
using WebBirthdayApp.Database;


var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddDbContext<PersonDbContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("BDConnStr"))
);

builder.Services
	.AddControllers(options => options.ReturnHttpNotAcceptable = true)
	.AddNewtonsoftJson()
	.AddXmlDataContractSerializerFormatters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthorization();
app.MapControllers();

app.Run();
