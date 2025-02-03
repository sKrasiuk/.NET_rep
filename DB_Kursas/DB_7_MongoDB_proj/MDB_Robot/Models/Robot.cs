using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MDB_Robot.Models;

public class Robot
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public List<Arm> Arms { get; set; }
    public List<Leg> Legs { get; set; }
    public Torso Torso { get; set; }
    public HeadType HeadType { get; set; }

    public Robot(List<Arm> arms, List<Leg> legs, Torso torso, HeadType headType)
    {
        Arms = arms;
        Legs = legs;
        Torso = torso;
        HeadType = headType;
    }
}
