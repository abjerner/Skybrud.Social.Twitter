using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Twitter.Options.Lists {

    /// <summary>
    /// Options for a call to the Twitter API for deleting a list.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/post-lists-destroy</cref>
    /// </see>
    public class TwitterDeleteListOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the numerical ID of the list.
        /// </summary>
        public long ListId { get; set; }

        // TODO: Add support for the "owner_screen_name" property

        // TODO: Add support for the "owner_id" property

        // TODO: Add support for the "slug" property

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public TwitterDeleteListOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="listId"/>.
        /// </summary>
        /// <param name="listId">The numerical ID of the list.</param>
        public TwitterDeleteListOptions(long listId) {
            ListId = listId;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpQueryString"/>.</returns>
        public IHttpQueryString GetQueryString() {
            return new HttpQueryString();
        }

        /// <summary>
        /// Gets an instance of <see cref="IHttpPostData"/> representing the POST parameters.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpPostData"/>.</returns>
        public IHttpPostData GetPostData() {
            return new HttpPostData {{"list_id", ListId}};
        }

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            // Validate required properties
            if (ListId == 0) throw new PropertyNotSetException(nameof(ListId));

            // Initialize the POST body
            IHttpPostData body = new HttpPostData { { "list_id", ListId } };

            // Initialize a new GET request
            return HttpRequest.Post("/1.1/lists/destroy.json", null, body);

        }

        #endregion

    }

}