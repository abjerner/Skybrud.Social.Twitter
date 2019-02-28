using System;
using Skybrud.Essentials.Time;
using Skybrud.Essentials.Http;

namespace Skybrud.Social.Twitter.Models.Common {

    /// <summary>
    /// Class with rate-limiting information about a response from the Twitter API.
    /// </summary>
    public class TwitterRateLimiting {

        #region Properties

        /// <summary>
        /// Gets the total number of calls allowed within the current window.
        /// </summary>
        public int Limit { get; }

        /// <summary>
        /// Gets the remaining number of calls available to your app within the current window.
        /// </summary>
        public int Remaining { get; }

        /// <summary>
        /// Gets the timestamp for when the current window will be reset.
        /// </summary>
        public EssentialsDateTime Reset { get; }

        #endregion

        #region Constructors

        private TwitterRateLimiting(int limit, int remaining, int reset) {
            Limit = limit;
            Remaining = remaining;
            Reset = TimeUtils.GetDateTimeFromUnixTime(reset);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets rate limiting information from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>An instance of <see cref="TwitterRateLimiting"/>.</returns>
        public static TwitterRateLimiting GetFromResponse(IHttpResponse response) {

            int limit;
            int remaining;
            int reset;

            if (!Int32.TryParse(response.Headers["x-rate-limit-limit"] ?? "", out limit)) {
                limit = -1;
            }

            if (!Int32.TryParse(response.Headers["x-rate-limit-remaining"] ?? "", out remaining)) {
                remaining = -1;
            }

            if (!Int32.TryParse(response.Headers["x-rate-limit-reset"] ?? "", out reset)) {
                reset = 0;
            }

            return new TwitterRateLimiting(limit, remaining, reset);

        }

        #endregion

    }

}