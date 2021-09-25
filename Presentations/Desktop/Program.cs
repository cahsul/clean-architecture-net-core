using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Application;
using Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Desktop
{
	static class Program {

		[STAThread]
		static void Main(string[] args)
		{
			System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
			System.Windows.Forms.Application.EnableVisualStyles();
			System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

			var services = new ServiceCollection();

			//ConfigureServices(services);

			using (ServiceProvider serviceProvider = services.BuildServiceProvider())
			{
				var form1 = serviceProvider.GetRequiredService<Form1>();
				System.Windows.Forms.Application.Run(form1);
			}

			static void ConfigureServices(ServiceCollection services)
			{
				services.AddApplication();
				services.AddInfrastructure(null);
			}

		}
	}





	//  static class Program
	//  {

	//public static IConfiguration Configuration;
	//static void Main(string[] args)
	//      {
	//          //To register all default providers:
	//          //var host = Host.CreateDefaultBuilder(args).Build();
	//          //var builder = new ConfigurationBuilder()
	//          //   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
	//          //Configuration = builder.Build();
	//          System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
	//          System.Windows.Forms.Application.EnableVisualStyles();
	//          System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
	//          //System.Windows.Forms.Application.Run(Form1);

	//          var services = new ServiceCollection();

	//	ConfigureServices(services);
	//	using (ServiceProvider serviceProvider = services.BuildServiceProvider())
	//          {
	//              var form1 = serviceProvider.GetRequiredService<Form1>();
	//              System.Windows.Forms.Application.Run(form1);
	//          }
	//      }



	//      /// <summary>
	//      ///  The main entry point for the application.
	//      /// </summary>
	//      //[STAThread]
	//      //static void Main(string[] args)
	//      //{
	//      //    using IHost host = CreateHostBuilder(args).Build();
	//      //    var builder = new ConfigurationBuilder()
	//      //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
	//      //    Configuration = builder.Build();


	//      //    System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
	//      //    System.Windows.Forms.Application.EnableVisualStyles();
	//      //    System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
	//      //    System.Windows.Forms.Application.Run(new Form1());
	//      //}


	//      //static IHostBuilder CreateHostBuilder(string[] args) =>
	//      //    Host.CreateDefaultBuilder(args)
	//      //        .ConfigureServices((_, services) =>
	//      //        {
	//      //            services.AddApplication();
	//      //            services.AddInfrastructure(Configuration);
	//      //            //services.AddInfrastructure(Configuration);
	//      //        });

	//      //.ConfigureAppConfiguration((hostingContext, configuration) =>
	//      //{
	//      //    configuration.Sources.Clear();

	//      //    IHostEnvironment env = hostingContext.HostingEnvironment;

	//      //    configuration
	//      //        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
	//      //        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);

	//      //    IConfigurationRoot configurationRoot = configuration.Build();



	//      //});
	//  }
}
