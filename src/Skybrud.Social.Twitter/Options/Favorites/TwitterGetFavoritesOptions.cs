using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Twitter.Options.Favorites {

    /// <summary>
    /// Class with options for a request to the Twitter API for getting a list of favorites.
    /// </summary>
    public class TwitterGetFavoritesOptions : IHttpRequestOptions {

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
        /// Gets or sets the number of records to retrieve. Must be less than or equal to <c>200</c>; defaults to
        /// <code>20</code>. The value of count is best thought of as a limit to the number of tweets to return because
        /// suspended or deleted content is removed after the count has been applied.
        /// </summary>
        public int? Count { get; set; }

        /// <summary>
        /// Returns results with an ID greater than (that is, more recent than) the specified ID. There are limits to
        /// the number of Tweets which can be accessed through the API. If the limit of Tweets has occured since the
        /// <c>since_id</c>, the <c>since_id</c> will be forced to the oldest ID available.
        /// </summary>
        public long? SinceId { get; set; }

        /// <summary>
        /// Returns results with an ID less than (that is, older than) or equal to the specified ID.
        /// </summary>
        public long? MaxId { get; set; }

        /// <summary>
        /// The <c>entities</c> node will be omitted when set to <c>false</c>.
        /// </summary>
        public bool? IncludeEntities { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public TwitterGetFavoritesOptions() {
            IncludeEntities = true;
        }

        /// <summary>
        /// Intializes a new instance based on the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The screen name of the user owning the list.</param>
        public TwitterGetFavoritesOptions(long userId) {
            UserId = userId;
            IncludeEntities = true;
        }

        /// <summary>
        /// Intializes a new instance based on the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user owning the list.</param>
        public TwitterGetFavoritesOptions(string screenName) {
            ScreenName = screenName;
            IncludeEntities = true;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            // Initialize the query string
            IHttpQueryString query = new HttpQueryString();
            if (UserId > 0) query.Set("user_id", UserId);
            if (!string.IsNullOrWhiteSpace(ScreenName)) query.Set("screen_name", ScreenName);
            if (Count is not null) query.Set("count", Count.Value);
            if (SinceId is not null) query.Set("since_id", SinceId.Value);
            if (MaxId is not null) query.Set("max_id", MaxId.Value);
            if (IncludeEntities is not null) query.Set("include_entities", IncludeEntities.Value ? "1" : "0");

            // Initialize a new GET request
            return HttpRequest.Get("/1.1/favorites/list.json", query);

        }

        #endregion

    }

}