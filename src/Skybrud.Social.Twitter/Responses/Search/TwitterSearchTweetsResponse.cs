using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.Models.Search;

namespace Skybrud.Social.Twitter.Responses.Search {

    /// <summary>
    /// Class representing the response of a request to the Twitter API for searching through Twitter status messages (tweets).
    /// </summary>
    public class TwitterSearchTweetsResponse : TwitterResponse<TwitterSearchTweetsResults> {

        #region Constructors

        private TwitterSearchTweetsResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, TwitterSearchTweetsResults.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="TwitterSearchTweetsResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="TwitterSearchTweetsResponse"/> representing the response.</returns>
        public static TwitterSearchTweetsResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new TwitterSearchTweetsResponse(response);
        }

        #endregion

    }

}