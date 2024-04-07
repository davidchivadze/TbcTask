using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Net;
using TbcTask.Domain.Models.Resources;
using TbcTask.Domain.Repository;
using TbcTask.Domain.Services;
using TbcTask.Infrastructure.Middlewares;
using TbcTask.Infrastructure.Repository;
using TbcTask.Infrastructure.Services;
using TbcTask.Infrastructure.Store;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<PersonDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PersonConnectionString"));
});
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped<IPhysicalPersonRepository, PhysicalPersonRepository>();
builder.Services.AddScoped<IPhysicalPersonService, PhysicalPersonService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",new Microsoft.OpenApi.Models.OpenApiInfo { Title ="Physical Persons API",Version = "v1"});
    c.OperationFilter<SwaggerLocalizationHeaderOperationFilter>();
});
builder.Services.AddLocalization(options => options.ResourcesPath = "..\\TbcTask\\TbcTask\\TbcTask.Domain.Models\\Resources\\");
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { new CultureInfo("en-US"), new CultureInfo("ka-GE") };
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
});
//builder.WebHost.ConfigureKestrel((context, serverOptions) =>
//{
//    serverOptions.Listen(IPAddress.Loopback, 5000);
//    //serverOptions.Listen(IPAddress.Loopback, 5001, listenOptions =>
//    //{
//    //    listenOptions.UseHttps("testCert.pfx", "testPassword");
//    //});
//});
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Add other services...

builder.Services.AddControllers();

var app = builder.Build();


//Middlewares
//app.Use(async (context, next) =>
//{
//    var acceptLanguage = context.Request.Headers["Accept-Language"];
//    await next();
//});
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<LocalizationMiddleware>();
//Migration Auto Apply

ApplyMigration();
// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();
void ApplyMigration()
{
    using (var scope = app.Services.CreateScope())
    {
        var _db = scope.ServiceProvider.GetRequiredService<PersonDbContext>();
        if (_db.Database.GetPendingMigrations().Count() > 0)
        {
            _db.Database.Migrate();
        }
    }
}