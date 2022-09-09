using PeopleActz.Application.Helpers.Settings;

namespace PeopleActz.API.Extensions
{
    public static class CrossOriginRequestsExtension
    {
        /// <summary>
        /// Extends Customized Cross Origin Requests
        /// </summary>
        /// <param name="this">Injected <see cref="IServiceCollection"/></param>
        /// <param name="JwtSettings">Injected <see cref="JwtSettings"/></param>
        public static void AddCustomizedCrossOriginRequests(this IServiceCollection services, JwtSettings _JwtSettings)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins(_JwtSettings.JwtAudiences.ToArray()).AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
                });
            });
        }
    }
}
