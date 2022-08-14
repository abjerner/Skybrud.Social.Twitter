using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;
using Skybrud.Essentials.Strings;

namespace Skybrud.Social.Twitter.Options.Statuses {

    /// <summary>
    /// Class with options for getting information about a single status message (tweet).
    /// </summary>
    public class TwitterGetStatusMessageOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the status message to be found.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// When set to <c>true</c>, each tweet returned in a timeline will include a user object
        /// including only the status authors numerical ID. Omit this parameter to receive
        /// the complete user object.
        /// </summary>
        public bool TrimUser { get; set; }

        /// <summary>
        /// When set to <c>true</c>, any Tweets returned that have been retweeted by the
        /// authenticating user will include an additional <c>current_user_retweet</c>
        /// node, containing the ID of the source status for the retweet.
        /// </summary>
        public bool IncludeMyRetweet { get; set; }

        /// <summary>
        /// The entities node will be disincluded when set to <c>false</c>.
        /// </summary>
        public bool IncludeEntities { get; set; }

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
        public TwitterGetStatusMessageOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="statusId"/>.
        /// </summary>
        /// <param name="statusId">The ID of the status message (tweet).</param>
        public TwitterGetStatusMessageOptions(long statusId) {
            Id = statusId;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            // Validate required properties
            if (Id == 0) throw new PropertyNotSetException(nameof(Id));

            // Initialize the query string
            IHttpQueryString query = new HttpQueryString { { "id", Id } };
            if (TrimUser) query.Add("trim_user", "true");
            if (IncludeMyRetweet) query.Add("include_my_retweet", "true");
            if (IncludeEntities) query.Add("include_entities", "true");
            if (TweetMode != TwitterTweetMode.Compatibility) query.Add("tweet_mode", StringUtils.ToCamelCase(TweetMode));

            // Initialize a new GET request
            return HttpRequest.Get("/1.1/statuses/show.json", query);

        }

        #endregion

    }

}