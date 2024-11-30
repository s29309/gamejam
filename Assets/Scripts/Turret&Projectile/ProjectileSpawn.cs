using System.Collections;
using UnityEngine;

namespace Turret_Projectile {
    public class ProjectileSpawn : MonoBehaviour {
        [SerializeField] private AimingSystem aimingSystem;
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private TurretConfig turretConfig;
        [SerializeField] private TurretTurning turretTurning;
        private float _seriesCooldown;
        private float _projectileCooldown;
        private int _projectileCount;

        private void Awake() {
            _seriesCooldown = turretConfig.shootingSeriesCooldown;
            _projectileCooldown = turretConfig.projectileCooldown;
            _projectileCount = turretConfig.projectileCount;
        }

        public IEnumerator SpawnProjectileCoroutine(GameObject target) {
            if (!turretTurning.IsCoroutineNull()) turretTurning.StopTurning();
            turretTurning.StartTurning(target);
            yield return new WaitForSeconds(_seriesCooldown);
            while (true) {
                turretTurning.StopTurning();
                var angle = aimingSystem.Aim(target);
                for (var i = 0; i < _projectileCount; i++) {
                    Instantiate(projectilePrefab, transform.position, angle);
                    yield return new WaitForSeconds(_projectileCooldown);
                }
                turretTurning.StartTurning(target);
                yield return new WaitForSeconds(_seriesCooldown);
            }
        }
    }
}