using Core.DTOs.Input;
using Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.Settings;

namespace Core.Interfaces.Message
{
    public interface IMessageRepository
    {
        void AddMessage(Core.Entities.Message message);
        void DeleteMessage(Core.Entities.Message message);
        Task<Core.Entities.Message> GetMessage(int id);
        Task<PagedList<MessageDto>> GetMessagesForUser(MessageParams messageParams);
        Task<IEnumerable<MessageDto>> GetMessageThread(string currentUsername, string recipientUsername);
        void AddGroup(Group group);
        void RemoveConnection(Connection connection);
        Task<Connection> GetConnection(string connectionId);
        Task<Group> GetMessageGroup(string groupName);
        Task<Group> GetGroupForConnection(string connectionId);
    }
}
