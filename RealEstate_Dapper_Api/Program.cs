using RealEstate_Dapper_Api.Hubs;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Repositories.BottomGridRepositories;
using RealEstate_Dapper_Api.Repositories.CategoryRepositories;
using RealEstate_Dapper_Api.Repositories.ContactRespositories;
using RealEstate_Dapper_Api.Repositories.EmployeeRepositories;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepositories;
using RealEstate_Dapper_Api.Repositories.ProductRepositories;
using RealEstate_Dapper_Api.Repositories.ServiceRepositories;
using RealEstate_Dapper_Api.Repositories.StatisticRepositories;
using RealEstate_Dapper_Api.Repositories.TestimonialRepositories;
using RealEstate_Dapper_Api.Repositories.ToDoListRepositories;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<Context>();
builder.Services.AddTransient<ICategoryRepository,CategoryRepository>();
builder.Services.AddTransient<IProductRepository,ProductRepository>();
builder.Services.AddTransient<IWhoWeAreDetailRepository,WhoWeAreDetailRepository>();
builder.Services.AddTransient<IServiceRepository,ServiceRepository>();
builder.Services.AddTransient<IBottomGridRepository,BottomGridRepository>();
builder.Services.AddTransient<IPopularLocationRepository,PopularLocationRepository>();
builder.Services.AddTransient<ITestimonialRepository,TestimonialRepository>();
builder.Services.AddTransient<IEmployeRepository,EmployeRepository>();
builder.Services.AddTransient<IStatisticRepository,StatisticRepository>();
builder.Services.AddTransient<IContactRepository,ContactRepository>();
builder.Services.AddTransient<IToDoListRepository,ToDoListRepository>();
builder.Services.AddTransient<IStatisticsRepository,StatisticsRepository>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
               .AllowAnyMethod()
               .SetIsOriginAllowed((host) => true) // allow any origin
               .AllowCredentials();
    });
});

builder.Services.AddHttpClient();

builder.Services.AddSignalR();

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<SignalRHub>("/signalrhub");

app.Run();
