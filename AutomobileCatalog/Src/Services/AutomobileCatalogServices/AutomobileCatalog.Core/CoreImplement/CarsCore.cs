using AutomobileCatalog.Common;
using AutomobileCatalog.Core.CoreInterface;
using AutomobileCatalog.Models.Models;
using AutomobileCatalog.Models.ModelsDto;
using AutomobileCatalog.UnitOfWork;

namespace AutomobileCatalog.Core.CoreImplement
{
    public class CarsCore : ICarsCore
    {
        private readonly IUnitOfWork _unitOfWork; 

        public CarsCore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<int>> AddCarAsync(CarsDto carDto)
        {
            var response = new Response<int>();

            try
            {
                var brand = await _unitOfWork.BrandsRepository.GetBrandByIdAsync(carDto.BrandId);
                if (brand == null)
                {
                    response.IsSuccess = false;
                    response.Message = "La marca especificada no existe.";
                    return response;
                }

                var car = new Cars
                {
                    Id = carDto.Id,
                    Modelo = carDto.Modelo,
                    Descripcion = carDto.Descripcion,
                    Precio = carDto.Precio,
                    Kilometraje = carDto.Kilometraje,
                    BrandId = carDto.BrandId,
                    Brands = brand
                };

                response.Data = await _unitOfWork.CarsRepository.AddCarAsync(car);

                if(response.Data == 0)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro éxitoso";
                }
            }
            catch (Exception ex)
            {
                response.Message += ex.Message;
            }
            return response;
        }

        public Task<Response<CarsDto>> GetCarById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
