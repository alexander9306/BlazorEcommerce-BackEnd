namespace Sistema.Web.Helpers.Validators
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using Microsoft.AspNetCore.Http;

    public sealed class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;

        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        public override string FormatErrorMessage(string name)
        {
            var fileSize = _maxFileSize / 1024 / 1024;
            var size = _maxFileSize > 1000000 ? $"{fileSize} MB" : $"{fileSize} B";

            return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, size);
        }

        public override bool IsValid(object value)
        {
            var file = value as IFormFile;

            return file == null || file.Length < _maxFileSize;
        }
    }
}
