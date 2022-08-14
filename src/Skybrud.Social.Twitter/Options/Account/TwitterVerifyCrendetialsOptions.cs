using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Twitter.Options.Account {

    /// <summary>
    /// Options for a call to verify the authenticated user (or the <em>credentials</em> of the user).
    /// </summary>
    /// <see>
    ///     <cref>https://developer.twitter.com/en/docs/twitter-api/v1/accounts-and-users/manage-account-settings/api-reference/get-account-verify_credentials</cref>
    /// </see>
    public class TwitterVerifyCrendetialsOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets whether entities should be included in the response. Default is <c>true</c>.
        ///
        /// Notice that both the user object and the status object will have their own <c>entities</c> property.
        /// The Twitter API documentation doesn't this further, but at the time of writing, this property only seems to
        /// effect the <c>entities</c> property on the status object.
        /// in the API documentation.
        /// </summary>
        public bool IncludeEntities { get; set; }

        /// <summary>
        /// Gets or sets whether the latest tweet (status message) of the user should be skipped in the response.
        /// Default is <c>false</c> (meaning it is included by default).
        /// </summary>
        public bool SkipStatus { get; set; }

        /// <summary>
        /// Gets or sets the email of the authenticated user should be included in the response. Default is
        /// <c>false</c>.
        ///
        /// Notice that this qill require the <strong>Request email addresses from users</strong> option to be enabled
        /// in the settings of your Twitter app.
        /// </summary>
        public bool IncludeEmail { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public TwitterVerifyCrendetialsOptions() {
            IncludeEntities = true;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            // Initialize the query string
            IHttpQueryString query = new HttpQueryString();
            if (!IncludeEntities) query.Add("include_entities", "false");
            if (SkipStatus) query.Add("skip_status", "true");
            if (IncludeEmail) query.Add("include_email", "true");

            // Initialize a new GET request
            return HttpRequest.Get("/1.1/account/verify_credentials.json", query);

        }

        #endregion

    }

}