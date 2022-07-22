using Microsoft.OpenApi.Models;
using SimpleCrudApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(System.Reflection.Assembly.GetExecutingAssembly());
builder.Services.AddScoped<ITaskSettingService, TaskSettingService>();
builder.Services.AddScoped<ITaskParameterService, TaskParameterService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt => 
    opt.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Simple CRUD API with .NET6, EF6, PostgreSQL, AutoMapper, SwaggerUI.",
        Contact = new OpenApiContact
        {
            Email = "j.maleszyk@gmail.com",
        },
    }));

builder.Services.AddDbContext<ApiDbContext.Context.ApiDatabaseContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ApiDbConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
//app.UseAuthentication();
app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Simple CRUD API v1");
});

app.UseRouting();
//app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();