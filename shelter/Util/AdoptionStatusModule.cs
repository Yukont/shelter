using BLL.Interfaces;
using BLL.Services;

namespace shelter.Util
{
    public class AdoptionStatusModule
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAdoptionStatusService, AdoptionStatusService>();
        }
    }
}
