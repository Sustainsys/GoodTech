var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultScheme = "cookies";
    opt.DefaultChallengeScheme = "oidc";
})
    .AddCookie("cookies", opt =>
    {
        opt.Cookie.Name = "Web2";
    })
    .AddOpenIdConnect("oidc", opt =>
    {
        opt.Authority = "https://localhost:5000";

        opt.ClientId = "web2";
        opt.ClientSecret = "5FF27034-6CEB-4284-8E0E-87044C115651";

        opt.Scope.Add("api1");

        opt.MapInboundClaims = false;

        opt.ResponseType = "code";

        opt.GetClaimsFromUserInfoEndpoint = true;

        opt.SaveTokens = true;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages()
    .RequireAuthorization();

app.Run();
