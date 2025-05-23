﻿
using Dapper;
using RealEstate_Dapper_Api.Dtos.ToDoListDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepositories
{
    public class ToDoListRepository : IToDoListRepository
    {

        private readonly Context _context;

        public ToDoListRepository(Context context)
        {
            _context = context;
        }

        public Task CreateToDoList(CreateToDoListDto createToDoListDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteToDoList(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultToDoListDto>> GetAllToDoList()
        {
            string query = "Select * From ToDoList";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultToDoListDto>(query);
                return values.ToList();
            }
        }

        public Task<GetByIdToDoListDto> GetToDoList(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateToDoList(UpdateToDoListDto updateToDoListDto)
        {
            throw new NotImplementedException();
        }
    }
}
