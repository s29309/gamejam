using UnityEngine;

namespace Turret_Projectile {
    public class Projectile : MonoBehaviour {
        private float _speed = 5;
        private Rigidbody2D _rb2d;

        private void Awake() {
            _rb2d = GetComponent<Rigidbody2D>();
        }

        private void Start() {
            _rb2d.velocity = transform.right * _speed;
        }
    
        private void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.CompareTag("Ground")) {
                Destroy(gameObject);
            }

            if (other.gameObject.CompareTag("Player")) {
                //TODO: Player reaction to the projectile
                Destroy(gameObject);
            }
        }
    }
}