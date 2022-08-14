using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.Models;

namespace Skybrud.Social.Twitter.Responses {

    /// <summary>
    /// Class representing a response with a <see cref="TwitterIdList"/>.
    /// </summary>
    public class TwitterIdListResponse : TwitterResponse<TwitterIdList> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public TwitterIdListResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, TwitterIdList.Parse);

        }

    }

}