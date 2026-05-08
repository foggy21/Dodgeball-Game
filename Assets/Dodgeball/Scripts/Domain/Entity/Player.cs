using Dodgeball.Domain.Ability;
using FishNet.Object;

namespace Dodgeball.Scripts.Domain.Entity
{
    public abstract class Player : NetworkBehaviour, IMoveable, IRegenerable, IDamageable
    {
        public void Move()
        {
            throw new System.NotImplementedException();
        }

        public void Regenerate()
        {
            throw new System.NotImplementedException();
        }

        public void TakeDamage(byte damage)
        {
            throw new System.NotImplementedException();
        }
    }
}