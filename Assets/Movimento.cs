using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    //variavel do transform para não ter que ficar  usando this toda hora
    private Transform movimento;
    //para onde o personagem vai
    private GameObject lugar;
    //velocidade
    public float speed;
    //distancia minima entre os objetos
    public float acuracy;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }

    void Start()
    {
        //procurando na cena um objeto com a tag ponto, e colocando ele dentro da variavel
        lugar = GameObject.FindGameObjectWithTag("ponto");
        //buscando de dentro do objeto o proprio transform
        movimento = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //fazendo o objeto "olhar" para onde ele deve ir
        movimento.LookAt(lugar.transform.position);
        //pegando a direção para onde o player deve ir
        Vector3 direction = lugar.transform.position - movimento.position;
        //criando uma linha para mostrar a tragetoria
        Debug.DrawRay(movimento.position, direction, Color.red);
        //se a distancia entre um objeto e o outro for maior que a minima
        if (direction.magnitude > acuracy)
        {
            //movimento
            movimento.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }

    }
}
