using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Twitter.Models.Media {

    /// <summary>
    /// Class representing a resized format of a given media.
    /// </summary>
    public class TwitterVideoInfo : TwitterObject {

        #region Properties

        /// <summary>
        /// Gets a 2-element array with the aspect ratio of the video.
        /// </summary>
        public IReadOnlyList<int> AspectRatio { get; }

        /// <summary>
        /// Gets the duration of the video. For animated GIFs a duration won't be specified.
        /// </summary>
        public TimeSpan Duration { get; }

        /// <summary>
        /// Gets whether a duration has been specified for the video.
        /// </summary>
        public bool HasDuration => Duration.TotalMilliseconds > 0;

        /// <summary>
        /// Gets an array of all variants/formats of the video.
        /// </summary>
        public IReadOnlyList<TwitterVideoVariant> Variants { get; }

        #endregion

        #region Constructors

        private TwitterVideoInfo(JObject obj) : base(obj) {
            AspectRatio = obj.GetInt32Array("aspect_ratio");
            Duration = obj.GetDouble("duration_millis", TimeSpan.FromMilliseconds);
            Variants = obj.GetArray("variants", TwitterVideoVariant.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwitterVideoInfo"/> from the specified <see cref="JObject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwitterVideoInfo"/>.</returns>
        public static TwitterVideoInfo Parse(JObject obj) {
            return obj == null ? null : new TwitterVideoInfo(obj);
        }

        #endregion

    }

}