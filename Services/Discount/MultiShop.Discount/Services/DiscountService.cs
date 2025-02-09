using Dapper;
using MultiShop.Discount.Constables.Queries;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos.Coupon;
using MultiShop.Discount.Exceptions;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            try
            {
                string[] fields = ["Code", "Rate", "IsActive", "ValidDate"];
                string[] parameters = ["@code", "@rate", "@isActive", "@validDate"];
                string query = PureSQLQueryCreator.CreateInsertQuery("Coupones", fields, parameters);

                var dynamicParameter = new DynamicParameters();
                dynamicParameter.Add(parameters[0], createCouponDto.Code);
                dynamicParameter.Add(parameters[1], createCouponDto.Rate);
                dynamicParameter.Add(parameters[2], createCouponDto.IsActive);
                dynamicParameter.Add(parameters[3], createCouponDto.IsActive);

                using var connection = _context.CreateConnection();
                var result = await connection.ExecuteAsync(query, dynamicParameter);
                return result > 0;
            }
            catch (Exception e)
            {
                throw new CreateDiscountException(e);
            }
        }

        public async Task<bool> DeleteCouponAsync(string couponId)
        {
            try
            {
                string field = "Id";
                string parameterField = "@id";
                string query = PureSQLQueryCreator.CreateDeleteQuery("Coupones", field, parameterField);

                var dynamicParameter = new DynamicParameters();
                dynamicParameter.Add(parameterField, couponId);

                using var connection = _context.CreateConnection();
                var result = await connection.ExecuteAsync(query, dynamicParameter);
                return result > 0;
            }
            catch (Exception e)
            {
                throw new DeleteDiscountException(e);
            }
        }

        public async Task<List<ResultCouponDto>> GetAllCouponsAsync()
        {
            try
            {
                string query = PureSQLQueryCreator.CreateSelectAllQuery("Coupones");
                using var connection = _context.CreateConnection();
                var result = await connection.QueryAsync<ResultCouponDto>(query);
                return result.ToList();
            }
            catch (Exception e)
            {
                throw new GetAllDiscountsException(e);
            }
        }

        public async Task<GetByIdCouponDto> GetByIdCouponAsync(string couponId)
        {
            try
            {
                string field = "Id";
                string parameterField = "@id";
                string query = PureSQLQueryCreator.CreateSelectById("Coupones", field, parameterField);

                var dynamicParameter = new DynamicParameters();
                dynamicParameter.Add(parameterField, couponId);

                using var connection = _context.CreateConnection();
                var result = await connection.QueryFirstAsync<GetByIdCouponDto>(query, dynamicParameter);

                if (result == null)
                    throw new NotFoundDiscountException();

                return result;
            }
            catch (Exception ex) when (!(ex is NotFoundDiscountException))
            {
                throw new GetDiscountException(ex);
            }
        }

        public async Task<bool> UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            try
            {
                string[] fields = ["Code", "Rate", "IsActive", "ValidDate"];
                string[] parameters = ["@code", "@rate", "@isActive", "@validDate"];
                string[] whereFields = ["Id"];
                string[] parameterFields = ["@id"];

                string query = PureSQLQueryCreator.CreateUpdateQuery("Coupones", fields, parameters, whereFields, parameterFields);

                var dynamicParameter = new DynamicParameters();
                dynamicParameter.Add(fields[0], updateCouponDto.Code);
                dynamicParameter.Add(fields[1], updateCouponDto.Rate);
                dynamicParameter.Add(fields[2], updateCouponDto.IsActive);
                dynamicParameter.Add(fields[3], updateCouponDto.ValidDate);

                using var connection = _context.CreateConnection();
                var result = await connection.ExecuteAsync(query, dynamicParameter);
                return result > 0;
            }
            catch (Exception e)
            {
                throw new UpdateDiscountException(e);
            }
        }
    }
}
