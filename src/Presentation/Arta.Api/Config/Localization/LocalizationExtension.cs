using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Arta.Api.Middlewares;
using Microsoft.Extensions.Configuration;

namespace Arta.Api.Config.Localization
{
    public static class LocalizationExtension
    {
        public static void AddCustomLocalization(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });
            services.AddMvc().AddDataAnnotationsLocalization(options => options.DataAnnotationLocalizerProvider = (t, f) => f.Create(typeof(SharedResources)));

            var languages = configuration.GetSection("supportedLanguage").AsEnumerable().Where(p => !string.IsNullOrEmpty(p.Value)).Select(p => p.Value).Reverse().ToList();
            services.Configure<RequestLocalizationOptions>(opt =>
            {
                var suportedCulture = new List<CultureInfo>();
                if (languages.Count > 0)
                {
                    foreach (var lng in languages)
                        suportedCulture.Add(new CultureInfo(lng));
                }
                else
                    suportedCulture.Add(new CultureInfo("fa"));

                opt.SupportedCultures = suportedCulture;
                opt.SupportedUICultures = suportedCulture;
            });
        }
    }
}
