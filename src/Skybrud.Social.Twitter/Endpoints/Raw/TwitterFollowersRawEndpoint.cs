using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.OAuth;
using Skybrud.Social.Twitter.Options;

namespace Skybrud.Social.Twitter.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the <strong>Followers</strong> endpoint.
    /// </summary>
    public class TwitterFollowersRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth 1.0a client.
        /// </summary>
        public ITwitterOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal TwitterFollowersRawEndpoint(ITwitterOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Membmer methods

        /// <summary>
        /// Gets a list of IDs representing the followers of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/followers/ids</cref>
        /// </see>
        public IHttpResponse GetIds(long userId) {
            return GetIds(new TwitterFollowersIdsOptions(userId));
        }

        /// <summary>
        /// Gets a list of IDs representing the followers of the user with the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/followers/ids</cref>
        /// </see>
        public IHttpResponse GetIds(string screenName) {
            return GetIds(new TwitterFollowersIdsOptions(screenName));
        }

        /// <summary>
        /// Gets a list of IDs representing the followers of the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/followers/ids</cref>
        /// </see>
        public IHttpResponse GetIds(TwitterFollowersIdsOptions options) {
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Gets a list of followers of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/followers/list</cref>
        /// </see>
        public IHttpResponse GetList(long userId) {
            return GetList(new TwitterFollowersListOptions(userId));
        }

        /// <summary>
        /// Gets a list of followers of the user with the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/followers/list</cref>
        /// </see>
        public IHttpResponse GetList(string screenName) {
            return GetList(new TwitterFollowersListOptions(screenName));
        }

        /// <summary>
        /// Gets a list of followers of the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/followers/list</cref>
        /// </see>
        public IHttpResponse GetList(TwitterFollowersListOptions options) {
            return Client.GetResponse(options);
        }

        #endregion

    }

}