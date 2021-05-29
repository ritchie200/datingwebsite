using AutoMapper;
using Core.Entities.Settings;
using Core.Interfaces;
using Core.Interfaces.Like;
using Core.Interfaces.Message;
using Core.Interfaces.Setting;
using Core.Interfaces.User;
using Infrastructure.Data;
using Infrastructure.Data.Repositories.Like;
using Infrastructure.Data.Repositories.Settings;
using Infrastructure.Repositories.Message;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Setting
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMapper _mapper;
        private readonly DatingAppDBContext _context;
        public UnitOfWork(DatingAppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IUserRepository UserRepository => new UserRepository(_context, _mapper);

        public IMessageRepository MessageRepository => new MessageRepository(_context, _mapper);

        public ILikesRepository LikesRepository => new LikesRepository(_context);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}
