using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBhv : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] float health = 10;
    [SerializeField] int scoreValue = 1;

    [Header("Enemy Shoot Bhv")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject hitEffect;
    [SerializeField] int pooledAmount = 10;
    List<GameObject> bullets;

    [Header("Sound Effects")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion;
    [SerializeField] AudioSource shootSoundSource;
    [SerializeField] AudioSource deathSoundSource;

    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);

        bullets = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(projectile);
            obj.SetActive(false);
            bullets.Add(obj);
        }

        InvokeRepeating("FireBullets", minTimeBetweenShots, maxTimeBetweenShots);
    }

    void FireBullets()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                shootSoundSource.PlayOneShot(shootSoundSource.clip);
                bullets[i].transform.position = transform.position;
                bullets[i].transform.rotation = transform.rotation;
                bullets[i].SetActive(true);
                break;
            }
        }
    }

    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer)
        {
            return;
        }
        health -= damageDealer.GetDamage;
        damageDealer.DisableBullet();
        if (health <= 0)
        {
            Die();
        }
        else
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity, transform);
        }
            
    }

    private void Die()
    {
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(explosion, durationOfExplosion);
        deathSoundSource.PlayOneShot(deathSoundSource.clip);
        Destroy(gameObject);
    }
}
