using System;
using UnityEngine;

namespace Turret_Projectile {
    public class AimingSystem : MonoBehaviour {
        [SerializeField] private ProjectileSpawn projectileSpawn;

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.CompareTag("Player")) {
                var playerX = other.gameObject.transform.position.x;
                var playerY = other.gameObject.transform.position.y;
                var a = Mathf.Sqrt((float)Math.Pow(playerY - gameObject.transform.position.y, 2));
                var c = Mathf.Sqrt((float)Math.Pow(playerX - gameObject.transform.position.x, 2) +
                                   (float)Math.Pow(playerY - gameObject.transform.position.y, 2));
                var angle = Mathf.Rad2Deg * Mathf.Asin(a/c);
                Debug.Log(angle);
                if (playerX < gameObject.transform.position.x) {
                    angle = 180 - angle;
                }

                if (playerY < gameObject.transform.position.y) {
                    angle *= -1;
                }
                projectileSpawn.SpawnProjectile(Quaternion.Euler(0, 0, angle));
            }
        }
    }
}