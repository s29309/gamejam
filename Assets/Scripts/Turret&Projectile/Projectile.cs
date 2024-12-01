using UnityEngine;

namespace Turret_Projectile {
    public class Projectile : MonoBehaviour {
        [SerializeField] private TurretConfig turretConfig;
        private float _speed;
        [SerializeField] private float power;

        private Rigidbody2D _rb2d;

        private void Awake() {
            _rb2d = GetComponent<Rigidbody2D>();
            _speed = turretConfig.projectileSpeed;
        }

        private void Start() {
            _rb2d.velocity = transform.right * _speed;
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Platform")) {
                Destroy(gameObject);
            }

            if (other.gameObject.CompareTag("Player")) {
                other.GetComponent<PlayerController>().Stun();
                other.attachedRigidbody.AddForce(Vector2.up * power);
                other.attachedRigidbody.AddForce(transform.right*power);

                Vector2 triggerPosition = other.transform.position;

                if (triggerPosition.x > transform.position.x)
                {
                    other.attachedRigidbody.AddTorque(-power*0.1f, ForceMode2D.Force);
                }
                else
                {
                    other.attachedRigidbody.AddTorque(power * 0.1f, ForceMode2D.Force);
                }

                Destroy(gameObject);
            }
        }
    }
}