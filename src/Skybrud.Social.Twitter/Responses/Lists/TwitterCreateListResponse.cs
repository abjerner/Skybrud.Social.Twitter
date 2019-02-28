using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.Models.Lists;

namespace Skybrud.Social.Twitter.Responses.Lists {
    
    /// <summary>
    /// Class respresenting the response for a created list.
    /// </summary>
    public class TwitterCreateListResponse : TwitterResponse<TwitterList> {

        #region Constructors

        private TwitterCreateListResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, TwitterList.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="TwitterCreateListResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="TwitterCreateListResponse"/> representing the response.</returns>
        public static TwitterCreateListResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new TwitterCreateListResponse(response);
        }

        #endregion

    }

}