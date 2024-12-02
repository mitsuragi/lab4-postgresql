using lab4_postgresql.Models;

namespace DatabaseTest
{
    [TestClass]
    public class CRUDTests
    {
        [TestMethod]
        public void TestAddProduct()
        {
            using (var db = new StoreDbContext())
            {
                var list = db.Products.ToList();

                db.Products.RemoveRange((from p in list where p.ProductName == "test" select p).ToList());
                db.SaveChanges();

                Product product = new Product
                {
                    ProductName = "test",
                    Price = 10,
                    Quantity = 1,
                    CategoryId = 1
                };

                db.Products.Add(product);
                db.SaveChanges();

                list = db.Products.ToList();

                var prod = (from p in list where p.ProductName == "test" select p).FirstOrDefault();

                Assert.AreEqual(product, prod);

                db.Products.Remove(product);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void TestRemoveProduct()
        {
            using (var db = new StoreDbContext())
            {

                Product product = new Product
                {
                    ProductName = "test",
                    Price = 10,
                    Quantity = 1,
                    CategoryId = 1
                };

                db.Products.Add(product);
                db.SaveChanges();

                db.Products.Remove(product);
                db.SaveChanges();

                var list = db.Products.ToList();

                var prod = list.Select(p => p.ProductName == "test") as Product;

                Assert.IsNull(prod);
            }
        }

        [TestMethod]
        public void TestUpdateProduct()
        {
            using (var db = new StoreDbContext())
            {

                Product product = new Product
                {
                    ProductName = "test",
                    Price = 10,
                    Quantity = 1,
                    CategoryId = 1
                };

                db.Products.Add(product);
                db.SaveChanges();

                product.ProductName = "test1";
                db.Products.Update(product);
                db.SaveChanges();

                var list = db.Products.ToList();

                var prod = (from p in list where p.ProductName == "test" select p).FirstOrDefault();

                Assert.AreNotEqual(product, prod);

                db.Products.Remove(product);
                db.SaveChanges();
            }
        }
    }
}