using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ServiceDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ServiceServices
{
    public class ServiceService : IServiceService
    {
        private readonly IMongoCollection<Service> _ServiceCollection;
        private readonly IMapper _mapper;

        public ServiceService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _ServiceCollection = database.GetCollection<Service>(_databaseSettings.ServiceCollectionName);
            _mapper = mapper;
        }

        public async Task CreateServiceAsync(CreateServiceDto createServiceDto)
        {
            var value = _mapper.Map<Service>(createServiceDto);
            await _ServiceCollection.InsertOneAsync(value);
        }

        public async Task DeleteServiceAsync(string id)
        {
            await _ServiceCollection.DeleteOneAsync(x => x.ServiceId == id);
        }

        public async Task<List<ResultServiceDto>> GetAllServicesAsync()
        {
            var values = await _ServiceCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultServiceDto>>(values);
        }

        public async Task<GetByIdServiceDto> GetByIdServiceAsync(string id)
        {
            var value = await _ServiceCollection.Find<Service>(x => x.ServiceId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdServiceDto>(value);
        }

        public async Task UpdateServiceAsync(UpdateServiceDto updateServiceDto)
        {
            var values = _mapper.Map<Service>(updateServiceDto);
            await _ServiceCollection.FindOneAndReplaceAsync(x => x.ServiceId == updateServiceDto.ServiceId, values);
        }
    }
}
