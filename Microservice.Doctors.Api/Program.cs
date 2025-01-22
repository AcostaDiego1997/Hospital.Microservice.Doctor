using Microservice.Doctors.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

AppSettings_Config settings = new AppSettings_Config(builder);
_ = new Services_Dependencies(builder.Services);
_ = new Repositories_Dependencies(builder.Services);
_ = new DataContext_Dependency(builder.Services, settings.AppSettings);
_ = new AutoMapper_Config(builder.Services);
_ = new Mediatr_Config(builder.Services);
//_ = new JWT_Config(builder.Services, settings.AppSettings);
//_ = new Swagger_Config(builder.Services);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy",
        builder => builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
//app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
