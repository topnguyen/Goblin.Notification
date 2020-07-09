using Elect.Core.ConfigUtils;
using Goblin.Core.Web.Setup;
using Goblin.Notification.Core;
using Goblin.Notification.Repository;
using Goblin.Notification.Share.Validators;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Goblin.Notification
{
    public class Startup : BaseApiStartup
    {
        public Startup(IWebHostEnvironment env, IConfiguration configuration) : base(env, configuration)
        {
            RegisterValidators.Add(typeof(IValidator));

            BeforeConfigureServices = services =>
            {
                // Setting

                SystemSetting.Current = Configuration.GetSection<SystemSetting>("Setting");
                
                // Database

                services.AddGoblinDbContext();
            };
        }
    }
}