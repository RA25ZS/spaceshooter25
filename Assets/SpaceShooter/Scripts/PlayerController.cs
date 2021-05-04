using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] float speed = 7f;
    [SerializeField] float playerPos = 1f;
    [SerializeField] int health = 250;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip shootSound;

    [Header("Projectile Stats")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float firingPeriod = 1f;
    [SerializeField] int pooledAmount = 10;
    List<GameObject> bullets;

    Coroutine firingCoroutine;

    float xMin;
    float xMax;
    float yMin;
    float yMax;
    
    void Start()
    {
        MoveBoundaries();

        bullets = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(laserPrefab);
            obj.SetActive(false);
            bullets.Add(obj);
        }

        InvokeRepeating("FireBullets", firingPeriod, firingPeriod);
    }

    void FireBullets()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position);
                bullets[i].transform.position = transform.position;
                bullets[i].transform.rotation = transform.rotation;
                bullets[i].SetActive(true);
                break;
            }
        }
    }

    private void MoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + playerPos;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - playerPos;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + playerPos;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - playerPos;
    }

    void Update()
    {
        Move();
    }

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
        FindObjectOfType<Level>().LoadGameOver();
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position);
    }

    public int GetHealth()
    {
        return health;
    }   
    private void Move()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        float newXpos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        float newYpos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXpos, newYpos);
    }
}
