using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceShooter
{
    public class PlayerCollision : MonoBehaviour
    {
        [SerializeField] int health = 250;
        [SerializeField] AudioClip deathSound;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
            health -= damageDealer.GetDamage;
            damageDealer.DisableBullet();

            if (health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            FindObjectOfType<GameManager>().LoadGameOver();
            gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position);
        }

        public int GetHealth()
        {
            return health;
        }
    }
}
