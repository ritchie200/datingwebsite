using Core.Entities;
using Core.Entities.Settings;
using Core.Interfaces.Like;
using Core.Interfaces.Message;
using Core.Interfaces.User;
using System;
using System.Threading.Tasks;

namespace Core.Interfaces.Setting
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IMessageRepository MessageRepository { get; }
        ILikesRepository LikesRepository { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}
