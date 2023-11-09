using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float velocidade = 0.0f ;
    public float entradaHorizontal ;
    public float entradaVertical ;
    public int Voltas = 0 ; 
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start de "+this.name);
        velocidade = 3.0f ;
        transform.position = new Vector3(9.59f,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        entradaHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right*Time.deltaTime*velocidade*entradaHorizontal);
        if ( transform.position.x  < -13.35f  ) {
            transform.position = new Vector3(13.66f,transform.position.y,0);
            Voltas = Voltas + 1 ;

        }
        if ( transform.position.x  > 13.66f  ) {
            transform.position = new Vector3(-13.25f,transform.position.y,0);
            Voltas = Voltas - 1 ;

        }

          entradaVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up*Time.deltaTime*velocidade*entradaVertical);

        if ( transform.position.y  > 2.4f ) {
            transform.position = new Vector3(transform.position.x,2.4f,0);
        }

        if ( transform.position.y  < -5.89f  ) {
            transform.position = new Vector3(transform.position.x,-5.89f,0);
        }
    }
}
