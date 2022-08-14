using Skybrud.Essentials.Http;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Twitter.Options.Statuses {

    /// <summary>
    /// Abstract class with options for getting a timeline.
    /// </summary>
    public abstract class TwitterTimelineOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Returns results with an ID greater than (that is, more recent than) the specified ID. There are limits to
        /// the number of tweets which can be accessed through the API. If the limit of tweets has occured since the
        /// <c>since_id</c>, the <c>since_id</c> will be forced to the oldest ID available.
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
        /// <c>exclude_replies</c> with the <c>count</c> parameter will mean you will receive up-to count
        /// tweets — this is because the <c>count</c> parameter retrieves that many tweets before filtering out
        /// retweets and replies.
        /// </summary>
        public bool ExcludeReplies { get; set; }

        /// <summary>
        /// This parameter enhances the contributors element of the status response to include the
        /// <c>screen_name</c> of the contributor. By default only the <c>user_id</c> of the contributor is
        /// included.
        /// </summary>
        public bool ContributorDetails { get; set; }

        /// <summary>
        /// When set to <c>false</c>, the timeline will strip any native retweets (though they will still count
        /// toward both the maximal length of the timeline and the slice selected by the count parameter).
        ///
        /// Note: If you're using the <c>trim_user</c> parameter in conjunction with <c>include_rts</c>,
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
        protected TwitterTimelineOptions() {
            IncludeRetweets = true;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="count"/>.
        /// </summary>
        /// <param name="count">The maximum amount of tweets to be returned by the API.</param>
        protected TwitterTimelineOptions(int count) {
            Count = count;
            IncludeRetweets = true;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpQueryString"/>.</returns>
        protected virtual IHttpQueryString GetQueryString() {

            // Define the query string
            IHttpQueryString qs = new HttpQueryString();

            // Add optional parameters
            if (SinceId > 0) qs.Add("since_id", SinceId);
            if (Count > 0) qs.Add("count", Count);
            if (MaxId > 0) qs.Add("max_id", MaxId);
            if (TrimUser) qs.Add("trim_user", "true");
            if (ExcludeReplies) qs.Add("exclude_replies", "true");
            if (ContributorDetails) qs.Add("contributor_details", "true");
            if (!IncludeRetweets) qs.Add("include_rts", "false");
            if (TweetMode != TwitterTweetMode.Compatibility) qs.Add("tweet_mode", StringUtils.ToCamelCase(TweetMode));

            return qs;

        }

        /// <inheritdoc />
        public abstract IHttpRequest GetRequest();

        #endregion

    }

}