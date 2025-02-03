using System;
using System.Reflection.Metadata.Ecma335;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Models;
using MongoDB.Services;

namespace MongoDB;

class Program
{
    static void Main(string[] args)
    {
        var connectionString = "mongodb+srv://TestDB:TestDB123@cluster0.znu2h.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";

        var bookRepo = new BookRepository(connectionString);

        while (true)
        {

        }
    }
}
