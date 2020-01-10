using Microsoft.Extensions.DependencyInjection;

namespace BlazorToastify
{
    public static class ToastsExtensions
    {
        public static IServiceCollection AddToasts(this IServiceCollection services)
        {
            return services.AddScoped<IToastService, ToastService>();
        }
    }
}
