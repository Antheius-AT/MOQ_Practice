//-----------------------------------------------------------------------
// <copyright file="NoSuchProductException.cs" company="Sprocket Enterprises">
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
    public class NoSuchProductException : Exception
    {
        /// <summary>
        /// Gets the product name associated with this exception.
        /// </summary>
        public readonly string product;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoSuchProductException"/> class.
        /// </summary>
        /// <param name="product">The product associated with the message.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if either of the parameters are null.
        /// </exception>
        public NoSuchProductException(string product)
        {
            this.product = product ?? throw new ArgumentNullException(nameof(product), "Product name must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoSuchProductException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="product">The product associated with the message.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if either of the parameters are null.
        /// </exception>
        public NoSuchProductException(string message, string product) : base(message)
        {
            this.product = product ?? throw new ArgumentNullException(nameof(product), "Product name must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoSuchProductException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="inner">The inner exception.</param>
        /// <param name="product">The product associated with the message.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if either of the parameters are null.
        /// </exception>
        public NoSuchProductException(string message, Exception inner, string product) : base(message, inner)
        {
            this.product = product ?? throw new ArgumentNullException(nameof(product), "Product name must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoSuchProductException"/> class.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The streaming context.</param>
        /// <param name="product">The product associated with the message.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if either of the parameters are null.
        /// </exception>
        public NoSuchProductException(SerializationInfo info, StreamingContext context, string product) : base(info, context)
        {
            this.product = product ?? throw new ArgumentNullException(nameof(product), "Product name must not be null.");
        }
    }
}
