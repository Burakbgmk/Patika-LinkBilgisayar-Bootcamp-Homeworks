// Dependency Inversion Principle

// ProductService sınıfını alınan database ne olursa olsun(Film ya da Kitap), bu databaselerin implemente ettiği arabirimleri ProductService sınıfının oluşturucusu içinde parametre olarak aldığımız zaman, bu sınıflar arası bağlılığı ters yöne çevirmiş oluyoruz. Bu sayede ProductService sınıfına dokunmadan, Main sınıfı içerisinde hangi database i parametre olarak verirsek onu kullanabilmiş oluyoruz.

namespace DependencyInversionExample
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            IProductDB bookDB = new BookDB();
            IProductDB movieDB = new MovieDB();
            ProductService BookService = new ProductService(bookDB);
            ProductService MovieService = new ProductService(movieDB);

            Console.WriteLine(string.Join(",", BookService.GetProducts()));
            Console.WriteLine(string.Join(",", MovieService.GetProducts()));

        }
    }
}