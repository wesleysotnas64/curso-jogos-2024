using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public float velocity;

    void Start()
    {
        Destroy(this.gameObject, 3);
    }

    void Update()
    {
        transform.Translate(0, velocity * Time.deltaTime, 0);
    }
}
