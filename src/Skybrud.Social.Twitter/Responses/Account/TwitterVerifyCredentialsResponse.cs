using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.Models.Account;

namespace Skybrud.Social.Twitter.Responses.Account {

    /// <summary>
    /// Class representing the response of a call to get information about the authenticated user
    /// </summary>
    public class TwitterVerifyCredentialsResponse : TwitterResponse<TwitterAccount> {

        #region Constructors

        private TwitterVerifyCredentialsResponse(IHttpResponse response) : base(response) {
            
            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, TwitterAccount.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="TwitterVerifyCredentialsResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="TwitterVerifyCredentialsResponse"/> representing the response.</returns>
        public static TwitterVerifyCredentialsResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new TwitterVerifyCredentialsResponse(response);
        }

        #endregion

    }

}