using Microsoft.Extensions.Options;
using MilestoneAssessment3.Models;
using MongoDB.Driver;

namespace MilestoneAssessment3.Services
{
    public class NutritionServices
    {
        private readonly IMongoCollection<Nutrition> _context;

        public NutritionServices(IOptions<GymDatabase> database)
        {
            var mongoClient = new MongoClient(database.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(database.Value.DatabaseName);

            _context = mongoDatabase.GetCollection<Nutrition>(database.Value.CollectionName);
        }
        public async Task<List<Nutrition>> GetAll() =>
           await _context.Find(_ => true).ToListAsync();

        public async Task<Nutrition?> GetId(string id) =>
            await _context.Find(x => x.UserId == id).FirstOrDefaultAsync();

        public async Task<Nutrition?> GetByWorkoutType(string id) =>
            await _context.Find(x => x.WorkoutType == id).FirstOrDefaultAsync();

        public async Task Creat(Nutrition nu) =>
            await _context.InsertOneAsync(nu);

        public async Task UpdateUser(string id, Nutrition update) =>
            await _context.ReplaceOneAsync(x => x.UserId == id, update);

        public async Task Remove(string id) =>
            await _context.DeleteOneAsync(x => x.UserId == id);

        public async Task RemoveUsingWorkoutType(string id) =>
            await _context.DeleteOneAsync(x => x.WorkoutType == id);
    }
}
