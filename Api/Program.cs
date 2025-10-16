var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddAuthentication()
    .AddJwtBearer(opt =>
    {
        opt.Authority = "https://localhost:5000";

        opt.TokenValidationParameters.ValidateAudience = false;

        opt.MapInboundClaims = false;
    });


builder.Services.AddAuthorizationBuilder()
    .AddPolicy("api1", p =>
    {
        p.RequireAuthenticatedUser();
        p.RequireClaim("scope", "api1");
    })
    .AddPolicy("api3", p =>
    {
        p.RequireAuthenticatedUser();
        p.RequireClaim("scope", "api3");
    });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
