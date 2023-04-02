using AddressSearch.Application.UseCases.AddressUseCases;
using AddressSearch.Application.UseCases.AddressUseCases.Interfaces;
using AddressSearch.Domain.Interfaces;
using AddressSearch.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IGetAddressByCepUseCase, GetAddressByCepUseCase>();
builder.Services.AddScoped<IGetAddressByStreetUseCase, GetAddressByStreetUseCase>();
builder.Services.AddScoped<IGetAddressByStreetUseCase, GetAddressByStreetUseCase>();
//builder.Services.AddScoped<IExternalApiRepository, ViaCepRepository>();
//builder.Services.AddScoped<IExternalApiRepository, ApiCepRepository>();
builder.Services.AddScoped<IExternalApiRepository, AwesomeApiCepRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.Add(typeof(Program));

//builder.Services.AddScoped<IMapper, AddressProfile>();
//builder.Services.AddScoped(typeof(AddressProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
