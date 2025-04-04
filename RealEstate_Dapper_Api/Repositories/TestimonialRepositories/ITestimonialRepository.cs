﻿using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Dtos.TestimonialDtos;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepositories
{
    public interface ITestimonialRepository
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
        void CreateTestimonial(CreateTestimonialDto createTestimonialDto);
        void DeleteTestimonial(int id);
        void UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto);
        Task<GetByIdTestimonialDto> GetTestimonial(int id);
    }
}
