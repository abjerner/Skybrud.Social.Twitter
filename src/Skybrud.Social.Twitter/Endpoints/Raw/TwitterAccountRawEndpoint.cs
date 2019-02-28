using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.OAuth;
using Skybrud.Social.Twitter.Options.Account;

namespace Skybrud.Social.Twitter.Endpoints.Raw {
    
    /// <summary>
    /// Class representing the raw implementation of the <strong>Account</strong> endpoint.
    /// </summary>
    public class TwitterAccountRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth 1.0a client.
        /// </summary>
        public TwitterOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal TwitterAccountRawEndpoint(TwitterOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a represenation of the authenticated user (requires an access token).
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/account/verify_credentials</cref>
        /// </see>
        public IHttpResponse VerifyCredentials() {
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/account/verify_credentials.json");
        }

        /// <summary>
        /// Gets a represenation of the authenticated user (requires an access token).
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/account/verify_credentials</cref>
        /// </see>
        public IHttpResponse VerifyCredentials(TwitterVerifyCrendetialsOptions options) {
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/account/verify_credentials.json", options);
        }

        #endregion

    }

}