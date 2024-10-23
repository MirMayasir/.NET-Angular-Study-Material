using MongoDB.Bson.Serialization.Attributes;

namespace MilestoneAssessment3.Models
{
    public class UserProfile
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Name { get; set; }
        public string id { get; set; }
        public int DurationMinutes { get; set; }
        public DateTime Date { get; set; }


    }
}
