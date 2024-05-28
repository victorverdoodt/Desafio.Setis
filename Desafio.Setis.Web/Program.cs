using Desafio.Setis.Domain.Common;
using Desafio.Setis.Domain.Models.Aggregator;
using Desafio.Setis.Web.Components;
using Desafio.Setis.Web.Interfaces;
using Desafio.Setis.Web.Services;

namespace Desafio.Setis.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddSingleton<XmlDataMapper<AdmDatabase>>();
            builder.Services.AddSingleton<IXmlImportService, XmlImportService>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
