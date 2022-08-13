﻿using System.Net;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Xml.Extensions;
using Skybrud.Social.Twitter.Exceptions;
using Skybrud.Social.Twitter.Models.Common;

namespace Skybrud.Social.Twitter.Responses {

    /// <summary>
    /// Class representing a response from the Twitter API.
    /// </summary>
    public class TwitterResponse : HttpResponseBase {

        #region Properties

        /// <summary>
        /// Gets information about rate limiting.
        /// </summary>
        public TwitterRateLimiting RateLimiting { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        protected TwitterResponse(IHttpResponse response) : base(response) {
            RateLimiting = TwitterRateLimiting.GetFromResponse(response);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Validates the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response to be validated.</param>
        public static void ValidateResponse(IHttpResponse response) {

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;

            string contentType = response.ContentType?.Split(';')[0];

            switch (contentType) {

                case "application/xml":  {

                    // Parse the XML response body
                    XElement xml = XElement.Parse(response.Body);

                    // Get the XML element describing the error
                    XElement error = xml.GetElement("error");

                    // Get the code and error message
                    int code = error.GetAttributeValueAsInt32("code");
                    string message = error.Value;
                    
                    // Throw a new exception
                    throw new TwitterHttpException(response, message, code);

                }

                case "application/json": {
                        
                    JObject obj = ParseJsonObject(response.Body);

                    // For some types of errors, Twitter will only respond with an error message
                    if (obj.HasValue("error")) throw new TwitterHttpException(response, obj.GetString("error"), 0);

                    // However in most cases, Twitter responds with an array of errors
                    JArray errors = obj.GetArray("errors");

                    // Get the first error (don't remember ever seeing multiple errors in the same response)
                    JObject error = errors.GetObject(0);

                    // Throw the exception
                    throw new TwitterHttpException(response, error.GetString("message"), error.GetInt32("code"));

                }

                default:
                    throw new TwitterHttpException(response);

            }
        }

        #endregion

    }

    /// <summary>
    /// Class representing a response from the Twitter API.
    /// </summary>
    public class TwitterResponse<T> : TwitterResponse {

        #region Properties

        /// <summary>
        /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        protected TwitterResponse(IHttpResponse response) : base(response) { }

        #endregion

    }

}