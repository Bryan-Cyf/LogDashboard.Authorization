using System;
using LogDashboard.LogDashboardBuilder;
using LogDashboard.Handle;
using LogDashboard.Route;
using Microsoft.Extensions.DependencyInjection;
using LogDashboard.Views.Dashboard;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using LogDashboard;

namespace LogDashboard
{
    public static class LogDashboardServiceCollectionExtensions
    {
        public static ILogDashboardBuilder AddLogDashboard(this IServiceCollection services, LogdashboardAccountAuthorizeFilter filter, Action<LogDashboardOptions> func = null)
        {
            LogDashboardRoutes.Routes.AddRoute(new LogDashboardRoute(LogDashboardLoginConsts.LoginRoute, typeof(Login)));

            services.AddSingleton(filter);
            services.AddSingleton<IStartupFilter, LogDashboardLoginStartupFilter>();
            services.AddTransient<LoginHandle>();
            services.AddTransient<Login>();
            var options = new LogDashboardOptions();
            func?.Invoke(options);
            options.AddAuthorizationFilter(filter);

            Action<LogDashboardOptions> config = x =>
            {
                func?.Invoke(x);
                x.AddAuthorizationFilter(filter);
            };

            return services.AddLogDashboard(config);
        }
    }
}

internal class LogDashboardLoginStartupFilter : IStartupFilter
{
    public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
    {
        return app =>
        {
            var options = app.ApplicationServices.GetRequiredService<LogDashboardOptions>();
            app.Map($"{options.PathMatch}{LogDashboardLoginConsts.LoginRoute}", app => { app.UseMiddleware<LogDashboardLoginMiddleware>(); });
            next(app);
        };
    }
}