using Project1Rebar.Models;
using System;
using System.Collections.Generic;

namespace Project1Rebar.Services
{
    public interface IOrderService
    {
        //List<Shake> GetShakes();
        Shake CreateShakeInOrder(Shake shake);
        void DeleteShake(Guid id);
        void UpdateOrderShake(Guid id, Shake shake);
        object GetShakeById(Guid id);
        //Shake GetShakeById(Guid shakeId);
    }
}
