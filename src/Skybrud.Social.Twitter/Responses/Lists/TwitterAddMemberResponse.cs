using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.Models.Lists;

namespace Skybrud.Social.Twitter.Responses.Lists {

    /// <summary>
    /// Class respresenting the response for adding a member to a list.
    /// </summary>
    public class TwitterAddMemberResponse : TwitterResponse<TwitterList> {

        #region Constructors

        private TwitterAddMemberResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, TwitterList.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="TwitterAddMemberResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="TwitterAddMemberResponse"/> representing the response.</returns>
        public static TwitterAddMemberResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new TwitterAddMemberResponse(response);
        }

        #endregion

    }

}