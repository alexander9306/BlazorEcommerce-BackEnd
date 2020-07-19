namespace Sistema.Web.Helpers.Validators
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using Microsoft.AspNetCore.Http;

    public sealed class AllowedExtensionsAttribute : ValidationAttribute
    {
        private string _extensions;

        public string Extensions
        {
            get => string.IsNullOrWhiteSpace(_extensions) ? "png,jpg,jpeg,gif" : _extensions;
            set => _extensions = value;
        }

        private string ExtensionsFormatted => ExtensionsParsed.Aggregate((left, right) => left + ", " + right);

        private string ExtensionsNormalized =>
            Extensions.Replace(" ", string.Empty, StringComparison.InvariantCulture).Replace(".", string.Empty, StringComparison.InvariantCulture).ToUpperInvariant();

        private IEnumerable<string> ExtensionsParsed
        {
            get { return ExtensionsNormalized.Split(',').Select(e => "." + e); }
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            var valueAsIFormFile = value as IFormFile;
            if (valueAsIFormFile != null)
            {
                return ValidateExtension(valueAsIFormFile.FileName);
            }

            var valueAsString = value as string;
            if (valueAsString != null)
            {
                return ValidateExtension(valueAsString);
            }

            return false;
        }

        private bool ValidateExtension(string fileName)
        {
            return ExtensionsParsed.Contains(Path.GetExtension(fileName).ToUpperInvariant());
        }
    }
}
