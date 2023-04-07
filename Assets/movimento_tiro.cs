using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimento_tiro : MonoBehaviour
{
    Rigidbody  fisica;
    private float velocidade = 5f;

        private void Start()
    {
        fisica = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        fisica.AddRelativeForce(Vector3.forward * velocidade); ;
    }
}
