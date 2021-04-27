using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBhv : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, bulletSpeed * Time.deltaTime, 0);
    }
}
