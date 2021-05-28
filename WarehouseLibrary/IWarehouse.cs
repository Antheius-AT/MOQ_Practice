//-----------------------------------------------------------------------
// <copyright file="IWarehouse.cs" company="Sprocket Enterprises">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace WarehouseLibrary
{
    using System;

    /// <summary>
    /// Interface representing a warehouse.
    /// </summary>
    public interface IWarehouse
    {
        /// <summary>
        /// Checks whether the warehouse has a product in stock.
        /// </summary>
        /// <param name="product">The product to look for.</param>
        /// <returns>Whether the warehouse stores the product.</returns>
        /// <exception cref="ArgumentException">
        /// Is thrown if the specified product name is null or whitespace.
        /// </exception>
        bool HasProduct(string product);

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
        int CurrentStock(string product);

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
        void AddStock(string product, int amount);

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
        void TakeStock(string product, int amount);
    }
}
