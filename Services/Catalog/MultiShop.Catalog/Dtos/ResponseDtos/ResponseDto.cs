
namespace MultiShop.Catalog.Dtos.ResponseDtos
{
    public record ResponseDto(string Message, int Status);

    public record ResponseDto<T>(T data, string Message, int Status);
    
}
