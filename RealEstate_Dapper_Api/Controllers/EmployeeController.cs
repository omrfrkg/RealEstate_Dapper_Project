using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Repositories.EmployeeRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeRepository _employeRepository;

        public EmployeeController(IEmployeRepository employeRepository)
        {
            _employeRepository = employeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeList()
        {
            var values = await _employeRepository.GetAllEmployee();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            await _employeRepository.CreateEmployee(createEmployeeDto);
            return Ok("Personel Başarılı Bir Şekilde Eklendi!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeRepository.DeleteEmployee(id);
            return Ok("Personel Başarılı Bir Şekilde Silindi!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            await _employeRepository.UpdateEmployee(updateEmployeeDto);
            return Ok("Personel Başarılı Bir Şekilde Güncellendi!");

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var values = await _employeRepository.GetEmployee(id);
            return Ok(values);
        }
    }
}
