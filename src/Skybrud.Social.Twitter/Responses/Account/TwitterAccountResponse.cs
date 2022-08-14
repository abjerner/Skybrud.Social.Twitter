using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.Models.Account;

namespace Skybrud.Social.Twitter.Responses.Account {

    /// <summary>
    /// Class representing the response of a call to get information about the authenticated user
    /// </summary>
    public class TwitterAccountResponse : TwitterResponse<TwitterAccount> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public TwitterAccountResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, TwitterAccount.Parse);

        }

    }

}