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

    Camera mainCamera;
    bool controlIsActive = true;

    float xMin;
    float xMax;
    float yMin;
    float yMax;
    
    void Start()
    {

        mainCamera = Camera.main;
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
        Camera mainCamera = Camera.main;
        xMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + playerPos;
        xMax = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - playerPos;

        yMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + playerPos;
        yMax = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - playerPos;
    }

    void Update()
    {
        Movement();
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

    private void Movement()
    {
        if (controlIsActive)
        {
#if UNITY_STANDALONE || UNITY_EDITOR

            if (Input.GetMouseButton(0))   
            {
                Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = transform.position.z;
                transform.position = Vector3.MoveTowards(transform.position, mousePosition, 30 * Time.deltaTime);
            }
#endif

#if UNITY_IOS || UNITY_ANDROID

            if (Input.touchCount == 1)
            {
                Touch touch = Input.touches[0];
                Vector3 touchPosition = mainCamera.ScreenToWorldPoint(touch.position);
                touchPosition.z = transform.position.z;
                transform.position = Vector3.MoveTowards(transform.position, touchPosition, 30 * Time.deltaTime);
            }
#endif
        }
    }
}
