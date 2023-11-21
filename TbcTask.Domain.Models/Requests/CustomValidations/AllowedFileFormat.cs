using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TbcTask.Domain.Models.Resources;

namespace TbcTask.Domain.Models.Requests.CustomValidations
{
    public class AllowedFileFormat : ValidationAttribute
    {
        private readonly string[] allowedFormats;

        public AllowedFileFormat(params string[] formats)
        {
            allowedFormats = formats;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                string fileExtension = file.FileName.Split('.').LastOrDefault();

                if (!allowedFormats.Any(format => fileExtension.ToLower().Equals(format, StringComparison.OrdinalIgnoreCase)))
                {
                    return new ValidationResult(String.Format(ValidationMessages.AllowedFileFormat,string.Join(", ",allowedFormats)));
                }
            }

            return ValidationResult.Success;
        }
    }
}
