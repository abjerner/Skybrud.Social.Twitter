using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.Models.Statuses;

namespace Skybrud.Social.Twitter.Responses.Statuses {

    public class TwitterPostStatusMessageResponse : TwitterResponse<TwitterStatusMessage> {

        #region Constructors

        private TwitterPostStatusMessageResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, TwitterStatusMessage.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="TwitterPostStatusMessageResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="TwitterPostStatusMessageResponse"/> representing the response.</returns>
        public static TwitterPostStatusMessageResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new TwitterPostStatusMessageResponse(response);
        }

        #endregion

    }

}