using MultiShop.Discount.Dtos.Coupon;
using MultiShop.Discount.Exceptions;

namespace MultiShop.Discount.Services.Decorators
{
    public class LoggingDiscountDecorator : IDiscountService
    {
        private readonly IDiscountService _discountService;
        private readonly ILogger<LoggingDiscountDecorator> _logger;

        public LoggingDiscountDecorator(
            IDiscountService discountService,
            ILogger<LoggingDiscountDecorator> logger)
        {
            _discountService = discountService;
            _logger = logger;
        }

        public async Task<bool> CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            try
            {
                _logger.LogInformation("Creating new coupon {@CouponDetails}", new
                {
                    createCouponDto.Code,
                    createCouponDto.Rate,
                    createCouponDto.IsActive
                });

                var result = await _discountService.CreateCouponAsync(createCouponDto);

                if (result)
                {
                    _logger.LogInformation("Successfully created coupon with code {CouponCode}", createCouponDto.Code);
                }
                else
                {
                    _logger.LogWarning("Failed to create coupon with code {CouponCode}", createCouponDto.Code);
                }

                return result;
            }
            catch (CreateDiscountException ex)
            {
                 
                _logger.LogError(ex.actualException, "Error creating coupon {@CouponDetails}", new
                {
                    createCouponDto.Code,
                    createCouponDto.Rate,
                    createCouponDto.IsActive,
                    ErrorMessage = ex.actualException.Message,
                    StackTrace = ex.actualException.StackTrace
                });
                throw;
            }
        }

        public async Task<bool> DeleteCouponAsync(string couponId)
        {
            try
            {
                _logger.LogInformation("Attempting to delete coupon {CouponId}", couponId);
                var result = await _discountService.DeleteCouponAsync(couponId);

                if (result)
                {
                    _logger.LogInformation("Successfully deleted coupon {CouponId}", couponId);
                }
                else
                {
                    _logger.LogWarning("No coupon found to delete with ID {CouponId}", couponId);
                }

                return result;
            }
            catch (DeleteDiscountException ex)
            {
                _logger.LogError(ex.actualException, "Error deleting coupon {CouponId}", couponId);
                throw;
            }
        }

        public async Task<List<ResultCouponDto>> GetAllCouponsAsync()
        {
            try
            {
                _logger.LogInformation("Retrieving all coupons");
                var coupons = await _discountService.GetAllCouponsAsync();
                _logger.LogInformation("Successfully retrieved {CouponCount} coupons", coupons.Count);
                return coupons;
            }
            catch (GetAllDiscountsException ex)
            {
                _logger.LogError(ex.actualException, "Error retrieving all coupons");
                throw;
            }
        }

        public async Task<GetByIdCouponDto> GetByIdCouponAsync(string couponId)
        {
            try
            {
                _logger.LogInformation("Retrieving coupon with ID {CouponId}", couponId);
                var result = await _discountService.GetByIdCouponAsync(couponId);
                _logger.LogInformation("Successfully retrieved coupon {CouponId}", couponId);
                return result;
            }
            catch (NotFoundDiscountException)
            {
                _logger.LogWarning("No coupon found with ID {CouponId}", couponId);
                throw;
            }
            catch (GetDiscountException ex)
            {
                _logger.LogError(ex.actualException, "Error retrieving coupon with ID {CouponId}", couponId);
                throw;
            }
        }

        public async Task<bool> UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            try
            {
                _logger.LogInformation("Updating coupon {@CouponDetails}", new
                {
                    updateCouponDto.Id,
                    updateCouponDto.Code,
                    updateCouponDto.Rate,
                    updateCouponDto.IsActive
                });

                var result = await _discountService.UpdateCouponAsync(updateCouponDto);

                if (result)
                {
                    _logger.LogInformation("Successfully updated coupon {CouponId}", updateCouponDto.Id);
                }
                else
                {
                    _logger.LogWarning("Failed to update coupon {CouponId}", updateCouponDto.Id);
                }

                return result;
            }
            catch (UpdateDiscountException ex)
            {
                _logger.LogError(ex.actualException, "Error updating coupon {@CouponDetails}", new
                {
                    updateCouponDto.Id,
                    updateCouponDto.Code,
                    updateCouponDto.Rate,
                    updateCouponDto.IsActive,
                    ErrorMessage = ex.actualException.Message,
                    StackTrace = ex.actualException.StackTrace
                });
                throw;
            }
        }
    }

}
