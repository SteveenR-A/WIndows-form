using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime;
using System.Threading;
using System.Windows.Forms;

namespace OrdenamientoMultihilo
{
    internal static class Program
    {
    // Contenedor de servicios DI (usado para resolver el Form1 y otros servicios si se agregan)
    private static IServiceProvider? services;

    // Propiedad pública para acceder a los servicios desde otras partes del programa
    public static IServiceProvider? Services { get => services; set => services = value; }

    // Host genérico (Microsoft.Extensions.Hosting) para configurar servicios, logging y configuración.
    // No es estrictamente necesario para una app WinForms pequeña, pero permite usar DI y configuración centralizada.
    public static IHost? host;

        // Configuración de la aplicación: carga appsettings.json si existe
        // Este método lo llama el HostBuilder durante la construcción del host.
        private static void ConfigureAppConfiguration(HostBuilderContext context, IConfigurationBuilder builder)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
            builder.AddConfiguration(config);
        }

        // Registrar servicios en el contenedor DI. Aquí se registra Form1 como singleton para que
        // el Host pueda resolverlo y Application.Run use la misma instancia.
        private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            services.AddSingleton<Form1>();
        }

        // Configuración de logging para la aplicación (aquí únicamente consola).
        // Permite añadir más proveedores de logs si se desea (archivo, EventLog, etc.).
        private static void ConfigureLogging(HostBuilderContext context, ILoggingBuilder builder)
        {
            builder.ClearProviders();
            builder.AddConsole();
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        // Punto de entrada principal para la aplicación WinForms.
        // Es importante que sea síncrono y marcado con [STAThread] para que la UI de Windows funcione correctamente.
        static void Main()
        {
            // Mejora el rendimiento de inicio en escenarios donde se usa ProfileOptimization
            System.Runtime.ProfileOptimization.SetProfileRoot(AppDomain.CurrentDomain.BaseDirectory);
            System.Runtime.ProfileOptimization.StartProfile($@"{System.Reflection.Assembly.GetAssembly(typeof(Program))!.GetName().Name}.profile");

            // Evitar múltiples instancias: usamos un Mutex con nombre basado en el ensamblado
            // Si ya existe otra instancia, createdNew será false y salimos mostrando un MessageBox.
            bool createdNew;
            var appName = System.Reflection.Assembly.GetAssembly(typeof(Program))!.GetName().Name;
            Mutex m = new Mutex(true, appName, out createdNew);
            if (!createdNew)
            {
                MessageBox.Show($"{appName} is already running!", "Multiple Instances not supported.", MessageBoxButtons.OK ,  MessageBoxIcon.Error);
                return;
            }

            // Construcción del Host con configuración, servicios y logging.
            // El Host nos da un contenedor DI y un punto central para arrancar/parar la app.
            host = new HostBuilder()
                .ConfigureServices(ConfigureServices)
                .ConfigureAppConfiguration(ConfigureAppConfiguration)
                .ConfigureLogging(ConfigureLogging).Build();
            Services = host.Services;
            // Arrancamos el host de forma síncrona para mantener el flujo en el hilo STA.
            host.Start();

            // Registrar handler para cuando la aplicación termine (para parar el Host correctamente)
            Application.ApplicationExit += Application_ApplicationExit;
            // Manejo global de excepciones para capturar problemas en UI, hilos y tareas asincrónicas
            Application.ThreadException += (s, e) =>
            {
                try { MessageBox.Show($"Excepción en hilo de UI: {e.Exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } catch { }
            };
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                try
                {
                    var ex = e.ExceptionObject as Exception;
                    MessageBox.Show($"Excepción no controlada: {ex?.Message}", "Error no controlado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch { }
            };
            TaskScheduler.UnobservedTaskException += (s, e) =>
            {
                try { MessageBox.Show($"Excepción en task no observada: {e.Exception.Message}", "Task Exception", MessageBoxButtons.OK, MessageBoxIcon.Error); e.SetObserved(); } catch { }
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Ejecutar el loop principal de WinForms con la instancia de Form1 resuelta desde DI.
            // Si ocurre una excepción durante el inicio, se muestra y se asegura que el host se pare.
            try
            {
                Application.Run(Services!.GetRequiredService<Form1>());
            }
            catch (Exception ex)
            {
                try { MessageBox.Show($"Error al iniciar la aplicación: {ex.Message}", "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error); } catch { }
            }
            finally
            {
                try { host?.StopAsync().GetAwaiter().GetResult(); } catch { }
            }
        }

        private static async void Application_ApplicationExit(object? sender, EventArgs e)
        {
            await host!.StopAsync();
        }
    }
}