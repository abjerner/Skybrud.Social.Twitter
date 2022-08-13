using Skybrud.Social.Twitter.Endpoints.Raw;
using Skybrud.Social.Twitter.Options;
using Skybrud.Social.Twitter.Responses;
using Skybrud.Social.Twitter.Responses.Users;

namespace Skybrud.Social.Twitter.Endpoints {

    /// <summary>
    /// Class representing the implementation of the <strong>Followers</strong> endpoint.
    /// </summary>
    public class TwitterFollowersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Twitter service.
        /// </summary>
        public TwitterHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw followers endpoint.
        /// </summary>
        public TwitterFollowersRawEndpoint Raw => Service.Client.Followers;

        #endregion

        #region Constructors

        internal TwitterFollowersEndpoint(TwitterHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of IDs representing the followers of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="TwitterIdsResponse"/> representing the response.</returns>
        public TwitterIdsResponse GetIds(long userId) {
            return TwitterIdsResponse.ParseResponse(Raw.GetIds(userId));
        }

        /// <summary>
        /// Gets a list of IDs representing the followers of the user with the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <returns>An instance of <see cref="TwitterIdsResponse"/> representing the response.</returns>
        public TwitterIdsResponse GetIds(string screenName) {
            return TwitterIdsResponse.ParseResponse(Raw.GetIds(screenName));
        }

        /// <summary>
        /// Gets a list of IDs representing the followers of the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="TwitterIdsResponse"/> representing the response.</returns>
        public TwitterIdsResponse GetIds(TwitterFollowersIdsOptions options) {
            return TwitterIdsResponse.ParseResponse(Raw.GetIds(options));
        }

        /// <summary>
        /// Gets a list of followers of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="TwitterGetUsersResponse"/> representing the response.</returns>
        public TwitterGetUsersResponse GetList(long userId) {
            return TwitterGetUsersResponse.ParseResponse(Raw.GetList(userId));
        }

        /// <summary>
        /// Gets a list of followers of the user with the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <returns>An instance of <see cref="TwitterGetUsersResponse"/> representing the response.</returns>
        public TwitterGetUsersResponse GetList(string screenName) {
            return TwitterGetUsersResponse.ParseResponse(Raw.GetList(screenName));
        }

        /// <summary>
        /// Gets a list of followers of the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="TwitterGetUsersResponse"/> representing the response.</returns>
        public TwitterGetUsersResponse GetList(TwitterFollowersListOptions options) {
            return TwitterGetUsersResponse.ParseResponse(Raw.GetList(options));
        }

        #endregion

    }

}