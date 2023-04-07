using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ultimoex : MonoBehaviour
{
    //variavel do transform para não ter que ficar  usando this toda hora
    private Transform movimento;
    //criando um array para guardar todos os pontos de movimentação
    public GameObject[] lugar;
    //velocidade
    public float speed;
    //minima distancia possivel
    public float acuracy;
    //variavel para mudar o array
    private int quallugar = 0;
    //variavel para fazer voltar ao ultimo ponto
    bool final;
    // Start is called before the first frame update
    void Start()
    {
        //tranzendo o transform do proprio gameobject
        movimento = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //falando para "olhar" para o objeto em que se deseja chegar
        movimento.LookAt(lugar[quallugar].transform.position);
        //pegando a direção para onde o player deve ir
        Vector3 direction = lugar[quallugar].transform.position - movimento.position;
        //criando uma linha para mostrar a tragetoria
        Debug.DrawRay(movimento.position, direction, Color.red);
        //se a distancia entre um objeto e o outro for maior que a minima faz isso
        if (direction.magnitude > acuracy)
        {
            //movimento
            movimento.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
        // se for menor quer dizer que ele chegou
        else 
        {
            //se o contador for diferente do maximo do array, e ainda não chegou no final do trajeto pelo menos uma vez
            if (quallugar != lugar.Length - 1 && !final)
            {
                //adicionando ao contador que muda qual é o objeto foco
                quallugar++;
            }
            else 
            {
                //tirando o loop
                final = true;
                quallugar = lugar.Length - 2;
            }
            
        }
        
    }
}
