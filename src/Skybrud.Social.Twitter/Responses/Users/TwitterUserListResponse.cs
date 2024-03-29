using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.Models.Users;

namespace Skybrud.Social.Twitter.Responses.Users {

    /// <summary>
    /// Class representing a response with a list of Twitter users.
    /// </summary>
    public class TwitterUserListResponse : TwitterResponse<TwitterUserCollection> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public TwitterUserListResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, TwitterUserCollection.Parse);

        }

    }

}