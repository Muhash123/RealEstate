using RealEstate.Infrastructure; // Подключаем наш слой Infrastructure
using RealEstate.Application.Listings.Commands;
using MediatR; // Для регистрации MediatR

var builder = WebApplication.CreateBuilder(args);

// 1. РЕГИСТРАЦИЯ СЕРВИСОВ СЛОЕВ
// Вызываем метод, который мы написали в Infrastructure/DependencyInjection.cs
builder.Services.AddInfrastructureServices(builder.Configuration);

// 2. РЕГИСТРАЦИЯ MediatR
// Указываем MediatR искать хендлеры в сборке, где лежит любая команда из Application
//
// Если у тебя MediatR версии 11.x или ниже, используй такой синтаксис:
builder.Services.AddMediatR(typeof(RealEstate.Application.Listings.Commands.CreateListingCommand).Assembly);

// Стандартные сервисы API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Конфигурация Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Маппинг контроллеров (наш ListingsController подхватится автоматически)
app.MapControllers();

app.Run();