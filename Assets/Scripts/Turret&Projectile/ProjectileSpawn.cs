using System;
using System.Collections;
using UnityEngine;

namespace Turret_Projectile {
    public class ProjectileSpawn : MonoBehaviour {
        [SerializeField] private AimingSystem aimingSystem;
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private TurretConfig turretConfig;
        [SerializeField] private GameObject turretSprite;
        private float _cooldown;

        private void Awake() {
            _cooldown = turretConfig.shootingCooldown;
        }

        public IEnumerator SpawnProjectileCoroutine(GameObject target) {
            while (true) {
                var angle = aimingSystem.Aim(target);
                turretSprite.transform.rotation = angle;
                Instantiate(projectilePrefab, transform.position, angle);
                yield return new WaitForSeconds(_cooldown);
            }
        }
    }
}