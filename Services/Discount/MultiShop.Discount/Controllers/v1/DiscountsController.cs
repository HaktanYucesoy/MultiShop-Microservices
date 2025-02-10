using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos.Coupon;
using MultiShop.Discount.Dtos.Response;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers.v1
{
    [ApiController]
    [ApiVersion(1)]
    [Route("api/v{version:ApiVersion}/discounts")]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private const string CreateSuccessMessage = "Coupon created successfully";
        private const string GetAllSuccessMessage = "Coupons retrieved successfully";
        private const string GetByIdSuccessMessage = "Coupon retrieved successfully";
        private const string UpdateSuccessMessage = "Coupon updated successfully";
        private const string DeleteSuccessMessage = "Coupon deleted successfully";
        private const int SuccessStatusCode = 200;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon([FromBody] CreateCouponDto createCouponDto)
        {
            var result = await _discountService.CreateCouponAsync(createCouponDto);
            var response = new ResponseDto(CreateSuccessMessage, SuccessStatusCode);
            return StatusCode(SuccessStatusCode, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCoupons()
        {
            var coupons = await _discountService.GetAllCouponsAsync();
            var response = new ResponseDto<List<ResultCouponDto>>(
                coupons,
                GetAllSuccessMessage,
                SuccessStatusCode);
            return StatusCode(SuccessStatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCouponById(string id)
        {
            var coupon = await _discountService.GetByIdCouponAsync(id);
            var response = new ResponseDto<GetByIdCouponDto>(
                coupon,
                GetByIdSuccessMessage,
                SuccessStatusCode);
            return StatusCode(SuccessStatusCode, response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoupon([FromBody] UpdateCouponDto updateCouponDto)
        {
            var result = await _discountService.UpdateCouponAsync(updateCouponDto);
            var response = new ResponseDto(UpdateSuccessMessage, SuccessStatusCode);
            return StatusCode(SuccessStatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoupon(string id)
        {
            var result = await _discountService.DeleteCouponAsync(id);
            var response = new ResponseDto(DeleteSuccessMessage, SuccessStatusCode);
            return StatusCode(SuccessStatusCode, response);
        }
    }
}