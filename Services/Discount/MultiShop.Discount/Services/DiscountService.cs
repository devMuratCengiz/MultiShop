using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto)
        {
            string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("code", createDiscountCouponDto.Code);
            parameters.Add("rate", createDiscountCouponDto.Rate);
            parameters.Add("isActive", createDiscountCouponDto.IsActive);
            parameters.Add("validDate", createDiscountCouponDto.ValidDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query = "Delete from Coupons where CouponId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponsAsync()
        {
            string query = "Select * from Coupons";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
        {
            string query = "Select * from Coupons where CouponId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query,parameters);
                return values;
            }
        }

        public async Task<ResultDiscountCouponDto> GetCodeDetailByCodeAsync(string code)
        {
            string query = "Select * from Coupons Where Code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("code", code);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultDiscountCouponDto>(query, parameters);
                return values;
            }
        }

        public int GetDiscountCouponRate(string code)
        {
            string query = "Select Rate from Coupons Where Code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("code", code);
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query, parameters);
                return values;
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto)
        {
            string query = "Update Coupons Set Code = @code,Rate=@rate,IsActive=@isActive,ValidDate =@validDate where CouponId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("code", updateDiscountCouponDto.Code);
            parameters.Add("rate", updateDiscountCouponDto.Rate);
            parameters.Add("isActive", updateDiscountCouponDto.IsActive);
            parameters.Add("validDate", updateDiscountCouponDto.ValidDate);
            parameters.Add("id", updateDiscountCouponDto.CouponId);
            using (var connections = _context.CreateConnection())
            {
                await connections.ExecuteAsync(query, parameters);
            }
        }
    }
}
