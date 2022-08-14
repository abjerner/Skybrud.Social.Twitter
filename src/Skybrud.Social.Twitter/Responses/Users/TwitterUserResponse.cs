using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.Models.Users;

namespace Skybrud.Social.Twitter.Responses.Users {

    /// <summary>
    /// Class representing the response of a request to the Twitter API for getting information about a Twitter user.
    /// </summary>
    public class TwitterUserResponse : TwitterResponse<TwitterUser> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public TwitterUserResponse(IHttpResponse response) : base(response) {
            
            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, TwitterUser.Parse);

        }

    }

}