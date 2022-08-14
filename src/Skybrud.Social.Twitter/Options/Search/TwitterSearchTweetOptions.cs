using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Time;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;
using Skybrud.Essentials.Strings.Extensions;

namespace Skybrud.Social.Twitter.Options.Search {

    /// <summary>
    /// Class with options for searching through tweets using the Twitter API.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.twitter.com/en/docs/tweets/search/api-reference/get-search-tweets</cref>
    /// </see>
    public class TwitterSearchTweetOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// The search query of 500 characters maximum, including operators. Queries may additionally be limited by
        /// complexity.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Optional. Specifies what type of search results you would prefer to receive. The current default is
        /// <see cref="TwitterSearchTweetResultType.Mixed"/>.
        /// </summary>
        public TwitterSearchTweetResultType ResultType { get; set; }

        /// <summary>
        /// The number of tweets to return per page, up to a maximum of <c>100</c>. Defaults to <c>15</c>.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Returns tweets generated before the given date. Keep in mind that the search index may not go back as far
        /// as the date you specify here.
        /// </summary>
        public EssentialsTime Until { get; set; }

        /// <summary>
        /// Returns results with an ID greater than (that is, more recent than) the specified ID. There are limits to
        /// the number of tweets which can be accessed through the API. If the limit of tweets has occured since the
        /// <see cref="SinceId"/>, the <see cref="SinceId"/> will be forced to the oldest ID available.
        /// </summary>
        public long SinceId { get; set; }

        /// <summary>
        /// Returns results with an ID less than (that is, older than) or equal to the specified ID.
        /// </summary>
        public long MaxId { get; set; }

        /// <summary>
        /// The <c>entities</c> node will be disincluded when set to <c>false</c>.
        /// </summary>
        public bool IncludeEntities { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public TwitterSearchTweetOptions() {
            IncludeEntities = true;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="query"/>.
        /// </summary>
        /// <param name="query">The search query of 500 characters maximum, including operators.</param>
        public TwitterSearchTweetOptions(string query) {
            Query = query;
            IncludeEntities = true;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="query"/>.
        /// </summary>
        /// <param name="query">The search query of 500 characters maximum, including operators.</param>
        /// <param name="count">The maximum amount of tweets to be returned per page.</param>
        public TwitterSearchTweetOptions(string query, int count) {
            Query = query;
            Count = count;
            IncludeEntities = true;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpQueryString"/>.</returns>
        public IHttpQueryString GetQueryString() {

            if (string.IsNullOrWhiteSpace(Query)) throw new PropertyNotSetException(Query);

            string resultType = ResultType.ToString().ToLower();

            IHttpQueryString query = new HttpQueryString();
            if (!string.IsNullOrWhiteSpace(Query)) query.Set("q", Query);
            if (resultType != "mixed") query.Set("result_type", resultType);
            if (Count > 0) query.Set("count", Count);
            if (Until != null) query.Set("until", Until.ToString("yyyy-MM-dd"));
            if (SinceId > 0) query.Set("since_id", SinceId);
            if (MaxId > 0) query.Set("max_id", MaxId);
            if (!IncludeEntities) query.Set("include_entities", "false");
            return query;

        }

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            // Validate required properties
            if (string.IsNullOrWhiteSpace(Query)) throw new PropertyNotSetException(Query);

            // Initialize the query string
            IHttpQueryString query = new HttpQueryString();
            if (!string.IsNullOrWhiteSpace(Query)) query.Set("q", Query);
            if (ResultType != TwitterSearchTweetResultType.Mixed) query.Set("result_type", ResultType.ToLower());
            if (Count > 0) query.Set("count", Count);
            if (Until != null) query.Set("until", Until.ToString("yyyy-MM-dd"));
            if (SinceId > 0) query.Set("since_id", SinceId);
            if (MaxId > 0) query.Set("max_id", MaxId);
            if (!IncludeEntities) query.Set("include_entities", "false");

            // Initialize a new GET request
            return HttpRequest.Get("/1.1/account/verify_credentials.json", query);

        }

        #endregion

    }

}