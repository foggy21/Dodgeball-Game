using Dodgeball.Domain.Characteristic;
using UnityEngine;

namespace Dodgeball.Scripts.Config
{
    [CreateAssetMenu(fileName = "BallConfig", menuName = "Dodgeball/Config/Ball")]
    public class BallConfig : ScriptableObject
    {
        [SerializeField] private Harm _harmSettings;
        [SerializeField] private Movement _movementSettings;
        
        public Harm HarmSettings => _harmSettings;
        public Movement MovementSettings => _movementSettings;
    }
}