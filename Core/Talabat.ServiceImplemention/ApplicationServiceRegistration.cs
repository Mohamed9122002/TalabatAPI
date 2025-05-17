using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.ServiceAbstraction;
using Talabat.ServiceImplemention.MappingProfiles;

namespace Talabat.ServiceImplemention
{
  public static  class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection Services)
        {
            Services.AddAutoMapper(typeof(ProductProfiles).Assembly);
            Services.AddScoped<IServiceManager, ServiceManager>();
            return Services;
        }
    }
}
