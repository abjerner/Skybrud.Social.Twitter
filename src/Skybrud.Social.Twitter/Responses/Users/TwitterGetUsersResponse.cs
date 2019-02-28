using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.Models.Users;

namespace Skybrud.Social.Twitter.Responses.Users {

    /// <summary>
    /// Class representing the response of a request to the Twitter API for getting a collection of Twitter users.
    /// </summary>
    public class TwitterGetUsersResponse : TwitterResponse<TwitterUserCollection> {

        #region Constructors

        private TwitterGetUsersResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, TwitterUserCollection.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="TwitterGetUsersResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="TwitterGetUsersResponse"/> representing the response.</returns>
        public static TwitterGetUsersResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new TwitterGetUsersResponse(response);
        }

        #endregion

    }

}