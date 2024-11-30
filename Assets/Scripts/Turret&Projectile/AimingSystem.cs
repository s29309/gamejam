using System;
using System.Collections;
using UnityEngine;

namespace Turret_Projectile {
    public class AimingSystem : MonoBehaviour {
        [SerializeField] private TurretShooting turretShooting;

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.CompareTag("Player")) {
                turretShooting.SetTarget(other.gameObject);
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            if (other.gameObject.CompareTag("Player")) {
                turretShooting.SetTarget(null);
            }
        }

        public Quaternion Aim(GameObject target) {
            var playerX = target.transform.position.x;
            var playerY = target.transform.position.y;
            var a = Mathf.Sqrt((float)Math.Pow(playerY - gameObject.transform.position.y, 2));
            var c = Mathf.Sqrt((float)Math.Pow(playerX - gameObject.transform.position.x, 2) +
                               (float)Math.Pow(playerY - gameObject.transform.position.y, 2));
            var angle = Mathf.Rad2Deg * Mathf.Asin(a/c);
            if (playerX < gameObject.transform.position.x) {
                angle = 180 - angle;
            }

            if (playerY < gameObject.transform.position.y) {
                angle *= -1;
            }
            return Quaternion.Euler(0, 0, angle);
        }
    }
}