using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Skybrud.Social.Twitter.Entities.Formatting;
using Skybrud.Social.Twitter.Models.Entities;
using Skybrud.Social.Twitter.Models.Geocode;

#pragma warning disable CS1591

namespace Skybrud.Social.Twitter {

    /// <summary>
    /// Various utility methods for working with Twitter and the Twitter API.
    /// </summary>
    public class TwitterUtils {

        #region Version

#if NETSTANDARD2_0_OR_GREATER

        /// <summary>
        /// Gets the assembly version as a string.
        /// </summary>
        public static string GetVersion() {
            return typeof(TwitterUtils).Assembly.GetName().Version.ToString();
        }

        /// <summary>
        /// Gets the informational version as a string.
        /// </summary>
        /// <returns></returns>
        public static string GetInformationVersion() {
            Assembly assembly = typeof(TwitterUtils).Assembly;
            return FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
        }

        /// <summary>
        /// Gets the file version as a string.
        /// </summary>
        /// <returns></returns>
        public static string GetFileVersion() {
            Assembly assembly = typeof(TwitterUtils).Assembly;
            return FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
        }

#endif

        #endregion

        /// <summary>
        /// Parses the specified Twitter <paramref name="date"/> into an instance of <see cref="DateTime"/>.
        /// </summary>
        /// <param name="date">The string with the Twitter date.</param>
        /// <returns>An instance of <see cref="DateTime"/>.</returns>
        public static DateTime ParseDateTime(string date) {
            return DateTime.ParseExact(date, "ddd MMM dd HH:mm:ss K yyyy", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Parses the specified Twitter <paramref name="date"/> into an instance of <see cref="DateTime"/> adjusted to <strong>UTC</strong>.
        /// </summary>
        /// <param name="date">The string with the Twitter date.</param>
        /// <returns>An instance of <see cref="DateTime"/>.</returns>
        public static DateTime ParseDateTimeUtc(string date) {
            return DateTime.ParseExact(date, "ddd MMM dd HH:mm:ss K yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
        }

        public static TwitterGranularity ParseGranularity(string str) {
            switch (str.ToLower()) {
                case "neighborhood": return TwitterGranularity.Neighborhood;
                case "poi": return TwitterGranularity.Poi;
                case "city": return TwitterGranularity.City;
                case "admin": return TwitterGranularity.Admin;
                case "country": return TwitterGranularity.Country;
                default: throw new Exception("Unknown granularity \"" + str + "\"");
            }
        }

        #region FormatEntities(...)

        #region TwitterStatusMessageEntities

        public static string FormatEntities(string text, ITwitterEntities entities) {
            return FormatEntities(text, entities.GetAll(), new TwitterDefaultEntityFormatter());
        }

        public static string FormatEntities(string text, ITwitterEntities entities, ITwitterEntityFormatter formatter) {
            return FormatEntities(text, entities.GetAll(), formatter);
        }

        #endregion

        #region TwitterBaseEntity

        public static string FormatEntities(string text, IEnumerable<TwitterBaseEntity> entities) {
            return FormatEntities(text, entities, new TwitterDefaultEntityFormatter());
        }

        public static string FormatEntities(string text, IEnumerable<TwitterBaseEntity> entities, ITwitterEntityFormatter formatter) {

            // Some input validation
            if (string.IsNullOrWhiteSpace(text) || entities == null || formatter == null) return text;

            // Iterate through the entities
            foreach (TwitterBaseEntity entity in entities.OrderByDescending(x => x.StartIndex)) {

                string before = text.Substring(0, entity.StartIndex);
                string current = text.Substring(entity.StartIndex, entity.EndIndex - entity.StartIndex);
                string after = text.Substring(entity.EndIndex);

                string formatted = null;

                TwitterHashTagEntity hashtag = entity as TwitterHashTagEntity;
                TwitterUrlEntity url = entity as TwitterUrlEntity;
                TwitterMentionEntity mention = entity as TwitterMentionEntity;
                TwitterMediaEntity media = entity as TwitterMediaEntity;

                if (hashtag != null) {
                    formatted = formatter.FormatTag(current, hashtag);
                } else if (url != null) {
                    formatted = formatter.FormatUrl(current, url);
                } else if (mention != null) {
                    formatted = formatter.FormatMention(current, mention);
                } else if (media != null) {
                    formatted = formatter.FormatMedia(current, media);
                }

                if (formatted != null) text = before + formatted + after;

            }

            return text;

        }

        #endregion

        #endregion

    }

}