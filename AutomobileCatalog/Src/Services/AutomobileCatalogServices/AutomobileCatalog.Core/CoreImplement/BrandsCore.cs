using AutomobileCatalog.Common;
using AutomobileCatalog.Core.CoreInterface;
using AutomobileCatalog.Models.Models;
using AutomobileCatalog.Models.ModelsDto;
using AutomobileCatalog.UnitOfWork;

namespace AutomobileCatalog.Core.CoreImplement
{
    public class BrandsCore : IBrandsCore
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandsCore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<int>> AddBrandAsync(BrandsDto brandDto)
        {
            var response = new Response<int>();

            try
            {
                var brand = new Brands
                {
                    Nombre = brandDto.Nombre,  
                };

                response.Data = await _unitOfWork.BrandsRepository.AddBrandAsync(brand);

                if (response.Data == 0)
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
    }
}
