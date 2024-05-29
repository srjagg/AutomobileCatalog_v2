using AutomobileCatalog.Common;
using AutomobileCatalog.Models.ModelsDto;

namespace AutomobileCatalog.Core.CoreInterface
{
    public interface ICarsCore
    {
        Task<Response<int>> AddCarAsync(CarsDto foodDto);
        Task<Response<CarsDto>> GetCarById(int id);
    }
}
