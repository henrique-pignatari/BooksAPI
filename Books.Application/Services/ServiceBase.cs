using AutoMapper;
using Books.Application.Interfaces;
using Books.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Services
{
    public class ServiceBase<T, R, SendDTO, ReceiveDTO> : IService<SendDTO, ReceiveDTO> where R : INamedEntityRepository<T>
    {
        protected R _repository;
        protected IMapper _mapper;

        public ServiceBase(R repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(ReceiveDTO dto)
        {
            var entity = _mapper.Map<T>(dto);

            if(entity != null)
            {
                await _repository.CreateAsync(entity);
            }
        }

        public async Task<IEnumerable<SendDTO>> GetAll()
        {
            var entities =_repository.GetAll();

            return _mapper.Map<List<SendDTO>>(entities);
        }

        public async Task<SendDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
          
            return _mapper.Map<SendDTO>(entity);
        }

        public async Task<ICollection<SendDTO>> GetByNameAsync(string name, int quantity, int offset)
        {
            var entities = await _repository.GetByNameAsync(name, quantity, offset);

            return _mapper.Map<List<SendDTO>>(entities);
        }

        public async Task RemoveAsync(ReceiveDTO dto)
        {
            var entity = _mapper.Map<T>(dto);

            await _repository.RemoveAsync(entity);
        }

        public async Task UpdateAsync(ReceiveDTO dto)
        {
            var entity = _mapper.Map<T>(dto);

            await _repository.UpdateAsync(entity);
        }
    }
}
