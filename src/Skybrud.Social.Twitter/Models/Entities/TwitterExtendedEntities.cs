using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Twitter.Models.Entities {
    
    /// <summary>
    /// Class representing the extended entities property of a status message.
    /// </summary>
    public class TwitterExtendedEntities : TwitterObject {

        #region Properties

        /// <summary>
        /// Gets an array of all media mentioned in the parent status message.
        /// </summary>
        public IReadOnlyList<TwitterMediaEntity> Media { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwitterExtendedEntities"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The <see cref="JObject"/> to be parsed.</param>
        protected TwitterExtendedEntities(JObject obj) : base(obj) {
            Media = obj.GetArrayItems("media", TwitterMediaEntity.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwitterExtendedEntities"/> from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="TwitterExtendedEntities"/>.</returns>
        public static TwitterExtendedEntities Parse(JObject obj) {
            return obj == null ? null : new TwitterExtendedEntities(obj);
        }

        #endregion

    }

}