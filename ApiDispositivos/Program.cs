using ApiDispositivos.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<DispositivoService>();


// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
   

}

app.UseAuthorization();
app.UseRouting();

app.MapControllers();

app.Run();
