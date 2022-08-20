using MassTransit;
using MassTransitProject.Components.Consumers;
using MassTransitProject.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddSingleton(KebabCaseEndpointNameFormatter.Instance);

builder.Services.AddMassTransit(cfg =>
{
    cfg.AddConsumer<SubmitOrderConsumer>();
    cfg.AddMediator();

    cfg.UsingInMemory((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });
    //cfg.UsingRabbitMq();
    cfg.AddRequestClient<SubmitOrder>();
});

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

app.UseAuthorization();

app.MapControllers();

app.Run();
