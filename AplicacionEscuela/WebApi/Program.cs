var builder = WebApplication.CreateBuilder(args);
//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


/**
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://192.168.100.118:5500")
                                               .AllowAnyHeader()
                                               .AllowAnyMethod(); 
                      });
});

**/
/**
//Agregar la politica de seguridad CORS para aceptar las peticiones qúe se realicen en cualquier servidor.
builder.Services.AddCors(policyBuilder =>
                      policyBuilder.AddDefaultPolicy(policy => policy.WithOrigins
("*").AllowAnyHeader().AllowAnyMethod()));

**/

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
        });
});


//    aqui termina la politica
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

