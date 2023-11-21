using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TbcTask.Infrastructure.Middlewares
{
    public class LocalizationMiddleware
    {
        private readonly RequestDelegate _next;

        public LocalizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var langHeader = context.Request.Headers["Accept-Language"].FirstOrDefault();
            if (langHeader!=null)
            {
                var culture = DetermineCulture(langHeader);

                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
            }
            await _next(context);
        }

        private static CultureInfo DetermineCulture(string langHeader)
        {
            var preferredLanguage = langHeader?.Split(',').FirstOrDefault();
            var culture = preferredLanguage != null ? new CultureInfo(preferredLanguage) : CultureInfo.CurrentCulture;

            return culture;
        }
    }
}
