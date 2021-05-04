using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBhv : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;
    void Update()
    {
        transform.Translate(0, -bulletSpeed * Time.deltaTime, 0);
    }
}
