using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.Models.Statuses;
using Skybrud.Social.Twitter.OAuth;
using Skybrud.Social.Twitter.Options.Statuses;

namespace Skybrud.Social.Twitter.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the <strong>Statuses</strong> endpoint.
    /// </summary>
    public class TwitterStatusesRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public TwitterOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal TwitterStatusesRawEndpoint(TwitterOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        #region GetStatusMessage(...)

        /// <summary>
        /// Gets information about the status message (tweet) with the specified <paramref name="statusId"/>.
        /// </summary>
        /// <param name="statusId">The ID of the status message.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/get-statuses-show-id</cref>
        /// </see>
        public IHttpResponse GetStatusMessage(long statusId) {
            return GetStatusMessage(new TwitterGetStatusMessageOptions(statusId));
        }

        /// <summary>
        /// Gets information about the status message (tweet) matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options used when making the call to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/get-statuses-show-id</cref>
        /// </see>
        public IHttpResponse GetStatusMessage(TwitterGetStatusMessageOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

        #region PostStatusMessage(...)

        /// <summary>
        /// Posts the specified status message (tweet).
        /// </summary>
        /// <param name="status">The status message to send.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/post-statuses-update</cref>
        /// </see>
        public IHttpResponse PostStatusMessage(string status) {
            if (string.IsNullOrWhiteSpace(status)) throw new ArgumentNullException(nameof(status));
            return PostStatusMessage(new TwitterPostStatusMessageOptions(status));
        }

        /// <summary>
        /// Posts the specified status message (tweet).
        /// </summary>
        /// <param name="status">The status message to send.</param>
        /// <param name="replyTo">The ID of the status message to reply to.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/post-statuses-update</cref>
        /// </see>
        public IHttpResponse PostStatusMessage(string status, long replyTo) {
            if (string.IsNullOrWhiteSpace(status)) throw new ArgumentNullException(nameof(status));
            return PostStatusMessage(new TwitterPostStatusMessageOptions(status, replyTo));
        }

        /// <summary>
        /// Posts a new status message (tweet) with the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/post-statuses-update</cref>
        /// </see>
        public IHttpResponse PostStatusMessage(TwitterPostStatusMessageOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

        #region GetUserTimeline(...)

        /// <summary>
        /// Gets the timeline of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-user_timeline</cref>
        /// </see>
        public IHttpResponse GetUserTimeline(long userId) {
            return GetUserTimeline(new TwitterGetUserTimelineOptions(userId));
        }

        /// <summary>
        /// Gets the timeline of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">The maximum amount of tweets to return.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-user_timeline</cref>
        /// </see>
        public IHttpResponse GetUserTimeline(long userId, int count) {
            return GetUserTimeline(new TwitterGetUserTimelineOptions(userId, count));
        }

        /// <summary>
        /// Gets the timeline of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">The maximum amount of tweets to return.</param>
        /// <param name="maxId">The maximum status message ID. Only status message with an ID less then (that is, older
        /// than) this ID will be returned.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-user_timeline</cref>
        /// </see>
        public IHttpResponse GetUserTimeline(long userId, int count, long maxId) {
            return GetUserTimeline(new TwitterGetUserTimelineOptions(userId, count, maxId));
        }

        /// <summary>
        /// Gets the timeline of the user with the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-user_timeline</cref>
        /// </see>
        public IHttpResponse GetUserTimeline(string screenName) {
            return GetUserTimeline(new TwitterGetUserTimelineOptions(screenName));
        }

        /// <summary>
        /// Gets the timeline of the user with the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <param name="count">The maximum amount of tweets to return.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-user_timeline</cref>
        /// </see>
        public IHttpResponse GetUserTimeline(string screenName, int count) {
            return GetUserTimeline(new TwitterGetUserTimelineOptions(screenName, count));
        }

        /// <summary>
        /// Gets the timeline of the user with the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <param name="count">The maximum amount of tweets to return.</param>
        /// <param name="maxId">The maximum status message ID. Only status message with an ID less then (that is, older
        /// than) this ID will be returned.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-user_timeline</cref>
        /// </see>
        public IHttpResponse GetUserTimeline(string screenName, int count, long maxId) {
            return GetUserTimeline(new TwitterGetUserTimelineOptions(screenName, count, maxId));
        }

        /// <summary>
        /// Gets the timeline of the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options used when making the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-user_timeline</cref>
        /// </see>
        public IHttpResponse GetUserTimeline(TwitterGetUserTimelineOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

        #region GetHomeTimeline(...)

        /// <summary>
        /// Gets a collection of the most recent tweets and retweets posted by the authenticating user and the users
        /// they follow.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-home_timeline</cref>
        /// </see>
        public IHttpResponse GetHomeTimeline() {
            return GetHomeTimeline(new TwitterGetHomeTimelineOptions());
        }

        /// <summary>
        /// Gets a collection of the most recent tweets and retweets posted by the authenticating user and the users
        /// they follow.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <param name="count">The maximum amount of tweets to return.</param>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-home_timeline</cref>
        /// </see>
        public IHttpResponse GetHomeTimeline(int count) {
            return GetHomeTimeline(new TwitterGetHomeTimelineOptions(count));
        }

        /// <summary>
        /// Gets a collection of the most recent tweets and retweets posted by the authenticating user and the users
        /// they follow. 
        /// </summary>
        /// <param name="options">The options for the call.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-home_timeline</cref>
        /// </see>
        public IHttpResponse GetHomeTimeline(TwitterGetHomeTimelineOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

        #region GetMentionsTimeline(...)

        /// <summary>
        /// Gets the most recent mentions (tweets containing the users's @screen_name) for the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-mentions_timeline</cref>
        /// </see>
        public IHttpResponse GetMentionsTimeline() {
            return GetMentionsTimeline(new TwitterGetMentionsTimelineOptions());
        }

        /// <summary>
        /// Gets the most recent mentions (tweets containing the users's @screen_name) for the authenticated user.
        /// </summary>
        /// <param name="count">The maximum amount of tweets to return.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-mentions_timeline</cref>
        /// </see>
        public IHttpResponse GetMentionsTimeline(int count) {
            return GetMentionsTimeline(new TwitterGetMentionsTimelineOptions(count));
        }

        /// <summary>
        /// Gets the most recent mentions (tweets containing the users's @screen_name) for the authenticated user.
        /// </summary>
        /// <param name="options">The options for the call.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-mentions_timeline</cref>
        /// </see>
        public IHttpResponse GetMentionsTimeline(TwitterGetMentionsTimelineOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

        #region GetRetweetsOfMe(...)

        /// <summary>
        /// Gets a list of the most recent tweets authored by the authenticating user that have been retweeted by others.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/get-statuses-retweets_of_me</cref>
        /// </see>
        public IHttpResponse GetRetweetsOfMe() {
            return GetRetweetsOfMe(new TwitterGetRetweetsOfMeTimelineOptions());
        }

        /// <summary>
        /// Gets a list of the most recent tweets authored by the authenticating user that have been retweeted by others.
        /// </summary>
        /// <param name="count">The maximum amount of tweets to return.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/get-statuses-retweets_of_me</cref>
        /// </see>
        public IHttpResponse GetRetweetsOfMe(int count) {
            return GetRetweetsOfMe(new TwitterGetRetweetsOfMeTimelineOptions(count));
        }

        /// <summary>
        /// Gets a list of the most recent tweets authored by the authenticating user that have been retweeted by others.
        /// </summary>
        /// <param name="options">The options for the call.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/get-statuses-retweets_of_me</cref>
        /// </see>
        public IHttpResponse GetRetweetsOfMe(TwitterGetRetweetsOfMeTimelineOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

        #region RetweetStatusMessage(...)

        /// <summary>
        /// Retweets the status message with the specified <paramref name="statusId"/>.
        /// </summary>
        /// <param name="statusId">The ID of the status message to be retweeted.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/post-statuses-retweet-id</cref>
        /// </see>
        public IHttpResponse RetweetStatusMessage(long statusId) {
            return RetweetStatusMessage(statusId, false);
        }

        /// <summary>
        /// Retweets the status message with the specified <paramref name="statusId"/>.
        /// </summary>
        /// <param name="statusId">The ID of the status message to be retweeted.</param>
        /// <param name="trimUser">When set to <code>true</code>, each tweet returned in a timeline will include a user
        /// object including only the status authors numerical ID. Omit this parameter to receive the complete user
        /// object.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/post-statuses-retweet-id</cref>
        /// </see>
        public IHttpResponse RetweetStatusMessage(long statusId, bool trimUser) {
            return Client.Post("https://api.twitter.com/1.1/statuses/retweet/" + statusId + ".json" + (trimUser ? "?trim_user=true" : ""));
        }

        /// <summary>
        /// Retweets the specified <paramref name="statusMessage"/>.
        /// </summary>
        /// <param name="statusMessage">The status message to be retweeted.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse RetweetStatusMessage(TwitterStatusMessage statusMessage) {
            if (statusMessage == null) throw new ArgumentNullException(nameof(statusMessage));
            return RetweetStatusMessage(statusMessage.Id, false);
        }

        /// <summary>
        /// Retweets the specified <paramref name="statusMessage"/>.
        /// </summary>
        /// <param name="statusMessage">The status message to be retweeted.</param>
        /// <param name="trimUser">When set to <code>true</code>, each tweet returned in a timeline will include a user
        /// object including only the status authors numerical ID. Omit this parameter to receive the complete user
        /// object.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse RetweetStatusMessage(TwitterStatusMessage statusMessage, bool trimUser) {
            if (statusMessage == null) throw new ArgumentNullException(nameof(statusMessage));
            return RetweetStatusMessage(statusMessage.Id, trimUser);
        }

        #endregion

        #region DestroyStatusMessage(...)

        /// <summary>
        /// Destroys the status message with the specified <paramref name="statusId"/>. The authenticating user must be
        /// the author of the specified status message. Returns the destroyed status message if successful.
        /// </summary>
        /// <param name="statusId">The ID of the status message to be destroyed.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/post-statuses-destroy-id</cref>
        /// </see>
        public IHttpResponse DestroyStatusMessage(long statusId) {
            return DestroyStatusMessage(statusId, false);
        }

        /// <summary>
        /// Destroys the status message with the specified <paramref name="statusId"/>. The authenticating user must be
        /// the author of the specified status message. Returns the destroyed status message if successful.
        /// </summary>
        /// <param name="statusId">The ID of the status message to be destroyed.</param>
        /// <param name="trimUser">When set to <c>true</c>, each tweet returned in a timeline will include a user
        /// object including only the status authors numerical ID. Omit this parameter to receive the complete user
        /// object.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/post-statuses-destroy-id</cref>
        /// </see>
        public IHttpResponse DestroyStatusMessage(long statusId, bool trimUser) {
            return Client.Post("https://api.twitter.com/1.1/statuses/destroy/" + statusId + ".json" + (trimUser ? "?trim_user=true" : ""));
        }

        /// <summary>
        /// Destroys the specified <paramref name="statusMessage"/>. The authenticating user must be the author of the
        /// specified status message. Returns the destroyed status message if successful.
        /// </summary>
        /// <param name="statusMessage">The status meessage to be destroyed.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse DestroyStatusMessage(TwitterStatusMessage statusMessage) {
            if (statusMessage == null) throw new ArgumentNullException(nameof(statusMessage));
            return DestroyStatusMessage(statusMessage.Id, false);
        }

        /// <summary>
        /// Destroys the specified <paramref name="statusMessage"/>. The authenticating user must be the author of the
        /// specified status message. Returns the destroyed status message if successful.
        /// </summary>
        /// <param name="statusMessage">The status meessage to be destroyed.</param>
        /// <param name="trimUser">When set to <c>true</c>, each tweet returned in a timeline will include a user
        /// object including only the status authors numerical ID. Omit this parameter to receive the complete user
        /// object.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse DestroyStatusMessage(TwitterStatusMessage statusMessage, bool trimUser) {
            if (statusMessage == null) throw new ArgumentNullException(nameof(statusMessage));
            return DestroyStatusMessage(statusMessage.Id, trimUser);
        }

        #endregion

        #endregion

    }

}