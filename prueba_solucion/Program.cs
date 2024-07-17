using Microsoft.EntityFrameworkCore;
using prueba_solucion.Context;
using prueba_solucion.Models.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");//usamos la variable de entorno, para efectos de pruebas usamos una sola en caso de despliegue usamos una conexion apuntando a prod y otra a dev
builder.Services.AddDbContext<AplicacionDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<ClientesServices>();//añadimos los servicios al proyecto

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//rutas de servicios
app.MapControllerRoute(
    name: "crearcliente",
    pattern: "crearcliente",
    defaults: new { controller = "CrearUserController", action = "Post" } //asociamos el controllador con la accion rest
);

app.MapControllerRoute(
    name: "crearcliente",
    pattern: "crearcliente",
    defaults: new { controller = "VerClientesController", action = "Get" } //asociamos el controllador con la accion rest
);

app.MapControllerRoute(
    name: "eliminar_cliente",
    pattern: "eliminar_cliente",
    defaults: new { controller = "EliminarController", action = "Delete" } //asociamos el controllador con la accion rest
);
// ----

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);


app.Run();
