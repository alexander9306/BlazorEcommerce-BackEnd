namespace Sistema.Shared.Helpers.Validators
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
            get => string.IsNullOrWhiteSpace(this._extensions) ? "png,jpg,jpeg,gif" : this._extensions;
            set => this._extensions = value;
        }

        private string ExtensionsFormatted => this.ExtensionsParsed.Aggregate((left, right) => left + ", " + right);

        private string ExtensionsNormalized =>
            this.Extensions.Replace(" ", string.Empty, StringComparison.InvariantCulture).Replace(".", string.Empty, StringComparison.InvariantCulture).ToUpperInvariant();

        private IEnumerable<string> ExtensionsParsed
        {
            get { return this.ExtensionsNormalized.Split(',').Select(e => "." + e); }
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            var valueAsFileStream = value as FileStream;
            if (valueAsFileStream != null)
            {
                return this.ValidateExtension(valueAsFileStream.Name);
            }


            var valueAsIFormFile = value as IFormFile;
            if (valueAsIFormFile != null)
            {
                return this.ValidateExtension(valueAsIFormFile.FileName);
            }

            var valueAsString = value as string;
            if (valueAsString != null)
            {
                return this.ValidateExtension(valueAsString);
            }

            return false;
        }

        private bool ValidateExtension(string fileName)
        {
            return this.ExtensionsParsed.Contains(Path.GetExtension(fileName).ToUpperInvariant());
        }
    }
}
