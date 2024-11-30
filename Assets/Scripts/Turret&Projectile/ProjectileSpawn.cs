using UnityEngine;

namespace Turret_Projectile {
    public class ProjectileSpawn: MonoBehaviour {
        [SerializeField] private GameObject projectilePrefab;

        public void SpawnProjectile(Quaternion angle) {
            Instantiate(projectilePrefab, transform.position, angle);
        }
    }
}