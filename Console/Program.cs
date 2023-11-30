using Business.Constants;
using Businnes.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI;

internal class Program
{
    static void Main(string[] args)
    {

        CarManager carManager = new CarManager(new EfCarDal());

        var result = carManager.GetCarDetails();

        if (result.Success==true)
        {
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName + "/" + car.ColorName);

            }

        }
        else
        {

            Console.WriteLine(result.Message);
        }

        //foreach (var car in carManager.GetCarDetails().Data)
        //{
        //    Console.WriteLine(car.CarName + "/" + car.ColorName);
        //}


        //Car car = new Car();


        //car.Name = "Ford Yenilenmedi";
        //car.DailyPrice = 500;
        //car.BrandId = 1;
        //car.ModelYear = 2023;
        //car.ColorId = 3;
        //car.Description = "Kırmızı";

        //carManager.Add(car);







        //foreach (var car1 in carManager.GetCarsByBrandId(1))
        //{
        //    Console.WriteLine(car1.Name);
        //}

        ////foreach (var car1 in carManager.GetCarsByColorId(3))
        ////{
        ////    Console.WriteLine(car1.Name);
        ////}




        //BrandManager brandManager = new BrandManager(new EfBrandDal());
        //foreach (var brand1 in brandManager.GetAll())
        //{
        //    Console.WriteLine(brand1.Name);
        //}


        //ColorManager manager = new ColorManager(new EfColorDal());
        //foreach (var color in manager.GetAll())
        //{
        //    Console.WriteLine(color.Name);


        //}



    }
}