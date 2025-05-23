﻿using Dapper;
using RealEstate_Dapper_Api.Dtos.PropertyAmenityDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PropertyAmenityRepositories
{
    public class PropertyAmenityRepository : IPropertyAmenityRepository
    {
        private readonly Context _context;

        public PropertyAmenityRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultPropertyAmenityByStatusTrueDto>> GetPropertyAmenityByStatusTrue(int id)
        {
            string query = "Select PropertyAmenityID, Title From PropertyAmenity Inner Join Amenity on Amenity.AmenityID = PropertyAmenity.AmenityID Where PropertyID = @id And Status=1";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultPropertyAmenityByStatusTrueDto>(query, parameters);
                return result.ToList();
            }

        }
    }
}
