using Skybrud.Social.Twitter.Endpoints.Raw;
using Skybrud.Social.Twitter.Models.Statuses;
using Skybrud.Social.Twitter.Options.Statuses;
using Skybrud.Social.Twitter.Responses.Statuses;

namespace Skybrud.Social.Twitter.Endpoints {

    /// <summary>
    /// Class representing the implementation of the <strong>Statuses</strong> endpoint.
    /// </summary>
    public class TwitterStatusesEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Twitter service.
        /// </summary>
        public TwitterHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public TwitterStatusesRawEndpoint Raw => Service.Client.Statuses;

        #endregion

        #region Constructors

        internal TwitterStatusesEndpoint(TwitterHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        #region GetStatusMessage(...)

        /// <summary>
        /// Gets information about the status message (tweet) with the <paramref name="statusId"/>.
        /// </summary>
        /// <param name="statusId">The ID of the status message.</param>
        /// <returns>An instance of <see cref="TwitterStatusResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/get-statuses-show-id</cref>
        /// </see>
        public TwitterStatusResponse GetStatusMessage(long statusId) {
            return new TwitterStatusResponse(Raw.GetStatusMessage(statusId));
        }

        /// <summary>
        /// Gets the raw API response for a status message (tweet) matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options used when making the call to the API.</param>
        /// <returns>An instance of <see cref="TwitterStatusResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/get-statuses-show-id</cref>
        /// </see>
        public TwitterStatusResponse GetStatusMessage(TwitterGetStatusMessageOptions options) {
            return new TwitterStatusResponse(Raw.GetStatusMessage(options));
        }

        #endregion

        #region PostStatusMessage(...)

        /// <summary>
        /// Posts the specified status message.
        /// </summary>
        /// <param name="status">The status message to send.</param>
        /// <returns>An instance of <see cref="TwitterStatusListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/post-statuses-update</cref>
        /// </see>
        public TwitterStatusListResponse PostStatusMessage(string status) {
            return new TwitterStatusListResponse(Raw.PostStatusMessage(status));
        }

        /// <summary>
        /// Posts the specified status message.
        /// </summary>
        /// <param name="status">The status message to send.</param>
        /// <param name="replyTo">The ID of the status message to reply to.</param>
        /// <returns>An instance of <see cref="TwitterStatusListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/post-statuses-update</cref>
        /// </see>
        public TwitterStatusListResponse PostStatusMessage(string status, long replyTo) {
            return new TwitterStatusListResponse(Raw.PostStatusMessage(status, replyTo));
        }

        /// <summary>
        /// Posts a new status message (tweet) with the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="TwitterStatusListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/post-statuses-update</cref>
        /// </see>
        public TwitterStatusListResponse PostStatusMessage(TwitterPostStatusMessageOptions options) {
            return new TwitterStatusListResponse(Raw.PostStatusMessage(options));
        }

        #endregion

        #region GetUserTimeline(...)

        /// <summary>
        /// Gets the timeline of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="TwitterStatusListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-user_timeline</cref>
        /// </see>
        public TwitterStatusListResponse GetUserTimeline(long userId) {
            return new TwitterStatusListResponse(Raw.GetUserTimeline(userId));
        }

        /// <summary>
        /// Gets the timeline of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">The maximum amount of tweets to return.</param>
        /// <returns>An instance of <see cref="TwitterStatusListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-user_timeline</cref>
        /// </see>
        public TwitterStatusListResponse GetUserTimeline(long userId, int count) {
            return new TwitterStatusListResponse(Raw.GetUserTimeline(userId, count));
        }

        /// <summary>
        /// Gets the timeline of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">The maximum amount of tweets to return.</param>
        /// <param name="maxId">The maximum status message ID. Only status message with an ID less then (that is, older
        /// than) this ID will be returned.</param>
        /// <returns>An instance of <see cref="TwitterStatusListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-user_timeline</cref>
        /// </see>
        public TwitterStatusListResponse GetUserTimeline(long userId, int count, long maxId) {
            return new TwitterStatusListResponse(Raw.GetUserTimeline(userId, count, maxId));
        }

        /// <summary>
        /// Gets the timeline of the user with the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <returns>An instance of <see cref="TwitterStatusListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-user_timeline</cref>
        /// </see>
        public TwitterStatusListResponse GetUserTimeline(string screenName) {
            return new TwitterStatusListResponse(Raw.GetUserTimeline(screenName));
        }

        /// <summary>
        /// Gets the timeline of the user with the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <param name="count">The maximum amount of tweets to return.</param>
        /// <returns>An instance of <see cref="TwitterStatusListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-user_timeline</cref>
        /// </see>
        public TwitterStatusListResponse GetUserTimeline(string screenName, int count) {
            return new TwitterStatusListResponse(Raw.GetUserTimeline(screenName, count));
        }

        /// <summary>
        /// Gets the timeline of the user with the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <param name="count">The maximum amount of tweets to return.</param>
        /// <param name="maxId">The maximum status message ID. Only status message with an ID less then (that is, older
        /// than) this ID will be returned.</param>
        /// <returns>An instance of <see cref="TwitterStatusListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-user_timeline</cref>
        /// </see>
        public TwitterStatusListResponse GetUserTimeline(string screenName, int count, long maxId) {
            return new TwitterStatusListResponse(Raw.GetUserTimeline(screenName, count, maxId));
        }

        /// <summary>
        /// Get the raw API response for a user's timeline.
        /// </summary>
        /// <param name="options">The options used when making the call to the API.</param>
        /// <returns>An instance of <see cref="TwitterStatusListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-user_timeline</cref>
        /// </see>
        public TwitterStatusListResponse GetUserTimeline(TwitterGetUserTimelineOptions options) {
            return new TwitterStatusListResponse(Raw.GetUserTimeline(options));
        }

        #endregion

        #region GetHomeTimeline(...)

        /// <summary>
        /// Gets a collection of the most recent tweets and retweets posted by the authenticating
        /// user and the users they follow.
        /// </summary>
        /// <returns>An instance of <see cref="TwitterStatusListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-home_timeline</cref>
        /// </see>
        public TwitterStatusListResponse GetHomeTimeline() {
            return new TwitterStatusListResponse(Raw.GetHomeTimeline());
        }

        /// <summary>
        /// Gets a collection of the most recent tweets and retweets posted by the authenticating
        /// user and the users they follow.
        /// </summary>
        /// <returns>An instance of <see cref="TwitterStatusListResponse"/> representing the response.</returns>
        /// <param name="count">The maximum amount of tweets to return.</param>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-home_timeline</cref>
        /// </see>
        public TwitterStatusListResponse GetHomeTimeline(int count) {
            return new TwitterStatusListResponse(Raw.GetHomeTimeline(count));
        }

        /// <summary>
        /// Gets a collection of the most recent tweets and retweets posted by the authenticating
        /// user and the users they follow.
        /// </summary>
        /// <param name="options">The options for the call.</param>
        /// <returns>An instance of <see cref="TwitterStatusListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-home_timeline</cref>
        /// </see>
        public TwitterStatusListResponse GetHomeTimeline(TwitterGetHomeTimelineOptions options) {
            return new TwitterStatusListResponse(Raw.GetHomeTimeline(options));
        }

        #endregion

        #region GetMentionsTimeline(...)

        /// <summary>
        /// Gets the most recent mentions (tweets containing the users's @screen_name) for the authenticating user.
        /// </summary>
        /// <returns>An instance of <see cref="TwitterStatusListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-mentions_timeline</cref>
        /// </see>
        public TwitterStatusListResponse GetMentionsTimeline() {
            return new TwitterStatusListResponse(Raw.GetMentionsTimeline());
        }

        /// <summary>
        /// Gets the most recent mentions (tweets containing the users's @screen_name) for the authenticating user.
        /// </summary>
        /// <param name="count">The maximum amount of tweets to return.</param>
        /// <returns>An instance of <see cref="TwitterStatusListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-mentions_timeline</cref>
        /// </see>
        public TwitterStatusListResponse GetMentionsTimeline(int count) {
            return new TwitterStatusListResponse(Raw.GetMentionsTimeline(count));
        }

        /// <summary>
        /// Gets the most recent mentions (tweets containing the users's @screen_name) for the authenticating user.
        /// </summary>
        /// <param name="options">The options for the call.</param>
        /// <returns>An instance of <see cref="TwitterStatusListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-mentions_timeline</cref>
        /// </see>
        public TwitterStatusListResponse GetMentionsTimeline(TwitterGetMentionsTimelineOptions options) {
            return new TwitterStatusListResponse(Raw.GetMentionsTimeline(options));
        }

        #endregion

        #region GetRetweetsOfMe(...)

        /// <summary>
        /// Gets a list of the most recent tweets authored by the authenticating user that have been retweeted by others.
        /// </summary>
        /// <returns>An instance of <see cref="TwitterStatusListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/get-statuses-retweets_of_me</cref>
        /// </see>
        public TwitterStatusListResponse GetRetweetsOfMe() {
            return new TwitterStatusListResponse(Raw.GetRetweetsOfMe());
        }

        /// <summary>
        /// Gets a list of the most recent tweets authored by the authenticating user that have been retweeted by others.
        /// </summary>
        /// <param name="count">The maximum amount of tweets to return.</param>
        /// <returns>An instance of <see cref="TwitterStatusListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/get-statuses-retweets_of_me</cref>
        /// </see>
        public TwitterStatusListResponse GetRetweetsOfMe(int count) {
            return new TwitterStatusListResponse(Raw.GetRetweetsOfMe(count));
        }

        /// <summary>
        /// Gets a list of the most recent tweets authored by the authenticating user that have been retweeted by others.
        /// </summary>
        /// <param name="options">The options for the call.</param>
        /// <returns>An instance of <see cref="TwitterStatusListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/get-statuses-retweets_of_me</cref>
        /// </see>
        public TwitterStatusListResponse GetRetweetsOfMe(TwitterGetRetweetsOfMeTimelineOptions options) {
            return new TwitterStatusListResponse(Raw.GetRetweetsOfMe(options));
        }

        #endregion

        #region RetweetStatusMessage(...)

        /// <summary>
        /// Retweets the status message with the specified <paramref name="statusId"/>.
        /// </summary>
        /// <param name="statusId">The ID of the status message to be retweeted.</param>
        /// <returns>An instance of <see cref="TwitterStatusListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/post-statuses-retweet-id</cref>
        /// </see>
        public TwitterStatusListResponse RetweetStatusMessage(long statusId) {
            return new TwitterStatusListResponse(Raw.RetweetStatusMessage(statusId));
        }

        /// <summary>
        /// Retweets the status message with the specified <paramref name="statusId"/>.
        /// </summary>
        /// <param name="statusId">The ID of the status message to be retweeted.</param>
        /// <param name="trimUser">When set to <c>true</c>, each tweet returned in a timeline will include a user
        /// object including only the status authors numerical ID. Omit this parameter to receive the complete user
        /// object.</param>
        /// <returns>An instance of <see cref="TwitterStatusListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/post-statuses-retweet-id</cref>
        /// </see>
        public TwitterStatusListResponse RetweetStatusMessage(long statusId, bool trimUser) {
            return new TwitterStatusListResponse(Raw.RetweetStatusMessage(statusId, trimUser));
        }

        /// <summary>
        /// Retweets the specified <paramref name="statusMessage"/>.
        /// </summary>
        /// <param name="statusMessage">The status message to be retweeted.</param>
        /// <returns>An instance of <see cref="TwitterStatusListResponse"/> representing the response.</returns>
        public TwitterStatusListResponse RetweetStatusMessage(TwitterStatusMessage statusMessage) {
            return new TwitterStatusListResponse(Raw.RetweetStatusMessage(statusMessage));
        }

        /// <summary>
        /// Retweets the specified <paramref name="statusMessage"/>.
        /// </summary>
        /// <param name="statusMessage">The status message to be retweeted.</param>
        /// <param name="trimUser">When set to <c>true</c>, each tweet returned in a timeline will include a user
        /// object including only the status authors numerical ID. Omit this parameter to receive the complete user
        /// object.</param>
        /// <returns>An instance of <see cref="TwitterStatusListResponse"/> representing the response.</returns>
        public TwitterStatusListResponse RetweetStatusMessage(TwitterStatusMessage statusMessage, bool trimUser) {
            return new TwitterStatusListResponse(Raw.RetweetStatusMessage(statusMessage, trimUser));
        }

        #endregion

        #region DestroyStatusMessage(...)

        /// <summary>
        /// Destroys the status message with the specified <paramref name="statusId"/>. The authenticating user must be
        /// the author of the specified status message. Returns the destroyed status message if successful.
        /// </summary>
        /// <param name="statusId">The ID of the status message to be destroyed.</param>
        /// <returns>An instance of <see cref="TwitterStatusListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/post-statuses-destroy-id</cref>
        /// </see>
        public TwitterStatusListResponse DestroyStatusMessage(long statusId) {
            return new TwitterStatusListResponse(Raw.DestroyStatusMessage(statusId));
        }

        /// <summary>
        /// Destroys the status message with the specified <paramref name="statusId"/>. The authenticating user must be
        /// the author of the specified status message. Returns the destroyed status message if successful.
        /// </summary>
        /// <param name="statusId">The ID of the status message to be destroyed.</param>
        /// <param name="trimUser">When set to <c>true</c>, each tweet returned in a timeline will include a user
        /// object including only the status authors numerical ID. Omit this parameter to receive the complete user
        /// object.</param>
        /// <returns>An instance of <see cref="TwitterStatusListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/post-statuses-destroy-id</cref>
        /// </see>
        public TwitterStatusListResponse DestroyStatusMessage(long statusId, bool trimUser) {
            return new TwitterStatusListResponse(Raw.DestroyStatusMessage(statusId, trimUser));
        }

        /// <summary>
        /// Destroys the specified <paramref name="statusMessage"/>. The authenticating user must be the author of the
        /// specified status message. Returns the destroyed status message if successful.
        /// </summary>
        /// <param name="statusMessage">The status meessage to be destroyed.</param>
        /// <returns>An instance of <see cref="TwitterStatusListResponse"/> representing the response.</returns>
        public TwitterStatusListResponse DestroyStatusMessage(TwitterStatusMessage statusMessage) {
            return new TwitterStatusListResponse(Raw.DestroyStatusMessage(statusMessage));
        }

        /// <summary>
        /// Destroys the specified <paramref name="statusMessage"/>. The authenticating user must be the author of the
        /// specified status message. Returns the destroyed status message if successful.
        /// </summary>
        /// <param name="statusMessage">The status meessage to be destroyed.</param>
        /// <param name="trimUser">When set to <code>true</code>, each tweet returned in a timeline will include a user
        /// object including only the status authors numerical ID. Omit this parameter to receive the complete user
        /// object.</param>
        /// <returns>An instance of <see cref="TwitterStatusListResponse"/> representing the response.</returns>
        public TwitterStatusListResponse DestroyStatusMessage(TwitterStatusMessage statusMessage, bool trimUser) {
            return new TwitterStatusListResponse(Raw.DestroyStatusMessage(statusMessage, trimUser));
        }

        #endregion

        #endregion

    }

}