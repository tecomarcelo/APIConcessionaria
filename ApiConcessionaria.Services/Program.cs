using ApiConcessionaria.Services.Configurations;
using ApiConcessionaria.Services.ExternalServices.Implementations;
using ApiConcessionaria.Services.ExternalServices.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//auth externo
builder.Services.AddHttpClient<IAuthExternalService, AuthExternalService>();

//configurações do produto AspNet
AutoMapperConfiguration.AddAutoMapper(builder);
CorsConfiguration.AddCors(builder);
EntityFrameworkConfiguration.AddEntityFramework(builder);
SwaggerConfiguration.AddSwagger(builder);
JwtBearerConfiguration.AddJwtConfiguration(builder);

//cors configuration
builder.Services.AddCors(s => s.AddPolicy("DefaultPolicy", builder =>{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("DefaultPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
