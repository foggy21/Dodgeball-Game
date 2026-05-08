using System;

namespace Dodgeball.Domain.Characteristic
{
    [Serializable]
    public struct Health
    {
        public byte MaxHealth;
        public byte Regeneration;
    }
}