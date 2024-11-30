using UnityEngine;

namespace Turret_Projectile {
    [CreateAssetMenu(menuName = "Scriptable Objects/Turret Config", fileName = "Turret Config")]
    public class TurretConfig : ScriptableObject {
        public float projectileSpeed;
        public float shootingSeriesCooldown;
        public float projectileCooldown;
        public int projectileCount;
        public float rotationSpeed;
    }
}