using Business.Constants;
using Businnes.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstact;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businnes.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.Name.Length < 2 && car.DailyPrice < 0)

            {
                return new ErrorResult(Messages.ProdactNameInValid);


            }
            return new SuccessResult(Messages.ProductAdded);



            _carDal.Add(car);

        }

        public IResult Delete(Car car)
        {
            return new SuccessResult();
            _carDal.Delete(car); ////???????????????
        }

        public IDataResult<List<Car>> GetAll()
        {
            //iş kodları

            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);

        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IResult Update(Car car)
        {

            return new SuccessResult();

            _carDal.Update(car);  //????????????????????
        }
    }
}
