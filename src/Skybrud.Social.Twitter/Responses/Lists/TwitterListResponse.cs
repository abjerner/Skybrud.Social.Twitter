using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.Models.Lists;

namespace Skybrud.Social.Twitter.Responses.Lists {
    
    /// <summary>
    /// Class respresenting the response for a list.
    /// </summary>
    public class TwitterListResponse : TwitterResponse<TwitterList> {

        #region Constructors

        private TwitterListResponse(IHttpResponse response) : base(response) {
            
            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, TwitterList.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="TwitterListResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="TwitterListResponse"/> representing the response.</returns>
        public static TwitterListResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new TwitterListResponse(response);
        }

        #endregion

    }

}