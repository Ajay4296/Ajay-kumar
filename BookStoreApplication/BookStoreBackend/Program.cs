using BookStoreRepositoryLayer.JsonErrorHandler;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace BookStoreBackend
{
    /// <summary>
    /// Entry point of this project
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            MSMQ message = new MSMQ();
            string value = message.ReceiveMessage();
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates the web host builder.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
