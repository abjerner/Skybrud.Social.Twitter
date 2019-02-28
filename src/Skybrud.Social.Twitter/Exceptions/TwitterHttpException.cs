using System;
using Skybrud.Essentials.Http;

namespace Skybrud.Social.Twitter.Exceptions {

    /// <summary>
    /// Exception class representing an error received from the Twitter API.
    /// </summary>
    public class TwitterHttpException : Exception {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <see cref="IHttpResponse"/>.
        /// </summary>
        public IHttpResponse Response { get; }

        /// <summary>
        /// Gets the error code received from the Twitter API. Not all errors have an error code.
        /// </summary>
        public int Code { get; }

        #endregion

        #region Constructors

        internal TwitterHttpException(IHttpResponse response, string message) : base(message) {
            Response = response;
        }

        internal TwitterHttpException(IHttpResponse response, string message, int code) : base(message) {
            Response = response;
            Code = code;
        }

        #endregion

    }

}