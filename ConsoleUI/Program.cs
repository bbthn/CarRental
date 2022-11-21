using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager cm = new CarManager(new EfCarDal());
            BrandManager bm = new BrandManager(new EfBrandDal());
            ColorManager clm = new ColorManager(new EfColorDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManger = new CustomerManager(new EfCustomerDal());



            List<Brand> brandList = new List<Brand>
            {
                new Brand{BrandName="Renault"},
                new Brand{BrandName="Ford"},
                new Brand{BrandName="BMW"}
            };
            List<Color> colorList = new List<Color>
            {
                new Color{ColorName="Turuncu"},
                new Color{ColorName="Siyah"}
            };
            List<Car> carList = new List<Car>
            {
                new Car{ BrandId=2,ColorId=3,ModelYear=2003,DailyPrice=13214,Description="Sıfır tadında"},
                new Car{ BrandId=3,ColorId=1,ModelYear=2011,DailyPrice=13214,Description="Sıfır tadında"},
                new Car{ BrandId=4,ColorId=2,ModelYear=2015,DailyPrice=888,Description="Sıfır tadında"},
                new Car{ BrandId=1,ColorId=2,ModelYear=2022,DailyPrice=55532,Description="Sıfır tadında"},
            };

            User user = new User { FirstName = "Batuhan", LastName = "Batumlu", Email = "bbgma", Password = "12345" };
            Customer customer = new Customer { UserId = 3, CompanyName = "YapıKredi"};
            Rental rental = new Rental { CarId = 2, CustomerId = 8, RentDate = DateTime.Now, ReturnDate = new DateTime(2022, 12, 13, 12, 00, 00, 00) };

            //userManager.Add(user);
            //customerManger.Add(customer);
            rentalManager.Add(rental);

            foreach (var item in rentalManager.GetAll().Data)
            {
                Console.WriteLine(item.RentDate);

            }

            

            //foreach (var item in brandList)
            //{
            //    bm.Add(item);

            //}
            //foreach (var item in colorList)
            //{
            //    clm.Add(item);

            //}

            //foreach (var item in carList)
            //{
            //    cm.Add(item);

            //}

            //foreach (var item in cm.GetCarsBrandId(1))
            //{
            //    Console.WriteLine("{0} {1} {2} {3} ",item.Description,item.DailyPrice,item.ColorId,item.CarId);

            //}

        }
    }
}
