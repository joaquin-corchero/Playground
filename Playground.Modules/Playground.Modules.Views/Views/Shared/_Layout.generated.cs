﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/_Layout.cshtml")]
    public partial class _Views_Shared__Layout_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Shared__Layout_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <meta");

WriteLiteral(" charset=\"utf-8\"");

WriteLiteral(" />\r\n    <meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"width=device-width, initial-scale=1.0\"");

WriteLiteral(">\r\n    <title>");

            
            #line 6 "..\..\Views\Shared\_Layout.cshtml"
      Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral(" - My ASP.NET Application</title>\r\n\r\n");

WriteLiteral("    ");

            
            #line 8 "..\..\Views\Shared\_Layout.cshtml"
Write(Html.Partial("_ScriptsAndStylesTop"));

            
            #line default
            #line hidden
WriteLiteral("\r\n</head>\r\n<body>\r\n    <div");

WriteLiteral(" class=\"navbar navbar-inverse navbar-fixed-top\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"navbar-header\"");

WriteLiteral(">\r\n                <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"navbar-toggle\"");

WriteLiteral(" data-toggle=\"collapse\"");

WriteLiteral(" data-target=\".navbar-collapse\"");

WriteLiteral(">\r\n                    <span");

WriteLiteral(" class=\"icon-bar\"");

WriteLiteral("></span>\r\n                    <span");

WriteLiteral(" class=\"icon-bar\"");

WriteLiteral("></span>\r\n                    <span");

WriteLiteral(" class=\"icon-bar\"");

WriteLiteral("></span>\r\n                </button>\r\n");

WriteLiteral("                ");

            
            #line 19 "..\..\Views\Shared\_Layout.cshtml"
           Write(Html.ActionLink("Modules with Razor Views", "Index", "Home", new { area = "" }, new { @class = "navbar-brand" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"navbar-collapse collapse\"");

WriteLiteral(">\r\n                <ul");

WriteLiteral(" class=\"nav navbar-nav\"");

WriteLiteral(">\r\n                    <li>");

            
            #line 23 "..\..\Views\Shared\_Layout.cshtml"
                   Write(Html.ActionLink("Home", "Index", "Home"));

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n                    <li>");

            
            #line 24 "..\..\Views\Shared\_Layout.cshtml"
                   Write(Html.ActionLink("About", "About", "Home"));

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n                    <li>");

            
            #line 25 "..\..\Views\Shared\_Layout.cshtml"
                   Write(Html.ActionLink("Contact", "Contact", "Home"));

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n                    <li><a");

WriteLiteral(" href=\"/Module1/Home/About\"");

WriteLiteral(">Module 1</a></li>\r\n                </ul>\r\n");

WriteLiteral("                ");

            
            #line 28 "..\..\Views\Shared\_Layout.cshtml"
           Write(Html.Partial("_LoginPartial"));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"container body-content\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 33 "..\..\Views\Shared\_Layout.cshtml"
   Write(RenderBody());

            
            #line default
            #line hidden
WriteLiteral("\r\n        <hr />\r\n        <footer>\r\n            <p>&copy; ");

            
            #line 36 "..\..\Views\Shared\_Layout.cshtml"
                 Write(DateTime.Now.Year);

            
            #line default
            #line hidden
WriteLiteral(" - My ASP.NET Application Using Razor Views</p>\r\n        </footer>\r\n    </div>\r\n");

WriteLiteral("    ");

            
            #line 39 "..\..\Views\Shared\_Layout.cshtml"
Write(Html.Partial("_ScriptsAndStylesBottom"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

WriteLiteral("    ");

            
            #line 41 "..\..\Views\Shared\_Layout.cshtml"
Write(RenderSection("scripts", required: false));

            
            #line default
            #line hidden
WriteLiteral("\r\n</body>\r\n</html>");

        }
    }
}
#pragma warning restore 1591
