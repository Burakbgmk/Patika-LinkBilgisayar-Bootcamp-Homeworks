// Liskov's Substitution Principle

// Ana sınıf olan vehicle sınıfı; Car, Motorcycle, Boat ve Plane sınıflarına kalıtım veriyor. Bunu yaparken kalıtım alan sınıflar, ana vehicle sınıfının tüm özelliklerini kullanıyor. Öyle ki Forwards metodu tüm araçlarda kullanırken, hepsinin kullanamadığı Backwards metodu bir arabirim olan ICanGoBackwards ile bu özelliği kullanabilen sınıflara sağlanıyor.
// Bu sayede Liskov's Substitution Prensibinin söylediği; kalıtım alan tüm sınıflar, kalıtım aldıkları sınıfın tüm özelliklerini alarak, kalıtım alan bu sınıfların yer değişebilir olma özelliği sağlanıyor.

// Open Closed Principle

// TripTimeCalculator ve SpeedCalculator sınıflarının aldığı parametreler, Vehicle sınıfı ve bu sınıfın kalıtım verdiği tüm sınıflar tarafından belirlendiği için yeni bir araç sınıfı eklendiğinde bu sınıflarda değişiklik yapılma ihtiyacı ortadan kalkıyor.
// Bu sayede Open Closed Prensibinin söylediği; varolan koda dokunmadan geliştirme yapılması özelliği sağlanmış oldu.

// Interface Segragetion Principle

// Motorcycle ve Car sınıflarının karada gitme özelliğini veren IGrounded arabirimini IGroundedRidable şeklinde de ayırıp, tek bir genel arabirim yerini iki tane özelleşmiş arabirim kullanarak bu prensibi sağlamış oluyoruz.


namespace OpenClosed_Liskov_InterfaceSegregationExample
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            double tripDistance = 20;
            Boat boat = new Boat();
            Car car = new Car();
            Motorcycle motorcycle = new Motorcycle();
            Plane plane = new Plane();
            boat.Float();
            CalculateTripTime(tripDistance,CalculateSpeed(boat));
            car.DrivingOnRoad();
            CalculateTripTime(tripDistance, CalculateSpeed(car));
            motorcycle.RidingOnRoad();
            CalculateTripTime(tripDistance, CalculateSpeed(motorcycle));
            plane.Fly();
            CalculateTripTime(tripDistance, CalculateSpeed(plane));

        }

        public static double CalculateSpeed(Vehicle vehicle)
        {
            var speedCalculator = new SpeedCalculator();
            var speed = speedCalculator.Calculate(vehicle);
            Console.WriteLine($"Speed of vehicle is {speed}");
            return speed;
        }

        public static void CalculateTripTime(double tripDistance, double speed)
        {
            var tripTimeCalculator = new TripTimeCalculator();
            var time = tripTimeCalculator.Calculate(tripDistance, speed);
            Console.WriteLine($"Trip time is {time}");
        }

    }



}
