using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Twitter.Options.Users {

    /// <summary>
    /// Class with options for searching through Twitter users.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/follow-search-get-users/api-reference/get-users-search</cref>
    /// </see>
    public class TwitterSearchUsersOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the search query.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Specifies the page of results to retrieve.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// The number of potential user results to retrieve per page. This value has a maximum of 20.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// The entities node will be disincluded from embedded tweet objects when set to <c>false</c>.
        /// </summary>
        public bool IncludeEntities { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public TwitterSearchUsersOptions() {
            Page = 1;
            Count = 20;
            IncludeEntities = true;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpQueryString"/>.</returns>
        public IHttpQueryString GetQueryString() {

            IHttpQueryString query = new HttpQueryString();

            query.Set("q", Query);
            if (Page > 1) query.Set("page", Page);
            if (Count != 20) query.Set("count", Count);
            if (!IncludeEntities) query.Set("include_entities", "false");

            return query;

        }

        #endregion

    }

}