using System.Web;
using System.Web.Mvc;

namespace Playground.CQRS.Web.Repositories
{
    public interface ISessionRepository
    {
        void SetValue(string variableName, int value, ControllerContext controllerContext );
    }

    public class SessionRepository : ISessionRepository
    {
        public void SetValue(string variableName, int value, ControllerContext controllerContext)
        {
            controllerContext.HttpContext.Session[variableName] = value;
        }
    }
}