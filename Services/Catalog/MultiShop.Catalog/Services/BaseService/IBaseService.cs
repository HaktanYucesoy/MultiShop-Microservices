using MultiShop.Catalog.Dtos.CategoryDtos;

namespace MultiShop.Catalog.Services.BaseService
{
    public interface IBaseService<TResultDto,TCreateDto,TUpdateDto,TGetByIdDto>
    {
        Task<List<TResultDto>> GetAllAsync();

        Task CreateAsync(TCreateDto createDto);

        Task UpdateAsync(TUpdateDto updateDto);

        Task DeleteAsync(string id);

        Task<TGetByIdDto> GetByIdAsync(string id);
    }
}
