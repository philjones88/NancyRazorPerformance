using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.Conventions;

namespace NancyRazorPerformance
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions nc)
        {
            nc.ViewLocationConventions.Add((viewName, model, context) =>
            {
                string modulePath = context.ModulePath;

                if (!string.IsNullOrWhiteSpace(modulePath) || modulePath.StartsWith("/"))
                    modulePath = modulePath.Remove(0, 1);

                return string.Concat(modulePath, "/Views/", context.ModuleName, "/", viewName);
            });

            nc.ViewLocationConventions.Add((viewName, model, context) =>
            {
                string modulePath = context.ModulePath;

                if (!string.IsNullOrWhiteSpace(modulePath) || modulePath.StartsWith("/"))
                    modulePath = modulePath.Remove(0, 1);

                return string.Concat(modulePath, "/Views/Shared/", viewName);
            });

            nc.ViewLocationConventions.Add((viewName, model, context) => string.Concat("Public/Views/", context.ModuleName, "/", viewName));
            nc.ViewLocationConventions.Add((viewName, model, context) => string.Concat("Public/Views/Shared/", viewName));
        }
    }
}