using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class BackgroundScroller : MonoBehaviour
    {
        [SerializeField] float backroundScrollSpeed = 0.5f;
        Material myMaterial;
        Vector2 offSet;

        private void Awake()
        {
            myMaterial = GetComponent<Renderer>().material;
        }
        void Start()
        {
            offSet = new Vector2(0f, backroundScrollSpeed);
        }

        void Update()
        {
            myMaterial.mainTextureOffset += offSet * Time.deltaTime;
        }
    }
}
