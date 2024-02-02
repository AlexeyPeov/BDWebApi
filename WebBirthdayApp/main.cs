using Microsoft.EntityFrameworkCore;
using WebBirthdayApp.Database;


var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("BDConnStr"))
);

builder.Services
	.AddControllers(options => options.ReturnHttpNotAcceptable = true)
	.AddJsonOptions(o =>
	{
		o.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
		o.JsonSerializerOptions.PropertyNamingPolicy = null;
	})
	.AddNewtonsoftJson()
	.AddXmlDataContractSerializerFormatters();

builder.Services.AddCors(opt => 
	opt.AddDefaultPolicy(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
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
app.UseCors();
app.UseAuthorization();
app.MapControllers();

app.Run();
