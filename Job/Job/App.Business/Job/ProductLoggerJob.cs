using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Job
{
    public class ProductLoggerJob(IServiceProvider provider, ILogger<ProductLoggerJob> logger) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = provider.CreateScope();

                var productService = scope.ServiceProvider.GetRequiredService<IProductService>();
                var loggerService = scope.ServiceProvider.GetRequiredService<IJobLoggerService>();

                var products = await productService.GetAllsAsync();
                var logMessage = $"Job çalıştı: {products.Count} ürün bulundu.";

                foreach (var product in products)
                {
                    logger.LogInformation($"Product: {product.Name}, Category: {product.Category.Name}");
                }

                await loggerService.LogAsync(logMessage);

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken); //1 dakikada bir job çalışır.
            }
        }
    }
}
