using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.OAuth;
using Skybrud.Social.Twitter.Options;

namespace Skybrud.Social.Twitter.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the <strong>Friends</strong> endpoint.
    /// </summary>
    public class TwitterFriendsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth 1.0a client.
        /// </summary>
        public TwitterOAuthClient Client { get; }

        #endregion

        #region Constructor

        internal TwitterFriendsRawEndpoint(TwitterOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a list of IDs representing the friends of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/friends/ids</cref>
        /// </see>
        public IHttpResponse GetIds(long userId) {
            return GetIds(new TwitterFriendsIdsOptions(userId));
        }

        /// <summary>
        /// Gets a list of IDs representing the friends of the user with the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/friends/ids</cref>
        /// </see>
        public IHttpResponse GetIds(string screenName) {
            return GetIds(new TwitterFriendsIdsOptions(screenName));
        }

        /// <summary>
        /// Gets a list of IDs representing the friends of the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/friends/ids</cref>
        /// </see>
        public IHttpResponse GetIds(TwitterFriendsIdsOptions options) {
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Gets a list of friends for a given user using the default options.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/friends/list</cref>
        /// </see>
        public IHttpResponse GetList(long userId) {
            return GetList(new TwitterFriendsListOptions(userId));
        }

        /// <summary>
        /// Gets a list of friends for a given user using the default options.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/friends/list</cref>
        /// </see>
        public IHttpResponse GetList(string screenName) {
            return GetList(new TwitterFriendsListOptions(screenName));
        }

        /// <summary>
        /// Gets a list of friends for a given user using the specified options.
        /// </summary>
        /// <param name="options">The options for the call.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/friends/list</cref>
        /// </see>
        public IHttpResponse GetList(TwitterFriendsListOptions options) {
            return Client.GetResponse(options);
        }

        #endregion

    }

}