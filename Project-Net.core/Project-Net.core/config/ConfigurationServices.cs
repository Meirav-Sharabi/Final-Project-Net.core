using AutoMapper;
using Weight_Watchers.core.interfaces_BAL;
using Weight_Watchers.core.interfaces_DAL;
using Weight_Watchers.service.BL;
using Weight_Watchers.service.DAL;
using WeightWatchers.service.DAL;

namespace Project_Net.core.config
{
    public static class ConfigurationServices
    {
        public static void ConfigurationService(this IServiceCollection services)
        {
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<ISubscriberRepository, SubscriberRepository>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<ISubscriberService, SubscriberService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new WeightWatcherProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
//DA AKA
//דא עקא 