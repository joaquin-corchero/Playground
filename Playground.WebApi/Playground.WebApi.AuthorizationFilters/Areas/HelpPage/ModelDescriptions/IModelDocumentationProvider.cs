using System;
using System.Reflection;

namespace Playground.WebApi.AuthorizationFilters.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}