using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.Models.Users;

namespace Skybrud.Social.Twitter.Responses.Users {

    public class TwitterUserListResponse : TwitterResponse<TwitterUserCollection> {

        #region Constructors

        private TwitterUserListResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, TwitterUserCollection.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="TwitterUserListResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="TwitterUserListResponse"/> representing the response.</returns>
        public static TwitterUserListResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new TwitterUserListResponse(response);
        }

        #endregion

    }

}