using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Aspects.ExceptionHandling;
using MultiShop.Catalog.Entities.Base;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.BaseService
{
    public class BaseMongoService<TCollection,TResultDto, TCreateDto, TUpdateDto, TGetByIdDto,TDomain>
        :IBaseService<TResultDto,TCreateDto,TUpdateDto,TGetByIdDto>
        where TCollection:BaseMongoEntity
    {
        private readonly IMongoCollection<TCollection> _collection;
        private readonly IMapper _mapper;
        private readonly DomainExceptionRegistery _exceptionRegistery;
        private readonly Type _domainType;


        public BaseMongoService(IDatabaseSettings databaseSettings,
            string collectionName, IMapper mapper, 
            DomainExceptionRegistery exceptionRegistery, Type domainType)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<TCollection>(collectionName);
            _mapper = mapper;
            _exceptionRegistery = exceptionRegistery;
            _domainType = domainType;
        }

        protected Exception GetDomainException(string methodName)
        {
            var map = _exceptionRegistery.GetExceptionMap<TDomain>();
            Type exceptionType = methodName switch
            {
                nameof(GetByIdAsync) => map.NotFoundException,
                nameof(CreateAsync) => map.CreateFailedException,
                nameof(UpdateAsync) => map.UpdateFailedException,
                nameof(DeleteAsync) => map.DeleteFailedException,
                nameof(GetAllAsync) => map.GetFailedException,
                _ => typeof(Exception)
            };

            return (Exception)Activator.CreateInstance(exceptionType)!;
        }

        public async Task CreateAsync(TCreateDto createDto)
        {
            var value = _mapper.Map<TCreateDto,TCollection>(createDto);
            await _collection.InsertOneAsync(value);
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                var value = await GetByIdAsync(id);
                await _collection.DeleteOneAsync(id);
            }

            catch(Exception ex)
            {
                throw GetDomainException(nameof(DeleteAsync));
            }
           

           
        }

        public async Task<List<TResultDto>> GetAllAsync()
        {
            try
            {
                var values = await _collection.Find(x => true).ToListAsync();
                return _mapper.Map<List<TResultDto>>(values);
            }

            catch(Exception ex) 
            {
                throw GetDomainException(nameof(GetAllAsync));
            }
           
        }

        public async Task<TGetByIdDto> GetByIdAsync(string id)
        {
            var value = await _collection.Find(x => x.ID == id).FirstOrDefaultAsync();

            if (value == null)
            {
                throw GetDomainException(nameof(GetByIdAsync));
            }

            return _mapper.Map<TGetByIdDto>(value);
        }

        public async Task UpdateAsync(TUpdateDto updateDto)
        {
            try
            {
                var updateValue = _mapper.Map<TUpdateDto, TCollection>(updateDto);
                var existValue = await GetByIdAsync(updateValue.ID);

                await _collection.FindOneAndReplaceAsync(x => x.ID == updateValue.ID,
                    updateValue);
            }

            catch(Exception ex)
            {
                throw GetDomainException(nameof(UpdateAsync));
            }
            
        }
    }
}
