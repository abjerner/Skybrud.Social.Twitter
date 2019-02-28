using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.Models.Geocode;

namespace Skybrud.Social.Twitter.Responses.Geocode {

    /// <summary>
    /// Class representing the response of a request to the Twitter API for getting information about a Twitter place.
    /// </summary>
    public class TwitterGetPlaceResponse : TwitterResponse<TwitterPlace> {

        #region Constructors

        private TwitterGetPlaceResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, TwitterPlace.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="TwitterGetPlaceResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="TwitterGetPlaceResponse"/> representing the response.</returns>
        public static TwitterGetPlaceResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new TwitterGetPlaceResponse(response);
        }

        #endregion

    }

}