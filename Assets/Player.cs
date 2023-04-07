using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody fisica;
    public float forca;
    public Camera maincamera;
    public LayerMask layerMask;
    Vector3 olhaaar;
    public  GameObject TIRO;
    public Transform lugartiro;

    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "chao")
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        
        fisica = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = maincamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask)) 
        {
           Vector3 olhar = raycastHit.point;
            olhaaar = olhar;
        }

        transform.LookAt(olhaaar);
        
        Vector3 moveplayer = new Vector3(Input.GetAxis("Horizontal"),0f, Input.GetAxis("Vertical"));
        fisica.velocity = moveplayer * forca;

        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
          GameObject bala =  Instantiate(TIRO, lugartiro.transform.position, this.transform.rotation );
        }
       
    }
}
