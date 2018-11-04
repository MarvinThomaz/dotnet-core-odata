using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace POC.EntityFramework.OData
{
    /// <summary>
    /// Programa de inicialização.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Método de inicialização.
        /// </summary>
        /// <param name="args">Argumentos para inicializaçõa</param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Criação do host.
        /// </summary>
        /// <param name="args">Argumentos de inicialização.</param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
