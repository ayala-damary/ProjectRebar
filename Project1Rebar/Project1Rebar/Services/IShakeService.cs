using Project1Rebar.Models;

namespace Project1Rebar.Services
{
    public interface IShakeService
    {
        List<Shake> Get();
        Shake Get(Guid id);
        Shake Create(Shake shake);
        void Update(Guid id, Shake shake);
        void Remove(Guid id);

    }
}
