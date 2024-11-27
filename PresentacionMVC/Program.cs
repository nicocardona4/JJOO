using DTO;
using LogicaAplicacion.CU;
using LogicaAplicacion.InterfacesCU;
using LogicaDatos.Repositorios;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace PresentacionMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IAltaUsuario, AltaUsuario>();
            builder.Services.AddScoped<IListadoUsuarios, ListadoUsuarios>();
            builder.Services.AddScoped<IListadoRoles, ListadoRoles>();
            builder.Services.AddScoped<IBuscarUsuarioPorId, BuscarUsuarioPorId>();
            builder.Services.AddScoped<IModificarUsuario, ModificarUsuario>();
            builder.Services.AddScoped<IBajaUsuario, BajaUsuario>();
            builder.Services.AddScoped<ILogin, LogicaAplicacion.CU.Login>();
            builder.Services.AddScoped<IListadoAtletas, ListadoAtletas>();
            builder.Services.AddScoped<IAsignarDisciplinaAtleta, AsignarDisciplinaAtleta>();
            builder.Services.AddScoped<IBuscarAtletaPorId, BuscarAtletaPorId>();
            builder.Services.AddScoped<IListadoDisciplinas, ListadoDisciplinas>();
            builder.Services.AddScoped<IAltaDisciplina, AltaDisciplina>();
            builder.Services.AddScoped<IAltaEvento, AltaEvento>();
            builder.Services.AddScoped<IBuscarDisciplinaPorId, BuscarDisciplinaPorId>();
            builder.Services.AddScoped<IBuscarAtletasPorDisciplina, BuscarAtletasPorDisciplina>();
            builder.Services.AddScoped<IListadoEventos, ListadoEventos>();
            builder.Services.AddScoped<IBuscarEventoPorNombre, BuscarEventoPorNombre>();
            builder.Services.AddScoped<IAltaParticipacion, AltaParticipacion>();
            builder.Services.AddScoped<ILogin, LogicaAplicacion.CU.Login>();
            



            builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuariosBD>();
            builder.Services.AddScoped<IRepositorioRoles, RepositorioRolesBD>();
            builder.Services.AddScoped<IRepositorioAtletas, RepositorioAtletasBD>();
            builder.Services.AddScoped<IRepositorioDisciplinas, RepositorioDisciplinasBD>();
            builder.Services.AddScoped<IRepositorioEventos, RepositorioEventosBD>();
            builder.Services.AddScoped<IRepositorioParticipaciones, RepositorioParticipacionesBD>();



            builder.Services.AddSession();



            //builder.Services.AddDbContext<OlimpiadasContext>();

            string strCon = builder.Configuration.GetConnectionString("ConexionLocal");
            builder.Services.AddDbContext<OlimpiadasContext>(options => options.UseSqlServer(strCon));

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

            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Usuario}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
