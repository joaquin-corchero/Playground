using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Playground.WebApi.MessageHandlers.Handlers
{
    public class NaiveAuthenticationHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            IEnumerable<string> userValues;
            if (!request.Headers.TryGetValues("UserName", out userValues))
                return base.SendAsync(request, cancellationToken);

            var user = userValues.FirstOrDefault();
            if (!string.IsNullOrEmpty(user))
            {
                Thread.CurrentPrincipal = //How internal code will execute, this is not required as you probably don't want to make internal calls with that user
                    HttpContext.Current.User = //How you are configured to the controllers
                    new GenericPrincipal(new GenericIdentity(user), new[] { "User" });
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}