using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.Models.Geocode;

namespace Skybrud.Social.Twitter.Responses.Geocode {

    /// <summary>
    /// Class representing the response of a request to the Twitter API for doing a reverse geocode search.
    /// </summary>
    public class TwitterReverseGeocodeResponse : TwitterResponse<TwitterReverseGeocode> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public TwitterReverseGeocodeResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, TwitterReverseGeocode.Parse);

        }

    }

}