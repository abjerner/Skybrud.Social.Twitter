using Skybrud.Essentials.Http.Client;
using Skybrud.Social.Twitter.Endpoints.Raw;

namespace Skybrud.Social.Twitter.OAuth {

    /// <summary>
    /// Interface describing a Twitter OAuth client.
    /// </summary>
    public interface ITwitterOAuthClient : IHttpClient {

        /// <summary>
        /// Gets a reference to the account endpoint.
        /// </summary>
        TwitterAccountRawEndpoint Account { get; }

        /// <summary>
        /// Gets a reference to the favorites endpoint.
        /// </summary>
        TwitterFavoritesRawEndpoint Favotires { get; }

        /// <summary>
        /// Gets a reference to the followers endpoint.
        /// </summary>
        TwitterFollowersRawEndpoint Followers { get; }

        /// <summary>
        /// Gets a reference to the friends endpoint.
        /// </summary>
        TwitterFriendsRawEndpoint Friends { get; }

        /// <summary>
        /// Gets a reference to the geo endpoint.
        /// </summary>
        TwitterGeocodeRawEndpoint Geocode { get; }

        /// <summary>
        /// Gets a reference to the lists endpoint.
        /// </summary>
        TwitterListsRawEndpoint Lists { get; }

        /// <summary>
        /// Gets a reference to the statuses endpoint.
        /// </summary>
        TwitterSearchRawEndpoint Search { get; }

        /// <summary>
        /// Gets a reference to the statuses endpoint.
        /// </summary>
        TwitterStatusesRawEndpoint Statuses { get; }

        /// <summary>
        /// Gets a reference to the users endpoint.
        /// </summary>
        TwitterUsersRawEndpoint Users { get; }

    }

}