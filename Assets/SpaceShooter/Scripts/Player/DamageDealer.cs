using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField] int damage = 10;

        private void OnEnable()
        {
            Invoke("DisableBullet", 3f);
        }

        public void DisableBullet()
        {
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            CancelInvoke();
        }
        public int GetDamage { get => damage; }

    }
}
