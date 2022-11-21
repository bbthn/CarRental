using Business.Abstract;
using Business.Constants.Path;
using Core.Utilities.Business.BusinessRules;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
        public CarImageManager(ICarImageDal carImageDal,IFileHelper formFile)
        {
            _carImageDal = carImageDal;
            _fileHelper = formFile;

        }
        public IResult add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimited(carImage.CarId));
            if(result != null)
            {
                return result;

            }
            carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagePath);
            carImage.DateTime = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult("Resim basariyla Yuklendi");
        }

        private IResult CheckIfCarImageLimited(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult("Image limit exceeded!");
            }
            return new SuccessResult("İslem Basarili");
        }
    }
}
