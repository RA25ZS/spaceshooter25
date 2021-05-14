using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] AudioSource shootSoundSource;

    [Header("Projectile Stats")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float firingPeriod = 1f;
    [SerializeField] int pooledAmount = 10;
    List<GameObject> bullets;

    [Header("Boundaries")]
    [SerializeField] float xRangeLeft;
    [SerializeField] float xRangeRight;
    [SerializeField] float yRangeUp;
    [SerializeField] float yRangeDown;

    bool controlIsActive = true;

    void Start()
    {

        bullets = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(laserPrefab);
            obj.SetActive(false);
            bullets.Add(obj);
        }

        InvokeRepeating("FireBullets", firingPeriod, firingPeriod);
    }

    public void FireBullets()
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

    private void Update()
    {
        PlayerMovement();
        SetBoundaries();
    }

    private void SetBoundaries()
    {
        if (transform.position.x < -xRangeLeft)
        {
            transform.position = new Vector3(-xRangeLeft, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRangeRight)
        {
            transform.position = new Vector3(xRangeRight, transform.position.y, transform.position.z);
        }

        if (transform.position.y < -yRangeDown)
        {
            transform.position = new Vector3(transform.position.x, -yRangeDown, transform.position.z);
        }

        if (transform.position.y > yRangeUp)
        {
            transform.position = new Vector3(transform.position.x, yRangeUp, transform.position.z);
        }
    }

     

    private void PlayerMovement()
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
