using AspnetCoreMvcFull.DB;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Add services to the container.
builder.Services.AddControllersWithViews();
  //.AddRazorRuntimeCompliation();

var conn = builder.Configuration.GetConnectionString("DefaultConection");
//Agregar contexto
builder.Services.AddDbContext<ColegioContext>(opt => opt.UseSqlServer(conn));

// Agregar Identity para manejar usuarios y roles
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
  options.Password.RequireDigit = true;
  options.Password.RequireLowercase = true;
  options.Password.RequireUppercase = true;
  options.Password.RequireNonAlphanumeric = true;
  options.Password.RequiredLength = 6;
  options.Password.RequiredUniqueChars = 1;
})
    .AddEntityFrameworkStores<ColegioContext>()
    .AddDefaultTokenProviders();

builder.Services.AddLogging(logging =>
{
  logging.ClearProviders();
  logging.AddConsole(); // Log a la consola (útil para desarrollo)
  logging.AddDebug();   // Log a la salida de depuración
  logging.AddEventSourceLogger(); // Log más avanzado para producción
});

//builder.Services.AddAuthentication()
//    .AddCookie(options =>
//    {
//      options.LoginPath = "/Auth/LoginBasic"; // Ruta a la página de login
//      options.AccessDeniedPath = "/Auth/LoginBasic"; // Redirigir aquí si no está autorizado
//    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=LoginBasic}/{id?}");

app.Run();
