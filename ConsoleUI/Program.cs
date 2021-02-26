using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // ProductTest();
            // CategoryTest();

            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetProductDetails().Data)
            {
                Console.WriteLine("PRODUCT NAME ________ CATEGORY NAME");
                Console.WriteLine(product.ProductName + " __________ " + product.CategoryName);
            }
        }


        // Alttaki fonksiyonlar için Sağ tıkla 
        // Quck Actions and Refactorings 
        // ile oluşturduk.

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetByUnitPrice(40, 100).Data)
            {
                Console.WriteLine(product.ProductName);
                // Console.WriteLine(" : " + product.UnitPrice + " $");
            }
            // ***** YUKARISI 9. DERS ÖNCESİ TESTİ...
        }

    }
}
