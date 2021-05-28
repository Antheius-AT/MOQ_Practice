//-----------------------------------------------------------------------
// <copyright file="Order.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace WarehouseLibrary
{
    using System;

    /// <summary>
    /// Represents an order to be fulfilled.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// The product to order.
        /// </summary>
        private string product;

        /// <summary>
        /// The amount of this product to order.
        /// </summary>
        private int amount;

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        /// <param name="product">The product to order.</param>
        /// <param name="amount">The amount to order.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Is thrown if you specify an amount less than 1.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Is thrown if the specified product is null, empty or a white space string.
        /// </exception>
        public Order(string product, int amount)
        {
            if (string.IsNullOrWhiteSpace(product))
                throw new ArgumentException(nameof(product), "The product must have a name and can not be white space or null.");

            if (amount < 1)
                throw new ArgumentOutOfRangeException(nameof(amount), "You must at least order one product.");

            this.product = product;
            this.amount = amount;
        }

        /// <summary>
        /// Gets a value indicating whether the order has been filled.
        /// </summary>
        public bool IsFilled
        {
            get;
            private set;
        }

        /// <summary>
        /// Determines whether this order can be filled by the specified warehouse.
        /// </summary>
        /// <param name="warehouse">The warehouse for which to check whether the order can be filled.</param>
        /// <returns>Whether the order can be filled from this warehouse.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if ware house is null.
        /// </exception>
        public bool CanFillOrder(IWarehouse warehouse)
        {
            if (warehouse == null)
                throw new ArgumentNullException(nameof(warehouse), "Warehouse must not be null.");

            return warehouse.HasProduct(this.product) && warehouse.CurrentStock(this.product) >= this.amount;
        }

        /// <summary>
        /// Fills the order using the specified warehouse.
        /// </summary>
        /// <param name="warehouse">The warehouse to fill the order from.</param>
        /// <exception cref="OrderAlreadyFilledException">
        /// Is thrown if the order is already filled.
        /// </exception>
        /// <exception cref="InsufficientStockException">
        /// Is thrown if the order can not be fulfilled with the specified warehouse, because
        /// the warehouse does not have the necessary stock to fulfill the order.
        /// </exception>
        /// <exception cref="NoSuchProductException">
        /// Is thrown if the specified product is not known to the specified warehouse.
        /// </exception>
        public void Fill(IWarehouse warehouse)
        {
            if (warehouse == null)
                throw new ArgumentNullException(nameof(warehouse), "Warehouse to fill order from must not be null.");

            if (this.IsFilled)
                throw new OrderAlreadyFilledException("The order was already filled.");

            warehouse.TakeStock(this.product, this.amount);
        }
    }
}
