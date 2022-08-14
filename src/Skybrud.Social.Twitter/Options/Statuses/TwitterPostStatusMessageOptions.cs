using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;
using Skybrud.Essentials.Maps;

namespace Skybrud.Social.Twitter.Options.Statuses {

    /// <summary>
    /// Class with options for posting a new status message (tweet) to the Twitter API.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/post-statuses-update</cref>
    /// </see>
    public class TwitterPostStatusMessageOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the text of the status message.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the ID of the status message to reply to.
        /// </summary>
        public long ReplyTo { get; set; }

        /// <summary>
        /// If you upload tweet media that might be considered sensitive content such as nudity, violence, or medical
        /// procedures, you should set this value to <c>true</c>.
        /// </summary>
        public bool IsPossiblySensitive { get; set; }

        /// <summary>
        /// Gets or sets the latitude of the location this tweet refers to. This parameter will be ignored unless it is
        /// inside the range <c>-90.0</c> to <c>+90.0</c> (North is positive) inclusive. It will also be ignored if
        /// there isn’t a corresponding <see cref="Longitude"/> property.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude of the location this tweet refers to. The valid ranges for longitude is
        /// <c>-180.0</c> to <c>+180.0</c> (East is positive) inclusive. This parameter will be ignored if outside that
        /// range, if it is not a number, if <c>geo_enabled</c> is disabled, or if there not a corresponding
        /// <see cref="Latitude"/> property.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Gets or sets the ID for a place in the world.
        /// </summary>
        public string PlaceId { get; set; }

        /// <summary>
        /// Gets or sets whether or not to put a pin on the exact coordinates a tweet has been sent from.
        /// </summary>
        public bool DisplayCoordinates { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public TwitterPostStatusMessageOptions() { }

        /// <summary>
        /// Initializes a new instanced based on the specified <paramref name="status"/>.
        /// </summary>
        /// <param name="status">The text of the status message.</param>
        public TwitterPostStatusMessageOptions(string status) {
            Status = status;
        }

        /// <summary>
        /// Initializes a new instanced based on the specified <paramref name="status"/>.
        /// </summary>
        /// <param name="status">The text of the status message.</param>
        /// <param name="replyTo">The ID of the status message which this status message should be a reply to.</param>
        public TwitterPostStatusMessageOptions(string status, long replyTo) {
            Status = status;
            ReplyTo = replyTo;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            // Validate required properties
            if (string.IsNullOrWhiteSpace(Status)) throw new PropertyNotSetException(nameof(Status));

            // Initialize a new instance with required parameters
            IHttpPostData data = new HttpPostData();
            data.Set("status", Status);

            // Append optional parameters to be POST data
            if (ReplyTo > 0) data.Add("in_reply_to_status_id", ReplyTo);
            if (IsPossiblySensitive) data.Add("possibly_sensitive", "true");
            if (!PointUtils.IsNullIsland(Latitude, Longitude)) {
                data.Add("lat", Latitude);
                data.Add("long", Longitude);
            }
            if (PlaceId != null) data.Add("place_id", PlaceId);
            if (DisplayCoordinates) data.Add("display_coordinates", "true");

            // Initialize a new GET request
            return HttpRequest.Post("/1.1/statuses/update.json", null, data);

        }

        #endregion

    }

}