namespace Sistema.Shared.Helpers.General
{
    using System;

    public class FileSizeFormatter : IFileSizeFormatter
    {
        private readonly string[] Suffixes =
            {
                "Bytes", "KB", "MB", "GB", "TB", "PB",
            };

        public string FormatSize(long? bytes)
        {
            if (!bytes.HasValue)
            {
                return $"0{Suffixes[0]}";
            }

            var counter = 0;
            var number = (decimal)bytes;
            while (Math.Round(number / 1024) >= 1)
            {
                number /= 1024;
                counter++;
            }

            return $"{number:n1}{Suffixes[counter]}";
        }
    }
}
