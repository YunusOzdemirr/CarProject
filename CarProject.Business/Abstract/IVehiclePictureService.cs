using System;
using System.Threading.Tasks;
using CarProject.Entities.Concrete;
using CarProject.Shared.Utilities.Results.Abstract;

namespace CarProject.Business.Abstract
{
    public interface IVehiclePictureService
    {
        Task<IDataResult> CarPictureAddAsync(VehiclePicture carPicture);
        Task<IResult> CarPictureDeleteAsync(int carPictureId);
        Task<IDataResult> BusPictureAddAsync(VehiclePicture busPicture);
        Task<IResult> BusPictureDeleteAsync(int busPictureId);
        Task<IDataResult> BoatPictureAddAsync(VehiclePicture boatPicture);
        Task<IResult> BoatPictureDeleteAsync(int boatPictureId);

    }
}

