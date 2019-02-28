using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.Twitter.OAuth;
using Skybrud.Social.Twitter.Options.Favorites;

namespace Skybrud.Social.Twitter.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the favorites endpoint.
    /// </summary>
    public class TwitterFavoritesRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth 1.0a client.
        /// </summary>
        public TwitterOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal TwitterFavoritesRawEndpoint(TwitterOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of favorites of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/favorites/list</cref>
        /// </see>
        public IHttpResponse GetFavorites() {
            return GetFavorites(default(TwitterGetFavoritesOptions));
        }

        /// <summary>
        /// Gets a list of favorites of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/favorites/list</cref>
        /// </see>
        public IHttpResponse GetFavorites(long userId) {
            return GetFavorites(new TwitterGetFavoritesOptions(userId));
        }

        /// <summary>
        /// Gets a list of favorites of the user with the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/favorites/list</cref>
        /// </see>
        public IHttpResponse GetFavorites(string screenName) {
            return GetFavorites(new TwitterGetFavoritesOptions(screenName));
        }

        /// <summary>
        /// Gets a list of favorites based on the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/favorites/list</cref>
        /// </see>
        public IHttpResponse GetFavorites(TwitterGetFavoritesOptions options) {
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/favorites/list.json", options);
        }

        /// <summary>
        /// Favorites the status message with the specified <paramref name="statusId"/> as the authenticating user.
        /// </summary>
        /// <param name="statusId">The ID of the status message.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/post/favorites/create</cref>
        /// </see>
        public IHttpResponse Create(long statusId) {

            // Declare the query string
            IHttpQueryString query = new HttpQueryString();
            query.Set("id", statusId);

            // Make the call to the API
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/favorites/create.json", query);

        }

        /// <summary>
        /// Un-favorites the status message with the specified <paramref name="statusId"/> as the authenticating user.
        /// </summary>
        /// <param name="statusId">The ID of the status message.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/post/favorites/destroy</cref>
        /// </see>
        public IHttpResponse Destroy(long statusId) {

            // Declare the query string
            IHttpQueryString query = new HttpQueryString();
            query.Set("id", statusId);

            // Make the call to the API
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/favorites/destroy.json", query);

        }

        #endregion

    }

}