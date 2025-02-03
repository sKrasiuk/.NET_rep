using System;
using MDB_Robot.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MDB_Robot.Services;

public class MongoDbRepository
{
    private readonly IMongoCollection<Robot> _robots;

    public MongoDbRepository(string connectionString = "mongodb+srv://TestDB:TestDB123@cluster0.znu2h.mongodb.net/", string databaseName = "RobotDb")
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _robots = database.GetCollection<Robot>("Robots");
    }

    public Robot AddRobot(Robot robot)
    {
        try
        {
            _robots.InsertOne(robot);
            return robot;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public bool AddRobots(List<Robot> robots)
    {
        if (robots == null || !robots.Any())
        {
            return false;
        }

        try
        {
            _robots.InsertMany(robots);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool DeleteRobotById(string id)
    {
        try
        {
            var result = _robots.DeleteOne(x => x.Id == id);
            return result.DeletedCount > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public Robot FindRobotById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return null;
        }

        try
        {
            var filter = Builders<Robot>.Filter.Eq(x => x.Id, id);
            return _robots.Find(filter).FirstOrDefault();
        }
        catch (Exception)
        {
            return null;
        }
    }

    public Robot FindRobotByProperty(string propertyName, object propertyValue)
    {
        if (string.IsNullOrEmpty(propertyName) || propertyValue == null)
        {
            return null;
        }

        try
        {
            var filter = Builders<Robot>.Filter.Eq(propertyName, propertyValue);
            return _robots.Find(filter).FirstOrDefault();
        }
        catch (Exception)
        {
            return null;
        }
    }

    public bool UpdateRobot(string id, Robot updatedRobot)
    {
        if (string.IsNullOrEmpty(id) || updatedRobot == null)
        {
            return false;
        }

        try
        {
            var filter = Builders<Robot>.Filter.Eq(r => r.Id, id);
            var result = _robots.ReplaceOne(filter, updatedRobot);

            return result.ModifiedCount > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
