using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{
    public float backgroundspeed;

    [SerializeField] private Renderer backgroundMaterial;

    private void Update()
    {
        backgroundMaterial.material.mainTextureOffset += new Vector2(0, backgroundspeed * Time.deltaTime);
    }
}