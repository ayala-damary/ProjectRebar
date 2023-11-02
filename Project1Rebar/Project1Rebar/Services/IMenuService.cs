using Project1Rebar.Models;
using System;
using System.Collections.Generic;
namespace Project1Rebar.Services
{
    public interface IMenuService
    {
        List<Shake> GetShakes();
        Shake GetShakeById(Guid id);
        Shake Create(Shake shake);
        void UpdateShake(Guid id, Shake shake);
        void RemoveShake(Guid id);
    }
}
