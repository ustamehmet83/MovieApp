using LinqSamples.Data;

namespace LINQSamples
{

    class ProductModel
    {

        public string Name { get; set; }
        public decimal? Price { get; set; }



    }

    class Program

    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindContext())
            {
                // var products = db.Products.Select(p => new { p.ProductName, p.UnitPrice }).ToList();
                //var products = db.Products.Select(p =>
                //new ProductModel
                //{
                //    Name = p.ProductName,
                //    Price = p.UnitPrice
                //}).ToList();

                //Tüm müşteri bilgilerinin getiriniz(Customers)

                var customer = db.Customers.ToList();

                foreach (var c in customer)
                {
                    Console.WriteLine(c.ContactName);
                }

                //Tüm müşterilerin sadece CustomerId ve ContactName kolonlarını getiriniz.

                var customer2 = db.Customers.Select(c => new { c.CustomerId, c.ContactName }).ToList();

                foreach (var c in customer)
                {
                    Console.WriteLine(c.CustomerId + ' ' + c.ContactName);
                }
                // Almanya'da yaşayan müşterilerin adlarını getiriniz.

                var customer3 = db.Customers.Select(c => new {c.ContactName,c.Country }).Where(c=>c.Country=="Germany").ToList();

                foreach (var c in customer)
                {
                    Console.WriteLine(c.CustomerId + ' ' + c.ContactName);
                }

                // "Diego Roel" isimli müşteri nerede yaşamaktadır.

                var customer4 = db.Customers.Select(c => new { c.ContactName, c.Country }).Where(c => c.ContactName == "Diego Roel").FirstOrDefault();
                Console.WriteLine(customer4.ContactName + ' ' + customer4.Country);

                // Stokta olmayan ürünler hangileridir?

                var products = db.Products.Select(c => new { c.ProductName,c.UnitsInStock }).Where(c => c.UnitsInStock == 0).ToList();
                foreach (var p in products)
                {
                    Console.WriteLine(p.ProductName );
                }

                // Ürünler tablosundaki ilk 5 kaydı alınız

                var products2 = db.Products.Take(5).ToList();
                foreach (var p in products2)
                {
                    Console.WriteLine(p.ProductName);
                }

                // Ürünler tablosundaki ikinci 5 kaydı alınız

                var products3 = db.Products.Skip(5).Take(5).ToList();
                foreach (var p in products3)
                {
                    Console.WriteLine(p.ProductName);
                }



            }
            Console.ReadLine();

        }
    }



}
