using Project1Rebar.Models;

namespace Project1Rebar.Services
{
    interface IMenuService
    {
        List<Shake> Get();
        Shake Get(Guid id);
        Shake Create(Shake shake);
        void Update(Guid id, Shake shake);
        void Remove(Guid id);
    }
}
