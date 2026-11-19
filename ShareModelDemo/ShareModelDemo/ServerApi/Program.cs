using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Shares;

namespace ServerApi;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }


    public static void StartApi()
    {
        try
        {
            var builder = WebApplication.CreateBuilder();
            app = builder.Build();

            // Define API endpoint
            app.MapGet($"/{Shares.Setting.GetAllProductsEndpoint}", GetProducts);
            app.MapPost($"/{Shares.Setting.PostProductEndpoint}", AddProductAsync);
            app.Run(Shares.Setting.BaseUrl);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Trying to host an API > {ex.Message}", "Hosting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            app = null;
        }
    }

    private static async Task<int> AddProductAsync(Product prd)
    {
        var result = await Task.Run<int>(() =>
        {
            if (products.Any(p=>p.No==prd.No)) return -1;
            products.Add(prd);
            return prd.No;
        });
        return result;
    }

    public static void StopApi()
    {
        if (app == null) return;
        app!.StopAsync().Wait();
        app = null;
    }

    public static WebApplication? app = null;
    
    public static List<Shares.Product> products = new()
    {
        new(){ No= 1, Name="Product 1", Price=23.5},
        new(){ No= 2, Name="Product 2", Price = 12.0 }
    };
    public static List<Shares.Product> GetProducts() => products;
}