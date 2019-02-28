using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.Models.Lists;

namespace Skybrud.Social.Twitter.Responses.Lists {
    
    /// <summary>
    /// Class respresenting the response for removing a member from a list.
    /// </summary>
    public class TwitterRemoveMemberResponse : TwitterResponse<TwitterList> {

        #region Constructors

        private TwitterRemoveMemberResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, TwitterList.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="TwitterRemoveMemberResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="TwitterRemoveMemberResponse"/> representing the response.</returns>
        public static TwitterRemoveMemberResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new TwitterRemoveMemberResponse(response);
        }

        #endregion

    }

}