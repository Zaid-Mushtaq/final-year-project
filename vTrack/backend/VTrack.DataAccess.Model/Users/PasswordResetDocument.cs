using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using VTrack.DataAccess.Model.Attributes;
using VTrack.DataAccess.Model.Common;

namespace VTrack.DataAccess.Model.Users;

[Collection("password_resets")]
public class PasswordResetDocument
{
    [BsonId]
    public ObjectId Id { get; set; }
    
    [BsonElement("email")]
    public string Email { get; set; }
    
    [BsonElement("userId")]
    public ObjectId UserId { get; set; }
    
    [BsonElement("created")]
    public AuditElement Created { get; set; }
    
    [BsonElement("ipAddress")]
    public string IpAddress { get; set; }
    
    [BsonElement("hash")]
    public string Hash { get; set; }
    
    [BsonElement("invalid")]
    public bool Invalid { get; set; }
}