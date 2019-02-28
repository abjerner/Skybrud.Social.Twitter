using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.Models.Statuses;

namespace Skybrud.Social.Twitter.Responses.Statuses {

    public class TwitterGetStatusMessageResponse : TwitterResponse<TwitterStatusMessage> {

        #region Constructors

        private TwitterGetStatusMessageResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);
            
            // Initialize the response object
            Body = ParseJsonObject(response.Body, TwitterStatusMessage.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="TwitterGetStatusMessageResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="TwitterGetStatusMessageResponse"/> representing the response.</returns>
        public static TwitterGetStatusMessageResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new TwitterGetStatusMessageResponse(response);
        }

        #endregion

    }

}