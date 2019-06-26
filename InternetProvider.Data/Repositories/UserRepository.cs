using AutoMapper;
using InternetProvider.Logic.DTO;
using InternetProvider.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetProvider.Data.Repositories
{
    public class UserRepository : IRepository<UserDTO>
    {
        private readonly InetContext _context;
        private readonly IMapper _mapper;

        public UserRepository(InetContext ctx, IMapper mapper)
        {
            _context = ctx;
            _mapper = mapper;
        }
        public void Create(UserDTO item)
        {
        }

        public void Delete(string id)
        {
            
        }

        public UserDTO Get(string id)
        {
            return _mapper.Map<UserDTO>(_context.Users.Find(id));
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var users = _context.Users.ToList();
            var dtos = _mapper.Map<IEnumerable<UserDTO>>(users);
            return dtos;
        }

        public void Update(UserDTO item)
        {
            
        }
    }
}
