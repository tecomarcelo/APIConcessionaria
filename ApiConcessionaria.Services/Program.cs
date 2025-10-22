using ApiConcessionaria.Services.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//configurações do produto AspNet
AutoMapperConfiguration.AddAutoMapper(builder);
CorsConfiguration.AddCors(builder);
EntityFrameworkConfiguration.AddEntityFramework(builder);
SwaggerConfiguration.AddSwagger(builder);

//cors configuration
builder.Services.AddCors(s => s.AddPolicy("DefaultPolicy", builder =>{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("DefaultPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
