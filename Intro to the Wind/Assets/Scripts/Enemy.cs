using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject parent;


    private void OnBecameInvisible()
    {
        Destroy(parent);
    }
}
