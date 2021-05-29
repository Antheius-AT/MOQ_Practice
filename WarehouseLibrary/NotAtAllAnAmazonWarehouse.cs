//-----------------------------------------------------------------------
// <copyright file="NotAtAllAnAmazonWarehouse.cs" company="Sprocket Enterprises">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace WarehouseLibrary
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a warehouse to store items at and receive items from.
    /// </summary>
    public class NotAtAllAnAmazonWarehouse : IWarehouse
    {
        /// <summary>
        /// Dictionary mapping product names to stock amounts.
        /// </summary>
        private Dictionary<string, int> products;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotAtAllAnAmazonWarehouse"/> class.
        /// </summary>
        public NotAtAllAnAmazonWarehouse()
        {
            this.products = new Dictionary<string, int>();
        }

        /// <summary>
        /// Checks whether a certain product is generally stored at the warehouse.
        /// This does nothing to confirm, whether currently there is available stock of this item, it 
        /// just confirms whether the item is usually stored at this warehouse.
        /// </summary>
        /// <param name="product">The product to look for.</param>
        /// <returns>Whether the warehouse stores the product.</returns>
        /// <exception cref="ArgumentException">
        /// Is thrown if the specified product name is null or whitespace.
        /// </exception>
        public bool HasProduct(string product)
        {
            if (string.IsNullOrWhiteSpace(product))
                throw new ArgumentException(nameof(product), "Product must not be null or only consist of white spaces.");
            
            return this.products.ContainsKey(product);
        }

        /// <summary>
        /// Gets the current stock of a certain item.
        /// </summary>
        /// <param name="product">The product to check the warehouse's stock for.</param>
        /// <returns>The stock amount that is stored of the particular item.</returns>
        /// <exception cref="ArgumentException">
        /// Is thrown if the specified product name is null or whitespace.
        /// </exception>
        /// <exception cref="NoSuchProductException">
        /// Is thrown if the product name is not known to the warehouse.
        /// </exception>
        public int CurrentStock(string product)
        {
            if (!this.HasProduct(product))
                throw new NoSuchProductException("The specified product is not known to this warehouse.", product);

            return this.products[product];
        }

        /// <summary>
        /// Adds products to the warehouse.
        /// </summary>
        /// <param name="product">The product to add.</param>
        /// <param name="amount">The amount to add of this product.</param>
        /// <exception cref="ArgumentException">
        /// Is thrown if product name is null or whitespace.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Is thrown if amount is less than 1.
        /// </exception>
        public void AddStock(string product, int amount)
        {
            if (string.IsNullOrWhiteSpace(product))
                throw new ArgumentException(nameof(product), "Product name must not be null or whitespace.");

            if (amount < 1)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount to add must be greater than 0");

            if (this.HasProduct(product))
                this.products[product] += amount;
            else
                this.products.Add(product, amount);
        }

        /// <summary>
        /// Removes products from the warehouse.
        /// </summary>
        /// <param name="product">The product to add.</param>
        /// <param name="amount">The amount to add of this product.</param>
        /// <exception cref="ArgumentException">
        /// Is thrown if product name is null or whitespace.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Is thrown if amount is less than 1.
        /// </exception>
        ///  /// <exception cref="NoSuchProductException">
        /// Is thrown if the product name is not known to the warehouse.
        /// </exception>
        /// <exception cref="InsufficientStockException">
        /// Is thrown if the requested amount exceeds the stock stored of the specified product.
        /// </exception>
        public void TakeStock(string product, int amount)
        {
            if (string.IsNullOrWhiteSpace(product))
                throw new ArgumentException(nameof(product), "Product name must not be null or whitespace.");

            if (amount < 1)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount to add must be greater than 0");

            if (!this.HasProduct(product))
                throw new NoSuchProductException("The specified product is not known to this warehouse", product);

            if (this.CurrentStock(product) < amount)
                throw new InsufficientStockException("Insufficient stock to honor request.");

            this.products[product] -= amount;
        }
    }
}
