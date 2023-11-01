using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1Rebar.Services
{
    public class MenuService
    {
        private readonly IMongoCollection<Shake> _shakes;
        public ShakeService(IRebarDatabaseSetting setting, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(setting.DatabaseName);
            _shakes = database.GetCollection<Shake>(setting.ShapesCollection);

        }
        public Shake Create(Shake shake)
        {
            _shakes.InsertOne(shake);
            return shake;

        }

        public List<Shake> Get()
        {
            return _shakes.Find(shake => true).ToList();
        }

        public Shake Get(Guid id)
        {
            return _shakes.Find(shake => shake.Id == id).FirstOrDefault();
        }

        public void Remove(Guid id)
        {
            _shakes.DeleteOne(shake => shake.Id == id);
        }

        public void Update(Guid id, Shake shake)
        {
            _shakes.ReplaceOne(shake => shake.Id == id, shake);
        }
    }
}
