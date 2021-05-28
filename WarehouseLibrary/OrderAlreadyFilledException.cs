//-----------------------------------------------------------------------
// <copyright file="OrderAlreadyFilledException.cs" company="Sprocket Enterprises">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace WarehouseLibrary
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// An exception that is thrown if an order that is already filled is attempted to be filled again.
    /// </summary>
    public class OrderAlreadyFilledException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderAlreadyFilledException"/> class.
        /// </summary>
        public OrderAlreadyFilledException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderAlreadyFilledException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public OrderAlreadyFilledException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderAlreadyFilledException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="inner">The inner exception.</param>
        public OrderAlreadyFilledException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderAlreadyFilledException"/> class.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The streaming context.</param>
        public OrderAlreadyFilledException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
