using Project1Rebar.Models;

namespace Project1Rebar.Services
{
    interface IMenuService
    {
        List<Shake> GetShakes();
        Shake GetShakeById(Guid id);
        Shake Create(Shake shake);
        void UpdateShake(Guid id, Shake shake);
        void RemoveShake(Guid id);
    }
}
