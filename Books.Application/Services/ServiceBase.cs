using AutoMapper;
using Books.Application.Interfaces;
using Books.Domain.Interfaces;
using HashidsNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Books.Application.Services
{
    public class ServiceBase<T, R, SendDTO, ReceiveDTO> : IService<SendDTO, ReceiveDTO> where R : INamedEntityRepository<T>
    {
        protected R _repository;
        protected IMapper _mapper;
        protected readonly IHashids _hashIds;

        public ServiceBase(R repository, IMapper mapper, IHashids hashIds)
        {
            _repository = repository;
            _mapper = mapper;
            _hashIds = hashIds;
        }

        public async Task<SendDTO> CreateAsync(ReceiveDTO dto)
        {
            var entity = _mapper.Map<T>(dto);

            if(entity != null)
            {
                await _repository.CreateAsync(entity);
            }

            return _mapper.Map<SendDTO>(entity);
        }

        public async Task<IEnumerable<SendDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();

            return _mapper.Map<List<SendDTO>>(entities);
        }

        public async Task<SendDTO> GetByIdAsync(string entityId)
        {
            var id = _hashIds.DecodeSingle(entityId);
            var entity = await _repository.GetByIdAsync(id);
          
            return _mapper.Map<SendDTO>(entity);
        }

        public async Task<ICollection<SendDTO>> GetByNameAsync(string name, int quantity, int offset)
        {
            var entities = await _repository.GetByNameAsync(name, quantity, offset);

            return _mapper.Map<List<SendDTO>>(entities);
        }

        public async Task<SendDTO> RemoveAsync(string entityId)
        {
            var id = _hashIds.DecodeSingle(entityId);
            var entity = await _repository.GetByIdAsync(id);

            return _mapper.Map<SendDTO>(await _repository.RemoveAsync(entity));
        }

        public async Task<SendDTO> UpdateAsync(SendDTO dto)
        {
            var entity = _mapper.Map<T>(dto);

            return _mapper.Map<SendDTO>(await _repository.UpdateAsync(entity));
        }
    }
}
