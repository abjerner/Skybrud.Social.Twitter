using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.Models.Statuses;

namespace Skybrud.Social.Twitter.Responses.Statuses {

    public class TwitterDestroyStatusMessageResponse : TwitterResponse<TwitterStatusMessage> {

        #region Constructors

        private TwitterDestroyStatusMessageResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, TwitterStatusMessage.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="TwitterDestroyStatusMessageResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="TwitterDestroyStatusMessageResponse"/> representing the response.</returns>
        public static TwitterDestroyStatusMessageResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new TwitterDestroyStatusMessageResponse(response);
        }

        #endregion

    }

}