using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MilestoneAssessment3.Models
{
    public class Nutrition
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public string WorkoutType { get; set; }
        public int DurationMinutes { get; set; }
    }
}
