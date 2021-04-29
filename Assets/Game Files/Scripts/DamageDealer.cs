using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 10;

    private void OnEnable()
    {
        Invoke("DisableBullet", 2f);
    }

    public void DisableBullet()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
    public int GetDamage { get => damage;}

}
