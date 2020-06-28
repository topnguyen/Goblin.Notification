﻿using System.Threading.Tasks;
using Goblin.Notification.Contract.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Goblin.Notification
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            await Goblin.Core.Web.Setup.ProgramHelper.Main(args, webHostBuilder =>
                {
                    webHostBuilder.UseStartup<Startup>();
                }, scope =>
                {
                    var bootstrapperService = scope.ServiceProvider.GetService<IBootstrapperService>();
                    
                    bootstrapperService.InitialAsync().Wait();
                }
            );
        }
    }
}