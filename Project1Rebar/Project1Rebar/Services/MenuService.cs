using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1Rebar.Models;
using MongoDB.Driver;

namespace Project1Rebar.Services
{
    public class MenuService:IMenuService
    {
        private readonly IMongoCollection<Shake> _shakes;
        public ShakeService(IRebarDatabaseSetting setting, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(setting.DatabaseName);
            _shakes = database.GetCollection<Shake>(setting.ShapesCollection);
        }

        public List<Shake> GetShakes()
        {
            return _shakes.Find(shake => true).ToList();
        }

        public Shake GetShakeById(Guid id)
        {
            return _shakes.Find(shake => shake.Id == id).FirstOrDefault();
        }
        public Shake Create(Shake shake)
        {
            _shakes.InsertOne(shake);
            return shake;

        }
        public void UpdateShake(Guid id, Shake shake)
        {
            _shakes.ReplaceOne(shake => shake.Id == id, shake);
        }
        public void RemoveShake(Guid id)
        {
            _shakes.DeleteOne(shake => shake.Id == id);
        }


    }
}
