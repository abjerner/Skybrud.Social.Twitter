using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.Models.Statuses;

namespace Skybrud.Social.Twitter.Responses.Statuses {

    /// <summary>
    /// Class representing a response with a single <see cref="TwitterStatusMessage"/>.
    /// </summary>
    public class TwitterStatusResponse : TwitterResponse<TwitterStatusMessage> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public TwitterStatusResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, TwitterStatusMessage.Parse);

        }

    }

}