using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Twitter.Options.Statuses {

    /// <summary>
    /// Class with options for posting a new status message (tweet) to the Twitter API.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/post-statuses-update</cref>
    /// </see>
    public class TwitterPostStatusMessageOptions : IHttpPostOptions {

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

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpQueryString"/>.</returns>
        public IHttpQueryString GetQueryString() {
            return null;
        }

        /// <summary>
        /// Gets an instance of <see cref="IHttpPostData"/> representing the POST parameters.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpPostData"/>.</returns>
        public IHttpPostData GetPostData() {

            // Validate required properties
            if (String.IsNullOrWhiteSpace(Status)) throw new PropertyNotSetException(nameof(Status));

            // Initialize a new instance with required parameters
            IHttpPostData data = new HttpPostData();
            data.Set("status", Status);

            // Append optional parameters to be POST data
            if (ReplyTo > 0) data.Add("in_reply_to_status_id", ReplyTo);
            if (IsPossiblySensitive) data.Add("possibly_sensitive", "true");
            if (Math.Abs(Latitude) > Double.Epsilon && Math.Abs(Longitude) > Double.Epsilon) {
                data.Add("lat", Latitude);
                data.Add("long", Longitude);
            }
            if (PlaceId != null) data.Add("place_id", PlaceId);
            if (DisplayCoordinates) data.Add("display_coordinates", "true");

            return data;

        }
    
    }

}