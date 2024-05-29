using AutomobileCatalog.Common;
using AutomobileCatalog.Models.ModelsDto;

namespace AutomobileCatalog.Core.CoreInterface
{
    public interface IBrandsCore
    {
        Task<Response<int>> AddBrandAsync(BrandsDto brandDto);
    }
}
