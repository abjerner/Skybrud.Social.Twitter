using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.Models.Geocode;

namespace Skybrud.Social.Twitter.Responses.Geocode {

    /// <summary>
    /// Class representing the response of a request to the Twitter API for getting information about a Twitter place.
    /// </summary>
    public class TwitterPlaceResponse : TwitterResponse<TwitterPlace> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public TwitterPlaceResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, TwitterPlace.Parse);

        }

    }

}