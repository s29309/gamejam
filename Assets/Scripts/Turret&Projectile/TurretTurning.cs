using System.Collections;
using UnityEngine;

namespace Turret_Projectile {
    public class TurretTurning : MonoBehaviour {
        [SerializeField] private AimingSystem aimingSystem;
        [SerializeField] private GameObject turretSprite;
        [SerializeField] private TurretConfig turretConfig;
        private bool _isShooting;
        private IEnumerator _turningCoroutine;
        private float _rotationSpeed;

        private void Awake() {
            _rotationSpeed = turretConfig.rotationSpeed;
        }

        private IEnumerator TurningCoroutine(GameObject target) {
            while (true) {
                var rotation = aimingSystem.Aim(target);
                turretSprite.transform.rotation = Quaternion.Slerp(turretSprite.transform.rotation, rotation,
                    _rotationSpeed * Time.deltaTime);
                yield return new WaitForSeconds(0);
            }
        }

        public void StartTurning(GameObject target) {
            _turningCoroutine = TurningCoroutine(target);
            StartCoroutine(_turningCoroutine);
        }

        public void StopTurning() {
            StopCoroutine(_turningCoroutine);
        }

        public bool IsCoroutineNull() {
            return _turningCoroutine == null;
        }
    }
}