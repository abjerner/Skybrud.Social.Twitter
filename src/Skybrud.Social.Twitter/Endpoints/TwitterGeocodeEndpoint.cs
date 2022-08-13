using Skybrud.Social.Twitter.Endpoints.Raw;
using Skybrud.Social.Twitter.Options.Geocode;
using Skybrud.Social.Twitter.Responses.Geocode;

namespace Skybrud.Social.Twitter.Endpoints {

    /// <summary>
    /// Class representing the implementation of the <strong>Geocode</strong> endpoint.
    /// </summary>
    public class TwitterGeocodeEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Twitter service.
        /// </summary>
        public TwitterHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public TwitterGeocodeRawEndpoint Raw => Service.Client.Geocode;

        #endregion

        #region Constructors

        internal TwitterGeocodeEndpoint(TwitterHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the place with the specified <paramref name="placeId"/>.
        /// </summary>
        /// <param name="placeId">The ID of the place.</param>
        /// <returns>An instance of <see cref="TwitterGetPlaceResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/geo/place-information/api-reference/get-geo-id-place_id</cref>
        /// </see>
        public TwitterGetPlaceResponse GetPlace(string placeId) {
            return TwitterGetPlaceResponse.ParseResponse(Raw.GetPlace(placeId));
        }

        /// <summary>
        /// Given a <paramref name="latitude"/> and a <paramref name="longitude"/>, searches for up to 20 places that
        /// can be used as a <c>place_id</c> when updating a status. This request is an informative call
        /// and will deliver generalized results about geography.
        /// </summary>
        /// <param name="latitude">The latitude to search around. This parameter will be ignored
        /// unless it is inside the range -90.0 to +90.0 (North is positive) inclusive. It will
        /// also be ignored if there isn't a corresponding <paramref name="longitude"/> parameter.</param>
        /// <param name="longitude">The longitude to search around. The valid ranges for longitude
        /// is -180.0 to +180.0 (East is positive) inclusive. This parameter will be ignored if
        /// outside that range, if it is not a number, if <code>geo_enabled</code> is disabled, or
        /// if there not a corresponding <paramref name="latitude"/> parameter.</param>
        /// <returns>An instance of <see cref="TwitterReverseGeocodeResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/geo/places-near-location/api-reference/get-geo-reverse_geocode</cref>
        /// </see>
        public TwitterReverseGeocodeResponse ReverseGeocode(double latitude, double longitude) {
            return TwitterReverseGeocodeResponse.ParseResponse(Raw.ReverseGeocode(latitude, longitude));
        }

        /// <summary>
        /// Given a latitude and a longitude, searches for up to 20 places that can be used as
        /// a <c>place_id</c> when updating a status. This request is an informative call
        /// and will deliver generalized results about geography.
        /// </summary>
        /// <param name="options">The options used when making the call to the API.</param>
        /// <returns>An instance of <see cref="TwitterReverseGeocodeResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/geo/places-near-location/api-reference/get-geo-reverse_geocode</cref>
        /// </see>
        public TwitterReverseGeocodeResponse ReverseGeocode(TwitterReverseGeocodeOptions options) {
            return TwitterReverseGeocodeResponse.ParseResponse(Raw.ReverseGeocode(options));
        }

        #endregion

    }

}