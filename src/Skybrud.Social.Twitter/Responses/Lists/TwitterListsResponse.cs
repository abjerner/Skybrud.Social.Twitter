using System.Collections.Generic;
using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.Models.Lists;

namespace Skybrud.Social.Twitter.Responses.Lists {

    /// <summary>
    /// Class respresenting the response for a list of lists.
    /// </summary>
    public class TwitterListsResponse : TwitterResponse<IReadOnlyList<TwitterList>> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public TwitterListsResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonArray(response.Body, TwitterList.Parse);

        }

    }

}