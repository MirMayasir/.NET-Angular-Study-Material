using Microsoft.Extensions.Options;
using MilestoneAssessment3.Models;
using MongoDB.Driver;
using MongoDB.Driver.Core.Operations.ElementNameValidators;

namespace MilestoneAssessment3.Services
{
    
    public class userprofileServices
    {

        private readonly IMongoCollection<UserProfile> _context;

        public userprofileServices(IOptions<GymDatabase> database)
        {
            var mongoClient = new MongoClient(database.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(
                database.Value.DatabaseName );
            _context = mongoDatabase.GetCollection<UserProfile>(
                database.Value.CollectionName);
        }
        public async Task<List<UserProfile>> GetAll() =>
            await _context.Find(_ => true).ToListAsync();

        public async Task<UserProfile?> GetId(string id) =>
            await _context.Find(x => x.id == id).FirstOrDefaultAsync();

        public async Task Creat(UserProfile us) =>
            await _context.InsertOneAsync(us);

        public async Task UpdateUser(string id, UserProfile update) =>
            await _context.ReplaceOneAsync(x => x.id == id, update);

        public async Task Remove(string id) => 
            await _context.DeleteOneAsync(x => x.id == id);
    }
}
