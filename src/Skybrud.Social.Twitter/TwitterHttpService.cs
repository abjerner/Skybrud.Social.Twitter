using System;
using Skybrud.Social.Twitter.Endpoints;
using Skybrud.Social.Twitter.OAuth;

namespace Skybrud.Social.Twitter {

    /// <summary>
    /// Class working as an entry point to the Twitter API.
    /// </summary>
    public class TwitterHttpService {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying OAuth client.
        /// </summary>
        public TwitterOAuthClient Client { get; }

        /// <summary>
        /// Gets a reference to the Account endpoint.
        /// </summary>
        public TwitterAccountEndpoint Account { get; }

        /// <summary>
        /// Gets a reference to the Favorites endpoint.
        /// </summary>
        public TwitterFavoritesEndpoint Favorites { get; }

        /// <summary>
        /// Gets a reference to the Followers endpoint.
        /// </summary>
        public TwitterFollowersEndpoint Followers { get; }

        /// <summary>
        /// Gets a reference to the Friends endpoint.
        /// </summary>
        public TwitterFriendsEndpoint Friends { get; }

        /// <summary>
        /// Gets a reference to the Geo endpoint.
        /// </summary>
        public TwitterGeocodeEndpoint Geocode { get; }

        /// <summary>
        /// Gets a reference to the Lists endpoint.
        /// </summary>
        public TwitterListsEndpoint Lists { get; }

        /// <summary>
        /// Gets a reference to the Search endpoint.
        /// </summary>
        public TwitterSearchEndpoint Search { get; }

        /// <summary>
        /// Gets a reference to the Statuses endpoint.
        /// </summary>
        public TwitterStatusesEndpoint Statuses { get; }

        /// <summary>
        /// Gets a reference to the Users endpoint.
        /// </summary>
        public TwitterUsersEndpoint Users { get; }

        #endregion

        #region Constructors

        private TwitterHttpService(TwitterOAuthClient client) {

            // Set the client
            Client = client;

            // Set the endpoints etc.
            Account = new TwitterAccountEndpoint(this);
            Favorites = new TwitterFavoritesEndpoint(this);
            Followers = new TwitterFollowersEndpoint(this);
            Friends = new TwitterFriendsEndpoint(this);
            Geocode = new TwitterGeocodeEndpoint(this);
            Lists = new TwitterListsEndpoint(this);
            Search = new TwitterSearchEndpoint(this);
            Statuses = new TwitterStatusesEndpoint(this);
            Users = new TwitterUsersEndpoint(this);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initializes a new instance from the specified <see cref="TwitterOAuthClient"/>.
        /// </summary>
        /// <param name="client">An instance of <see cref="TwitterOAuthClient"/>.</param>
        /// <returns>A new instance of <see cref="TwitterHttpService"/>.</returns>
        public static TwitterHttpService CreateFromOAuthClient(TwitterOAuthClient client) {
            if (client == null) throw new ArgumentNullException(nameof(client));
            return new TwitterHttpService(client);
        }

        #endregion

    }

}