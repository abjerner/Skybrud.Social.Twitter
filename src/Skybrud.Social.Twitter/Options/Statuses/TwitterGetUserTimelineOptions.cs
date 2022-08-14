using Skybrud.Essentials.Http;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Twitter.Options.Statuses {

    /// <summary>
    /// Class with options for getting the timeline of a Twitter user.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-user_timeline</cref>
    /// </see>
    public class TwitterGetUserTimelineOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the user for whom to return results for.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the screen name of the user for whom to return results for.
        /// </summary>
        public string ScreenName { get; set; }

        /// <summary>
        /// Returns results with an ID greater than (that is, more recent than) the specified ID. There are limits to
        /// the number of Tweets which can be accessed  through the API. If the limit of Tweets has occured since the
        /// <code>since_id</code>, the <code>since_id</code> will be forced to the oldest ID available.
        /// </summary>
        public long SinceId { get; set; }

        /// <summary>
        /// Specifies the number of tweets to try and retrieve, up to a maximum of 200 per distinct request. The value
        /// of count is best thought of as a limit to the number of tweets to return because suspended or deleted
        /// content is removed after the count has been applied.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Returns results with an ID less than (that is, older than) or equal to the specified ID.
        /// </summary>
        public long MaxId { get; set; }

        /// <summary>
        /// When set to true, each tweet returned in a timeline will include a user object including only the status
        /// authors numerical ID. Omit this parameter to receive the complete user object.
        /// </summary>
        public bool TrimUser { get; set; }

        /// <summary>
        /// This parameter will prevent replies from appearing in the returned timeline. Using
        /// <code>exclude_replies</code> with the <code>count</code> parameter will mean you will receive up-to count
        /// tweets — this is because the <code>count</code> parameter retrieves that many tweets before filtering out
        /// retweets and replies.
        /// </summary>
        public bool ExcludeReplies { get; set; }

        /// <summary>
        /// This parameter enhances the contributors element of the status response to include the screen_name of the
        /// contributor. By default only the user_id of the contributor is included.
        /// </summary>
        public bool ContributorDetails { get; set; }

        /// <summary>
        /// When set to <code>false</code>, the timeline will strip any native retweets  (though they will still count
        /// toward both the maximal length of the timeline and the slice selected by the count parameter).
        ///
        /// Note: If you're using the <code>trim_user</code> parameter in conjunction with <code>include_rts</code>,
        /// the retweets will still contain a full user object.
        /// </summary>
        public bool IncludeRetweets { get; set; }

        /// <summary>
        /// Gets or sets the tweet mode, qhich determines the JSON payload of each tweet. Default is <see cref="TwitterTweetMode.Compatibility"/>.
        /// </summary>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/tweet-updates#overview</cref>
        /// </see>
        public TwitterTweetMode TweetMode { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public TwitterGetUserTimelineOptions() {
            IncludeRetweets = true;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId"></param>
        public TwitterGetUserTimelineOptions(long userId) {
            UserId = userId;
            IncludeRetweets = true;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">The maximum amount of tweets to return.</param>
        public TwitterGetUserTimelineOptions(long userId, int count) {
            UserId = userId;
            Count = count;
            IncludeRetweets = true;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">The maximum amount of tweets to return.</param>
        /// <param name="maxId">The maximum status message ID. Only status message with an ID less then (that is, older
        /// than) this ID will be returned.</param>
        public TwitterGetUserTimelineOptions(long userId, int count, long maxId) {
            UserId = userId;
            Count = count;
            MaxId = maxId;
            IncludeRetweets = true;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        public TwitterGetUserTimelineOptions(string screenName) {
            ScreenName = screenName;
            IncludeRetweets = true;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <param name="count">The maximum amount of tweets to return.</param>
        public TwitterGetUserTimelineOptions(string screenName, int count) {
            ScreenName = screenName;
            Count = count;
            IncludeRetweets = true;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <param name="count">The maximum amount of tweets to return.</param>
        /// <param name="maxId">The maximum status message ID. Only status message with an ID less then (that is, older
        /// than) this ID will be returned.</param>
        public TwitterGetUserTimelineOptions(string screenName, int count, long maxId) {
            ScreenName = screenName;
            Count = count;
            MaxId = maxId;
            IncludeRetweets = true;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            // Initialize the query string
            IHttpQueryString query = new HttpQueryString();
            if (UserId > 0) query.Set("user_id", UserId);
            if (!string.IsNullOrWhiteSpace(ScreenName)) query.Set("screen_name", ScreenName);
            if (SinceId > 0) query.Set("since_id", SinceId);
            if (Count > 0) query.Set("count", Count);
            if (MaxId > 0) query.Set("max_id", MaxId);
            if (TrimUser) query.Set("trim_user", "true");
            if (ExcludeReplies) query.Set("exclude_replies", "true");
            if (ContributorDetails) query.Set("contributor_details", "true");
            if (!IncludeRetweets) query.Set("include_rts", "false");
            if (TweetMode != TwitterTweetMode.Compatibility) query.Add("tweet_mode", StringUtils.ToCamelCase(TweetMode));

            // Initialize a new GET request
            return HttpRequest.Get("/1.1/statuses/user_timeline.json", query);

        }

        #endregion

    }

}