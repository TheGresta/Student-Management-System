using Castle.Core.Interceptor;
using Core.Exceptions;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace StudentManagementSystem.Business.BusinessAspects
{
    public class SecuretOperation : MethodInterception
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly string[] _roles;

        public SecuretOperation(string roles)
        {
            _roles = roles.Split(",");
            _contextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var claims = _contextAccessor.HttpContext.User.ClaimRoles();

            foreach (string role in _roles)
                if (claims.Contains(role))
                    return;

            throw new AuthorizeException();
        }
    }
}
