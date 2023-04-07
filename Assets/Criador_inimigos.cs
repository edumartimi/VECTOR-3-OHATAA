using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Criador_inimigos : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject inimigo;
    float tempo;
    int tempoint;




    // Update is called once per frame
    void Update()
    {


        tempo = tempo + Time.deltaTime;
        tempoint = Mathf.RoundToInt(tempo);

        

        if (tempoint % 2 == 0) 
        {
            Instantiate(inimigo, this.transform);
        }
    }
}
