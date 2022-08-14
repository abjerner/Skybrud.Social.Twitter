using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.Models.Search;

namespace Skybrud.Social.Twitter.Responses.Search {

    /// <summary>
    /// Class representing the response of a request to the Twitter API for searching through Twitter status messages (tweets).
    /// </summary>
    public class TwitterSearchTweetsResponse : TwitterResponse<TwitterSearchTweetsResult> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public TwitterSearchTweetsResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, TwitterSearchTweetsResult.Parse);

        }

    }

}