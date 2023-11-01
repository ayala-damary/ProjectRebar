using Project1Rebar.Models;

namespace Project1Rebar.Services
{
    public interface IOrderService
    {
        List<Shake> GetShakes();
        Shake CreateShakeInOrder(Shake shake);
        void DeleteShake(Guid id);
        void UpdateOrderShake(Guid id, Shake shake);
        Shake GetShakeById(Guid shakeId);
    }
}
