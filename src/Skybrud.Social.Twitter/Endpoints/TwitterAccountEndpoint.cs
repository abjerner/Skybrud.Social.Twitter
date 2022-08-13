using Skybrud.Social.Twitter.Endpoints.Raw;
using Skybrud.Social.Twitter.Options.Account;
using Skybrud.Social.Twitter.Responses.Account;

namespace Skybrud.Social.Twitter.Endpoints {

    /// <summary>
    /// Implementation of the <strong>Account</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://dev.twitter.com/rest/reference/get/account/settings</cref>
    /// </see>
    /// <see>
    ///     <cref>https://dev.twitter.com/rest/reference/get/account/verify_credentials</cref>
    /// </see>
    public class TwitterAccountEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Twitter service.
        /// </summary>
        public TwitterHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public TwitterAccountRawEndpoint Raw => Service.Client.Account;

        #endregion

        #region Constructors

        internal TwitterAccountEndpoint(TwitterHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a represenation of the authenticated user (requires an access token).
        /// </summary>
        /// <returns>An instance of <see cref="TwitterVerifyCredentialsResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/account/verify_credentials</cref>
        /// </see>
        public TwitterVerifyCredentialsResponse VerifyCredentials() {
            return TwitterVerifyCredentialsResponse.ParseResponse(Raw.VerifyCredentials());
        }

        /// <summary>
        /// Gets a represenation of the authenticated user (requires an access token).
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="TwitterVerifyCredentialsResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/account/verify_credentials</cref>
        /// </see>
        public TwitterVerifyCredentialsResponse VerifyCredentials(TwitterVerifyCrendetialsOptions options) {
            return TwitterVerifyCredentialsResponse.ParseResponse(Raw.VerifyCredentials(options));
        }

        #endregion

    }

}