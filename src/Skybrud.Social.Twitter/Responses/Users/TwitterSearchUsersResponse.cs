using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.Models.Users;

namespace Skybrud.Social.Twitter.Responses.Users {

    /// <summary>
    /// Class representing the response of a request to the Twitter API for searching through Twitters users.
    /// </summary>
    public class TwitterSearchUsersResponse : TwitterResponse<TwitterUser[]> {

        #region Constructors

        private TwitterSearchUsersResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonArray(response.Body, TwitterUser.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="TwitterSearchUsersResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="TwitterSearchUsersResponse"/> representing the response.</returns>
        public static TwitterSearchUsersResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new TwitterSearchUsersResponse(response);
        }

        #endregion

    }

}