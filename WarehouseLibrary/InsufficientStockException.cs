//-----------------------------------------------------------------------
// <copyright file="InsufficientStockException.cs" company="Sprocket Enterprises">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace WarehouseLibrary
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represent an exception that is thrown if a product is attempted to be taken out of stock that does not exist.
    /// </summary>
    public class InsufficientStockException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InsufficientStockException"/> class.
        /// </summary>
        public InsufficientStockException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InsufficientStockException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public InsufficientStockException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InsufficientStockException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="inner">The inner exception.</param>
        public InsufficientStockException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InsufficientStockException"/> class.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The streaming context.</param>
        public InsufficientStockException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
