using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.BaseService
{
    public class BaseMongoService<TCollection,TResultDto, TCreateDto, TUpdateDto, TGetByIdDto>
        :IBaseService<TResultDto,TCreateDto,TUpdateDto,TGetByIdDto>
        where TCollection:BaseEntity
    {
        private readonly IMongoCollection<TCollection> _collection;
        private readonly IMapper _mapper;


        public BaseMongoService(IDatabaseSettings databaseSettings,
            string collectionName,IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<TCollection>(collectionName);
            _mapper = mapper;
        }

        public async Task CreateAsync(TCreateDto createDto)
        {
            var value = _mapper.Map<TCreateDto,TCollection>(createDto);
            await _collection.InsertOneAsync(value);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(id);
        }

        public async Task<List<TResultDto>> GetAllAsync()
        {
            var values = await _collection.Find(x => true).ToListAsync();
            return _mapper.Map<List<TResultDto>>(values);
        }

        public async Task<TGetByIdDto> GetByIdAsync(string id)
        {
            var value = await _collection.Find(x => x.ID == id).FirstOrDefaultAsync();
            return _mapper.Map<TGetByIdDto>(value);
        }

        public async Task UpdateAsync(TUpdateDto updateDto)
        {
            var updateValue=_mapper.Map<TUpdateDto,TCollection>(updateDto);
            await _collection.FindOneAndReplaceAsync(x => x.ID == updateValue.ID,
                updateValue);
        }
    }
}
