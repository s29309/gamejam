using UnityEngine;

namespace Turret_Projectile {
    [CreateAssetMenu(menuName = "Scriptable Objects/Turret Config", fileName = "Turret Config")]
    public class TurretConfig : ScriptableObject {
        public float projectileSpeed;
        public float shootingCooldown;
    }
}