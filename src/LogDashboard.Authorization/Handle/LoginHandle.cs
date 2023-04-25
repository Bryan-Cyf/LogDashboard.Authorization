using LogDashboard.Models;
using LogDashboard.Route;
using System;
using System.Threading.Tasks;

namespace LogDashboard.Handle
{
    public class LoginHandle : LogDashboardHandleBase
    {
        private readonly LogdashboardAccountAuthorizeFilter _filter;

        public LoginHandle(
            IServiceProvider serviceProvider,
            LogdashboardAccountAuthorizeFilter filter) : base(serviceProvider)
        {
            _filter = filter;
        }

        public async Task<string> Login(LoginInput input)
        {
            if (_filter.Password == input?.Password && _filter.UserName == input?.Name)
            {
                _filter.SetCookieValue(Context.HttpContext);

                //Redirect
                var homeUrl = LogDashboardRoutes.Routes.FindRoute(string.Empty).Key;
                Context.HttpContext.Response.Redirect($"{Context.Options.PathMatch}{homeUrl}");
                return string.Empty;
            }
            return await View();
        }
    }
}
