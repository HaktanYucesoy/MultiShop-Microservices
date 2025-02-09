using MultiShop.Discount.Dtos.Coupon;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {

        Task<List<ResultCouponDto>> GetAllCouponsAsync();

        Task<bool> CreateCouponAsync(CreateCouponDto createCouponDto);

        Task<bool> UpdateCouponAsync(UpdateCouponDto updateCouponDto);

        Task<bool> DeleteCouponAsync(string couponId);

        Task<GetByIdCouponDto> GetByIdCouponAsync(string couponId);
    }
}
