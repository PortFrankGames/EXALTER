using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    public float lifetime;

    void Awake()
    {
        Destroy(this.gameObject, lifetime);
    }
}
