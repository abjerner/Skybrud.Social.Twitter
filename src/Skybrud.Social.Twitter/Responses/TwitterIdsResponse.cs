using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.Models;

namespace Skybrud.Social.Twitter.Responses {

    public class TwitterIdsResponse : TwitterResponse<TwitterIdsCollection> {

        #region Constructors

        private TwitterIdsResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, TwitterIdsCollection.Parse);

        }

        #endregion

        #region Static methods

        public static TwitterIdsResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new TwitterIdsResponse(response);
        }

        #endregion

    }

}