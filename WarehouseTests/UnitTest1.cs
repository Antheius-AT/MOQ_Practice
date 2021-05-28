using NUnit.Framework;
using WarehouseLibrary;

namespace WarehouseTests
{
    public class Tests
    {
        [Test]
        public void Does_Order_Fill_Actually_Fill_Order_When_Called_Successfully()
        {
            var order = new Order("Plastikvagina", 5);
            var warehouse = new NotAtAllAnAmazonWarehouse();
            warehouse.AddStock("Plastikvagina", 100);

            var before = order.IsFilled;
            order.Fill(warehouse);
            var after = order.IsFilled;

            Assert.That(!before && after);
        }

        [Test]
        public void Does_Order_Fill_Decrease_Stock_In_Warehouse()
        {
            var order = new Order("Brezel", 4);
            var warehouse = new NotAtAllAnAmazonWarehouse();
            warehouse.AddStock("Brezel", 5);

            var before = warehouse.CurrentStock("Brezel");
            order.Fill(warehouse);
            var after = warehouse.CurrentStock("Brezel");

            Assert.That(before == 5 && after == 5 - 4);
        }

        [Test]
        public void Does_Order_Fill_Throw_Exception_If_Order_Already_Filled()
        {
            var order = new Order("Test", 100);
            var warehouse = new NotAtAllAnAmazonWarehouse();
            warehouse.AddStock("Test", 100);

            order.Fill(warehouse);

            Assert.Throws<OrderAlreadyFilledException>(() =>
            {
                order.Fill(warehouse);
            });
        }

        [Test]
        public void Does_CanFillOrder_Return_Whether_Ordedr_Can_Be_Filled()
        {
            var order = new Order("Wein", 50);
            var warehouse = new NotAtAllAnAmazonWarehouse();
            warehouse.AddStock("Wein", 50);

            Assert.That(order.CanFillOrder(warehouse));
        }

        [Test]
        public void Does_Current_Stock_Throw_If_Product_Nane_Is_Unknown()
        {
            var warehouse = new NotAtAllAnAmazonWarehouse();

            Assert.Throws<NoSuchProductException>(() =>
            {
                warehouse.CurrentStock("Windeln");
            });
        }

        [Test]
        public void Does_Add_Stock_Actually_Add_Stock_In_Warehouse()
        {
            var warehouse = new NotAtAllAnAmazonWarehouse();

            warehouse.AddStock("Windeln", 5);
            var after = warehouse.CurrentStock("Windeln");

            Assert.That(after == 5);
        }

        [Test]
        public void Does_Add_Stock_Add_Stock_If_Product_Is_Already_Known()
        {
            var warehouse = new NotAtAllAnAmazonWarehouse();

            warehouse.AddStock("Paintballmarkierer", 10);

            var before = warehouse.CurrentStock("Paintballmarkierer");

            warehouse.AddStock("Paintballmarkierer", 20);

            var after = warehouse.CurrentStock("Paintballmarkierer");

            Assert.That(before == 10 && after == 10 + 20);
        }

        [Test]
        public void Does_Warehouse_HasProduct_Return_Whether_Warehouse_Has_Product()
        {
            var warehouse = new NotAtAllAnAmazonWarehouse();

            var doesNotHave = warehouse.HasProduct("Reliefpfeiler");

            warehouse.AddStock("Reliefpfeiler", 1);

            var doesNowHave = warehouse.HasProduct("Reliefpfeiler");

            Assert.That(!doesNotHave && doesNowHave);
        }

        [Test]
        public void Does_Warehouse_HasProduct_Return_True_Even_If_Warehouse_Is_Out_Of_Stock()
        {
            var warehouse = new NotAtAllAnAmazonWarehouse();

            warehouse.AddStock("Pfeiler", 5);
            warehouse.TakeStock("Pfeiler", 5);

            Assert.That(warehouse.HasProduct("Pfeiler"));
        }

        [Test]
        public void Does_Take_Stock_Actually_Remove_Stock()
        {
            var warehouse = new NotAtAllAnAmazonWarehouse();

            warehouse.AddStock("Bier", 10);

            warehouse.TakeStock("Bier", 9);

            Assert.That(warehouse.CurrentStock("Bier") == 1);
        }

        [Test]
        public void Does_Take_Stock_Throw_For_Unknown_Item()
        {
            var warehouse = new NotAtAllAnAmazonWarehouse();

            Assert.Throws<NoSuchProductException>(() =>
            {
                warehouse.CurrentStock("Bertl");
            });
        }

        [Test]
        public void Does_TAke_Stock_Throw_For_Insufficient_Stock()
        {
            var warehouse = new NotAtAllAnAmazonWarehouse();

            warehouse.AddStock("Furzmaschine", 1337);

            Assert.Throws<InsufficientStockException>(() =>
            {
                warehouse.TakeStock("Furzmaschine", 2000);
            });
        }
    }
}