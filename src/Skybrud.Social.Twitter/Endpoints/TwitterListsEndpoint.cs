using Skybrud.Social.Twitter.Endpoints.Raw;
using Skybrud.Social.Twitter.Options.Lists;
using Skybrud.Social.Twitter.Responses.Lists;

namespace Skybrud.Social.Twitter.Endpoints {

    /// <summary>
    /// Class representing the implementation of the <strong>Lists</strong> endpoint.
    /// </summary>
    public class TwitterListsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Twitter service.
        /// </summary>
        public TwitterHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw lists endpoint.
        /// </summary>
        public TwitterListsRawEndpoint Raw => Service.Client.Lists;

        #endregion

        #region Constructors

        internal TwitterListsEndpoint(TwitterHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the list with the specified <paramref name="listId"/>.
        /// </summary>
        /// <param name="listId">The ID of the list.</param>
        /// <returns>An instance of <see cref="TwitterListResponse"/> representing the response.</returns>
        public TwitterListResponse GetList(long listId) {
            return new TwitterListResponse(Raw.GetList(listId));
        }

        /// <summary>
        /// Gets information about the list with the specified <paramref name="userId"/> and <paramref name="slug"/>.
        /// </summary>
        /// <param name="userId">The ID of the user owning the list.</param>
        /// <param name="slug">The slug of the list.</param>
        /// <returns>An instance of <see cref="TwitterListResponse"/> representing the response.</returns>
        public TwitterListResponse GetList(long userId, string slug) {
            return new TwitterListResponse(Raw.GetList(userId, slug));
        }

        /// <summary>
        /// Gets information about the list with the specified <paramref name="screenName"/> and <paramref name="slug"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user owning the list.</param>
        /// <param name="slug">The slug of the list.</param>
        /// <returns>An instance of <see cref="TwitterListResponse"/> representing the response.</returns>
        public TwitterListResponse GetList(string screenName, string slug) {
            return new TwitterListResponse(Raw.GetList(screenName, slug));
        }

        /// <summary>
        /// Gets information about the list matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="TwitterListResponse"/> representing the response.</returns>
        public TwitterListResponse GetList(TwitterGetListOptions options) {
            return new TwitterListResponse(Raw.GetList(options));
        }

        /// <summary>
        /// Gets a list of lists of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="TwitterListsResponse"/> representing the response.</returns>
        public TwitterListsResponse GetLists() {
            return new TwitterListsResponse(Raw.GetLists());
        }

        /// <summary>
        /// Gets a list of lists of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="TwitterListsResponse"/> representing the response.</returns>
        public TwitterListsResponse GetLists(long userId) {
            return new TwitterListsResponse(Raw.GetLists(userId));
        }

        /// <summary>
        /// Gets a list of lists of the user with the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <returns>An instance of <see cref="TwitterListsResponse"/> representing the response.</returns>
        public TwitterListsResponse GetLists(string screenName) {
            return new TwitterListsResponse(Raw.GetLists(screenName));
        }


        /// <summary>
        /// Creates a new list for the authenticated user. Note that you can create up to 1000 lists per account. The created list will be public.
        /// </summary>
        /// <param name="name">The name of the list.</param>
        /// <returns>An instance of <see cref="TwitterListsResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/post-lists-create</cref>
        /// </see>
        public TwitterListsResponse CreateList(string name) {
            return CreateList(new TwitterCreateListOptions(name));
        }

        /// <summary>
        /// Creates a new list for the authenticated user. Note that you can create up to 1000 lists per account.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="TwitterListsResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/post-lists-create</cref>
        /// </see>
        public TwitterListsResponse CreateList(TwitterCreateListOptions options) {
            return new TwitterListsResponse(Raw.CreateList(options));
        }

        /// <summary>
        /// Deletes the list with the specified <paramref name="listId"/>. The authenticated user must own the list to be able to destroy it.
        /// </summary>
        /// <param name="listId"></param>
        /// <returns>An instance of <see cref="TwitterListsResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/post-lists-destroy</cref>
        /// </see>
        public TwitterListsResponse DeleteList(long listId) {
            return DeleteList(new TwitterDeleteListOptions(listId));
        }

        /// <summary>
        /// Deletes the matching the specified <paramref name="options"/>. The authenticated user must own the list to be able to destroy it.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="TwitterListsResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/post-lists-destroy</cref>
        /// </see>
        public TwitterListsResponse DeleteList(TwitterDeleteListOptions options) {
            return new TwitterListsResponse(Raw.DeleteList(options));
        }

        /// <summary>
        /// Adds a member to a list. The authenticated user must own the list to be able to add members to it. Note that lists cannot have more than 5,000 members.
        /// </summary>
        /// <param name="listId">The numeric ID of the list.</param>
        /// <param name="userId">The numeric ID of the user.</param>
        /// <returns>An instance of <see cref="TwitterListsResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/post-lists-members-create</cref>
        /// </see>
        public TwitterListsResponse AddMember(long listId, long userId) {
            return AddMember(new TwitterAddMemberOptions(listId, userId));
        }

        /// <summary>
        /// Adds a member to a list. The authenticated user must own the list to be able to add members to it. Note that lists cannot have more than 5,000 members.
        /// </summary>
        /// <param name="listId">The numeric ID of the list.</param>
        /// <param name="screenName">The screen name of the user.</param>
        /// <returns>An instance of <see cref="TwitterListsResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/post-lists-members-create</cref>
        /// </see>
        public TwitterListsResponse AddMember(long listId, string screenName) {
            return AddMember(new TwitterAddMemberOptions(listId, screenName));
        }

        /// <summary>
        /// Adds a member to a list. The authenticated user must own the list to be able to add members to it. Note that lists cannot have more than 5,000 members.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="TwitterListsResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/post-lists-members-create</cref>
        /// </see>
        public TwitterListsResponse AddMember(TwitterAddMemberOptions options) {
            return new TwitterListsResponse(Raw.AddMember(options));
        }

        /// <summary>
        /// Removes the specified member from the list. The authenticated user must be the list’s owner to remove members from the list.
        /// </summary>
        /// <param name="listId">The numeric ID of the list.</param>
        /// <param name="userId">The numeric ID of the user.</param>
        /// <returns>An instance of <see cref="TwitterListsResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/post-lists-members-destroy</cref>
        /// </see>
        public TwitterListsResponse RemoveMember(long listId, long userId) {
            return RemoveMember(new TwitterRemoveMemberOptions(listId, userId));
        }

        /// <summary>
        /// Removes the specified member from the list. The authenticated user must be the list’s owner to remove members from the list.
        /// </summary>
        /// <param name="listId">The numeric ID of the list.</param>
        /// <param name="screenName">The screen name of the user.</param>
        /// <returns>An instance of <see cref="TwitterListsResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/post-lists-members-destroy</cref>
        /// </see>
        public TwitterListsResponse RemoveMember(long listId, string screenName) {
            return RemoveMember(new TwitterRemoveMemberOptions(listId, screenName));
        }

        /// <summary>
        /// Removes the specified member from the list. The authenticated user must be the list’s owner to remove members from the list.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="TwitterListsResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/post-lists-members-destroy</cref>
        /// </see>
        public TwitterListsResponse RemoveMember(TwitterRemoveMemberOptions options) {
            return new TwitterListsResponse(Raw.RemoveMember(options));
        }

        #endregion

    }

}