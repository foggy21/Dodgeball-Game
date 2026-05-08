using System;

namespace Dodgeball.Domain.Characteristic
{
    [Serializable]
    public struct Movement
    {
        public byte MaxSpeed;
        public byte Acceleration;
        public byte Deceleration;
    }
}