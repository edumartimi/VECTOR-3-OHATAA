using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimento2 : MonoBehaviour
{
    private Transform movimento;
    public GameObject lugar;
    public float speed;
    public float acuracy;
    // Start is called before the first frame update
    void Start()
    {
        movimento = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        movimento.LookAt(lugar.transform.position);
        Vector3 direction = lugar.transform.position - movimento.position;
        Debug.DrawRay(movimento.position, direction, Color.red);
        if (direction.magnitude > acuracy)
        {
            movimento.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }

    }
}
