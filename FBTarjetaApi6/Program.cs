using FBTarjetaApi6.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Models.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using FBTarjetaApi6.Middleware;


var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddTransient<NoticiaService, NoticiaService>();
builder.Services.AddTransient<AutorService, AutorService>();
builder.Services.AddTransient<TarjetaCreditoService, TarjetaCreditoService>();
builder.Services.AddTransient<UsuarioService, UsuarioService>();
builder.Services.AddTransient<MenuService, MenuService>();
builder.Services.AddControllers();

string MyAllowSpecificOrigins = "PermitirTodo";

builder.Services.AddCors(options => {
    options.AddPolicy(MyAllowSpecificOrigins,
    acceso => acceso.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
    //options.AddPolicy(name: "angular",
    //policy  => { policy.WithOrigins("http:localhost:4200", "http://www.contoso.com"); });
});
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Api de Tarjetas de Credito",
        Description = "Ejemplo simple de como trabajar swagger en net core",
        TermsOfService = new Uri("https://programacionparaaprender.github.io/mi-pagina-web2/"),
        Contact = new OpenApiContact
        {
            Name = "Programacion para Aprender",
            Email = string.Empty,
            Url = new Uri("https://twitter.com/ProgramacionPa1"),
        },
        License = new OpenApiLicense
        {
            Name = "Use under LICX",
            Url = new Uri("https://example.com/license"),
        }
    });
});

builder.Services.AddTokenAuthentication(builder.Configuration);

var app = builder.Build();

app.UseSwagger(c =>
{
    c.SerializeAsV2 = true;
});

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller}/{action=Index}/{id?}");

//app.MapFallbackToFile("index.html");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");
});


app.Run();
