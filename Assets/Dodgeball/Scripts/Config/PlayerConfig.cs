using Dodgeball.Domain.Characteristic;
using UnityEngine;

namespace Dodgeball.Scripts.Config
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Dodgeball/Config/Player")]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private Health _healthSettings;
        [SerializeField] private Movement _movementSettings;
        [SerializeField] private Combat _combatSettings;
        
        public Health HealthSettings => _healthSettings;
        public Movement MovementSettings => _movementSettings;
        public Combat CombatSettings => _combatSettings;
    }
}