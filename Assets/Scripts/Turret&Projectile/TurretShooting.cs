using System;
using System.Collections;
using UnityEngine;

namespace Turret_Projectile {
    public class TurretShooting : MonoBehaviour {
        [SerializeField] private ProjectileSpawn projectileSpawn;
        private bool _playerInRange; 
        private GameObject _target;
        private IEnumerator _projectileSpawnCoroutine;

        private void Awake() {
            _playerInRange = false;
        }

        public void SetTarget(GameObject target) {
            _playerInRange = !_playerInRange;
            _target = target;
            if (_playerInRange) {
                Shoot();
            }
            else {
                StopShooting();
            }
        }

        private void Shoot() {
            _projectileSpawnCoroutine = projectileSpawn.SpawnProjectileCoroutine(_target);
            StartCoroutine(_projectileSpawnCoroutine);
        }

        private void StopShooting() {
            StopCoroutine(_projectileSpawnCoroutine);
        }
    }
}