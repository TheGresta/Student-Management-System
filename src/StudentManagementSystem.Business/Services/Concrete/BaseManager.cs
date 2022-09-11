using Core.DataAccess;
using Core.Dto;
using Core.Entity;
using Core.Exceptions;
using Core.Paging;
using Core.Utilities.Message;
using Core.Utilities.Result;
using Mapster;
using Microsoft.EntityFrameworkCore.Query;
using StudentManagementSystem.Business.Services.Abstract;
using System.Linq.Expressions;

namespace StudentManagementSystem.Business.Services.Concrete
{
    public class BaseManager<TEntity, TWriteDto, TReadDto> :  IBaseService<TEntity, TWriteDto, TReadDto>
        where TEntity : BaseEntity, new()
        where TWriteDto : class, IWriteDto ,new()
        where TReadDto : class, IReadDto, new()
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly ILanguageMessage _languageMessage;

        public BaseManager(IRepository<TEntity> repository, ILanguageMessage languageMessage)
        {
            _languageMessage = languageMessage;
            _repository = repository;
        }

        public async virtual Task<DataResult<TReadDto>> AddAsync(TWriteDto writeDto)
        {
            TEntity entity = writeDto.Adapt<TEntity>();
            TEntity addedEntity = await _repository.AddAsync(entity);

            if (addedEntity != null)
                throw new BusinessException(_languageMessage.FailureAdd);

            return new SuccessDataResult<TReadDto>(addedEntity.Adapt<TReadDto>(), _languageMessage.SuccessAdd);
        }

        public async virtual Task<DataResult<TReadDto>> DeleteAsync(int id)
        {
            TEntity entity = await _repository.GetAsync(x => x.Id == id);
            
            if(entity == null)
                throw new BusinessException(_languageMessage.FailureDelete);

            TEntity deletedEntity = await _repository.DeleteAsync(entity);

            if (deletedEntity == null)
                throw new BusinessException(_languageMessage.FailureDelete);

            return new SuccessDataResult<TReadDto>(deletedEntity.Adapt<TReadDto>(), _languageMessage.SuccessDelete);
        }

        public async virtual Task<DataResult<TReadDto>> GetByIdAsync(int id)
        {
            IPaginate<TEntity> entity = await _repository.GetAllAsync(x => x.Id == id);

            if (entity == null)
                throw new BusinessException(_languageMessage.FailureGet);

            TReadDto readDto = entity.Adapt<TReadDto>();

            return new SuccessDataResult<TReadDto>(readDto, _languageMessage.SuccessGet);
        }        

        public async virtual Task<DataResult<TReadDto>> UpdateAsync(int id, TWriteDto writeDto)
        {
            TEntity updatedEntity = await _repository.GetAsync(x => x.Id == id);

            if (updatedEntity == null)
                throw new BusinessException(_languageMessage.FailureGet);

            writeDto.Adapt(updatedEntity);

            TEntity entity = await _repository.UpdateAsync(updatedEntity);

            if (entity == null)
                throw new BusinessException(_languageMessage.FailureUpdate);

            return new SuccessDataResult<TReadDto>(entity.Adapt<TReadDto>(), _languageMessage.SuccessUpdate);
        }

        public async virtual Task<DataResult<IPaginate<TReadDto>>> GetListAsync(
            Expression<Func<TEntity, bool>>? predicate = null, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, 
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, 
            int index = 0, int size = 10, bool enamleTracking = true, 
            CancellationToken cancellationToken = default)
        {
            IPaginate<TEntity> entities =
                await _repository.GetAllAsync(
                    predicate: predicate, orderBy: orderBy,
                    include: include, index: index, size: size,
                    enamleTracking: enamleTracking,
                    cancellationToken: cancellationToken);

            if (entities == null)
                throw new BusinessException(_languageMessage.FailureGet);

            IPaginate<TReadDto> readDtos = entities.Adapt<IPaginate<TReadDto>>();

            return new SuccessDataResult<IPaginate<TReadDto>>(readDtos, _languageMessage.SuccessGet);
        }
    }
}
