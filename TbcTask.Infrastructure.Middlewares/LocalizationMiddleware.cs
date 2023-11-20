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

                // Set the culture for the current request
                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
            }


            // Call the next middleware in the pipeline
            await _next(context);
        }

        private static CultureInfo DetermineCulture(string langHeader)
        {
            // Implement logic to determine the culture based on the Accept-Language header
            // For simplicity, this example uses the first language in the header as the preferred language
            var preferredLanguage = langHeader?.Split(',').FirstOrDefault();
            var culture = preferredLanguage != null ? new CultureInfo(preferredLanguage) : CultureInfo.CurrentCulture;

            return culture;
        }
    }
}
