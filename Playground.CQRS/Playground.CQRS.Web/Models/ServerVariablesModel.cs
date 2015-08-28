
using System.Collections.Specialized;
namespace Playground.CQRS.Web.Models
{
    public class ServerVariablesModel
    {
        public NameValueCollection Variables { get; private set; }

        public ServerVariablesModel(NameValueCollection nameValueCollection)
        {
            this.Variables = nameValueCollection;
        }

    }
}