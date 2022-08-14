using Skybrud.Social.Twitter.Endpoints.Raw;
using Skybrud.Social.Twitter.Options.Favorites;
using Skybrud.Social.Twitter.Responses.Statuses;

namespace Skybrud.Social.Twitter.Endpoints {

    /// <summary>
    /// Class representing the implementation of the Implementation of the <strong>Favorites</strong> endpoint.
    /// </summary>
    public class TwitterFavoritesEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Twitter service.
        /// </summary>
        public TwitterHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw favorites endpoint.
        /// </summary>
        public TwitterFavoritesRawEndpoint Raw => Service.Client.Favotires;

        #endregion

        #region Constructors

        internal TwitterFavoritesEndpoint(TwitterHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of favorites of the authenticated user.
        /// </summary>
        public TwitterStatusListResponse GetFavorites() {
            return new TwitterStatusListResponse(Raw.GetFavorites());
        }

        /// <summary>
        /// Gets a list of favorites of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public TwitterStatusListResponse GetFavorites(long userId) {
            return new TwitterStatusListResponse(Raw.GetFavorites(userId));
        }

        /// <summary>
        /// Gets a list of favorites of the user with the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        public TwitterStatusListResponse GetFavorites(string screenName) {
            return new TwitterStatusListResponse(Raw.GetFavorites(screenName));
        }

        /// <summary>
        /// Gets a list of favorites based on the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public TwitterStatusListResponse GetFavorites(TwitterGetFavoritesOptions options) {
            return new TwitterStatusListResponse(Raw.GetFavorites(options));
        }

        /// <summary>
        /// Favorites the status message with the specified <paramref name="statusId"/> as the authenticating user.
        /// </summary>
        /// <param name="statusId">The ID of the status message.</param>
        public TwitterStatusResponse Create(long statusId) {
            return new TwitterStatusResponse(Raw.Create(statusId));
        }

        /// <summary>
        /// Un-favorites the status message with the specified <paramref name="statusId"/> as the authenticating user.
        /// </summary>
        /// <param name="statusId">The ID of the status message.</param>
        public TwitterStatusResponse Destroy(long statusId) {
            return new TwitterStatusResponse(Raw.Destroy(statusId));
        }

        #endregion

    }

}