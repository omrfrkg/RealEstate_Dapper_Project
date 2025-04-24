﻿using Dapper;
using RealEstate_Dapper_Api.Dtos.MessageDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.MessageRepositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxLast3MessageListByReceiver(int id)
        {
            string query = "Select TOP(3) MessageID,Name,Subject,Detail,SendDate,IsRead, UserImageUrl From Message Inner Join AppUser On Message.Sender = AppUser.UserID Where Receiver=@id ORDER BY SendDate Desc";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection()) { 
                var values = await connection.QueryAsync<ResultInboxMessageDto>(query, parameters);
                return values.ToList();
            }

        }
    }
}
