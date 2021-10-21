using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace VetOnTrack
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(); //

            services.AddDistributedMemoryCache();

            services.AddControllersWithViews();

            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddSession();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.LoginPath = "/login"; //redirecionadas quando um usuário tentar acessar um recurso, mas não tiver sido autenticado;

                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute( //carlos
                    name: "logout",
                    pattern: "logout", new { controller = "Home", action = "LogOut" });

                endpoints.MapControllerRoute( //carlos
                    name: "funcionarioupdate",
                    pattern: "perfil/update", new { controller = "Funcionario", action = "UpdateEmployee" });

                endpoints.MapControllerRoute(
                    name: "autheticate",
                    pattern: "login/autheticate", new { controller = "Login", action = "Authenticate" });

                endpoints.MapControllerRoute(
                    name: "cadastro_cliente",
                    pattern: "cadastrocliente", new { controller = "Cadastros", action = "CadastroCliente" });

                endpoints.MapControllerRoute(
                    name: "cadastro_auth_cliente",
                    pattern: "authcadastrocliente", new { controller = "Cadastros", action = "AuthCadastroCliente" });

                endpoints.MapControllerRoute(
                    name: "agenda",
                    pattern: "agenda", new { controller = "Home", action = "Agenda" });

                endpoints.MapControllerRoute(
                    name: "cadastro_funcionario",
                    pattern: "cadastrofuncionario", new { controller = "Cadastros", action = "CadastroFuncionario" });

                endpoints.MapControllerRoute(
                    name: "cadastro_auth_funcionario",
                    pattern: "authcadastrofuncionario", new { controller = "Cadastros", action = "AuthCadastroFuncionario" });

                endpoints.MapControllerRoute(
                    name: "cadastro_pet",
                    pattern: "cadastropet", new { controller = "Cadastros", action = "CadastroPet" });

                endpoints.MapControllerRoute(
                    name: "cadastro_auth_pet",
                    pattern: "authcadastropet", new { controller = "Cadastros", action = "AuthCadastroPet" });

                endpoints.MapControllerRoute(
                    name: "home",
                    pattern: "home", new { controller = "Home", action = "Index" });

                endpoints.MapControllerRoute(
                       name: "lista_clientes",
                       pattern: "clientes", new { controller = "Home", action = "Cliente" });

                endpoints.MapControllerRoute(
                    name: "servico",
                    pattern: "cadastroservico", new { controller = "Cadastros", action = "CadastroServico" });

                endpoints.MapControllerRoute(
                    name: "delete_cliente",
                    pattern: "cliente/{id_cliente}/delete", new { controller = "Cliente", action = "DeleteClient", id_cliente = 0 }); //

                endpoints.MapControllerRoute(
                    name: "delete_servico",
                    pattern: "servico/{id_servico}/delete", new { controller = "Servico", action = "DeleteService", id_servico = 0 });//

                endpoints.MapControllerRoute(
                    name: "servicos",
                    pattern: "servicos", new { controller = "Home", action = "Servico" });//

                endpoints.MapControllerRoute(
                    name: "perfil",
                    pattern: "perfil", new { controller = "Home", action = "Perfil" });//

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Login}");


            });
        }
    }
}
