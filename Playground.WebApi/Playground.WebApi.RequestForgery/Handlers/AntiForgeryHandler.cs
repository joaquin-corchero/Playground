﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Playground.WebApi.RequestForgery.Handlers
{
    public class AntiForgeryHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var cookie = string.Empty;
            var form = string.Empty;
            IEnumerable<string> antiForgeryHeaders;
            if (request.Headers.TryGetValues("AntiForgeryToken", out antiForgeryHeaders))
            {
                var tokens = antiForgeryHeaders.First().Split(':');
                if (tokens.Length == 2)
                {
                    cookie = tokens[0].Trim();
                    form = tokens[1].Trim();
                }
            }
            try
            {
                AntiForgery.Validate(cookie, form);
            }
            catch(Exception e)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Forbidden)
                {
                    Content = new StringContent("We don't like your counterfeit request.")
                };
                return Task.FromResult(response);
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}