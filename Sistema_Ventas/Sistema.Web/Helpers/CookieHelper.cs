namespace Sistema.Web.Helpers
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Http;

    public class CookieHelper
    {
        public CookieHelper(HttpResponse response, HttpRequest request, ClaimsPrincipal user)
        {
            this.response = response;
            this.request = request;
            this.user = user;
        }

        public ClaimsPrincipal user { get; }

        private HttpResponse response { get; set; }

        private HttpRequest request { get; set; }

        /// <summary>
        /// Set the cookie.
        /// </summary>
        /// <param name="key">key (unique indentifier).</param>
        /// <param name="value">value to store in cookie object.</param>
        /// <param name="expireTime">expiration time in minutes.</param>
        public void Set(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();

            if (expireTime.HasValue)
            {
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            }
            else
            {
                option.Expires = DateTime.Now.AddMilliseconds(10);
            }

            this.response.Cookies.Append(key, value, option);
        }

        /// <summary>
        /// Delete the key.
        /// </summary>
        /// <param name="key">Key.</param>
        public void Remove(string key)
        {
            this.response.Cookies.Delete(key);
        }

        /// <summary>
        /// Get the key.
        /// </summary>
        /// <param name="key">Key.</param>
        public string? Get(string key)
        {
            return this.request.Cookies[key];
        }

        /// <summary>
        /// Get User id from header-token.
        /// </summary>
        public int? GetUserId()
        {
            return int.Parse(this.user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
        }

        /// <summary>
        /// Get the Header of the key.
        /// </summary>
        /// <param name="key">Key.</param>
        public string? GetHeader(string key)
        {
            return this.request.Headers.FirstOrDefault(x => x.Key == key).Value.FirstOrDefault();
        }

    }
}
