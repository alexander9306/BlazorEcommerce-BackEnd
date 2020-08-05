namespace Sistema.Shared.Helpers.Validators
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
<<<<<<< HEAD
    using System.IO;
=======
>>>>>>> origin/Reynaldo
    using Microsoft.AspNetCore.Http;

    public sealed class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;

        public MaxFileSizeAttribute(int maxFileSize)
        {
            this._maxFileSize = maxFileSize;
        }

        public override string FormatErrorMessage(string name)
        {
            var fileSize = this._maxFileSize / 1024 / 1024;
            var size = this._maxFileSize > 1000000 ? $"{fileSize} MB" : $"{fileSize} B";

            return string.Format(CultureInfo.InvariantCulture, this.ErrorMessageString, name, size);
        }

        public override bool IsValid(object value)
        {
<<<<<<< HEAD
            var file = value as FileStream;
=======
            var file = value as IFormFile;
>>>>>>> origin/Reynaldo

            return file == null || file.Length < this._maxFileSize;
        }
    }
}
