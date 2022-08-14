namespace Skybrud.Social.Twitter.Models.Statuses {

    /// <summary>
    /// Class with information about the status message (tweet) a <see cref="TwitterStatusMessage"/> is a reply to.
    /// </summary>
    public class TwitterReplyTo {

        /// <summary>
        /// Gets the ID of the status message.
        /// </summary>
        public long StatusId { get; internal set; }

        /// <summary>
        /// Gets the ID of the user who posted the status message.
        /// </summary>
        public long UserId { get; internal set; }

        /// <summary>
        /// Gets the screen name of the user who posted the status message.
        /// </summary>
        public string ScreenName { get; internal set; }

    }

}