using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http.Routing;

namespace Playground.WebApi.Versioning.Filters
{
    internal class VersionConstraint : IHttpRouteConstraint
    {
        public const string VersionHeaderName = "api-version";

        private const int DefaultVersion = 1;

        public VersionConstraint(int allowedVersion)
        {
            AllowedVersion = allowedVersion;
        }

        public int AllowedVersion
        {
            get;
            private set;
        }

        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            if (routeDirection == HttpRouteDirection.UriResolution)
            {
                var versionFromAcceptHeader = GetVersionFromMediaType(request);
                if (versionFromAcceptHeader.HasValue)
                    return (versionFromAcceptHeader.Value == AllowedVersion);


                int version = GetVersionHeader(request) ?? DefaultVersion;

                return (version == AllowedVersion);
            }

            return true;
        }

        private int? GetVersionHeader(HttpRequestMessage request)
        {
            string versionAsString;
            IEnumerable<string> headerValues;

            if (request.Headers.TryGetValues(VersionHeaderName, out headerValues) && headerValues.Count() == 1)
            {
                versionAsString = headerValues.First();
            }
            else
            {
                return null;
            }

            int version;
            if (versionAsString != null && Int32.TryParse(versionAsString, out version))
            {
                return version;
            }

            return null;
        }

        private int? GetVersionFromMediaType(HttpRequestMessage request)
        {
            var acceptHeader = request.Headers.Accept;

            var regularExpression = new Regex(@"application\/vnd\.versioning\.v([\d]+)\+json", RegexOptions.IgnoreCase);

            foreach (var mime in acceptHeader)
            {
                Match match = regularExpression.Match(mime.MediaType);
                if (match.Success == true)
                    return Convert.ToInt32(match.Groups[1].Value);
            }

            return null; //if not mime type return the API latest version
        }
    }
}