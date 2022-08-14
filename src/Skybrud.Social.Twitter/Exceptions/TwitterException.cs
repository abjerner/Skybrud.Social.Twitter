using System;

namespace Skybrud.Social.Twitter.Exceptions {

    /// <summary>
    /// Exception class representing an error related to the implementation in this package.
    /// </summary>
    public class TwitterException : Exception {

        internal TwitterException(string message) : base(message) { }

    }

}