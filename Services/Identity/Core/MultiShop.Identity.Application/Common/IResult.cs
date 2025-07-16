
namespace MultiShop.Identity.Application.Common
{
    public interface IResult
    {
        bool IsSuccess { get; set; }
        string? ErrorMessage { get; set; }
    }
}
