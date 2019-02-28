using System;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Twitter.Options.Favorites {
    
    /// <summary>
    /// Class with options for a request to the Twitter API for getting a list of favorites.
    /// </summary>
    public class TwitterGetFavoritesOptions : IHttpGetOptions {

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
        public int Count { get; set; }

        /// <summary>
        /// Returns results with an ID greater than (that is, more recent than) the specified ID. There are limits to
        /// the number of Tweets which can be accessed through the API. If the limit of Tweets has occured since the
        /// <c>since_id</c>, the <c>since_id</c> will be forced to the oldest ID available.
        /// </summary>
        public long SinceId { get; set; }

        /// <summary>
        /// Returns results with an ID less than (that is, older than) or equal to the specified ID.
        /// </summary>
        public long MaxId { get; set; }

        /// <summary>
        /// The <c>entities</c> node will be omitted when set to <c>false</c>.
        /// </summary>
        public bool IncludeEntities { get; set; }

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

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpQueryString"/>.</returns>
        public IHttpQueryString GetQueryString() {
            IHttpQueryString qs = new HttpQueryString();
            if (UserId > 0) qs.Set("user_id", UserId);
            if (!String.IsNullOrWhiteSpace(ScreenName)) qs.Set("screen_name", ScreenName);
            if (Count > 0) qs.Set("count", Count);
            if (SinceId > 0) qs.Set("since_id", SinceId);
            if (MaxId > 0) qs.Set("max_id", MaxId);
            if (!IncludeEntities) qs.Set("include_entities", "0");
            return qs;
        }

        #endregion

    }

}