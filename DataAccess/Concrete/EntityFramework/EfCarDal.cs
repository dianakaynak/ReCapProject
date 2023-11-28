using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstact;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, YeniVeriContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        
        {
                using (YeniVeriContext context = new YeniVeriContext())
                {
                    var result = from car in context.Cars
                                 join brand in context.Brands
                                 on car.BrandId equals brand.Id
                                 join color in context.Colors
                                 on car.ColorId equals color.Id


                                 select new CarDetailDto
                                 {
                                     //select brand.BrandName,car.CarName,color.ColorName,car.DailyPrice,Id from cars .....
                                     BrandName = brand.Name,
                                     CarName = car.Name,
                                     ColorName = color.Name,
                                     DailyPrice = car.DailyPrice,
                                     Id = car.Id
                                 };
                    return filter == null
                       ? result.ToList()
                       : result.Where(filter).ToList();


                }



            }
        }
    }


