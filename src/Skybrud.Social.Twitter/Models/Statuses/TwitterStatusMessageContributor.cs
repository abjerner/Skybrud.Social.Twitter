namespace Skybrud.Social.Twitter.Models.Statuses {

    /// <summary>
    /// Gets information about a user who contributed to a <see cref="TwitterStatusMessage"/>.
    /// </summary>
    public class TwitterStatusMessageContributor {

        /// <summary>
        /// Gets the ID of the user.
        /// </summary>
        public long UserId { get; internal set; }

        /// <summary>
        /// Gets the screen name of the user.
        /// </summary>
        public string ScreenName { get; internal set; }

    }

}