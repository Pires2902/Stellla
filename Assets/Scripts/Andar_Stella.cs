using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andar_Stella : MonoBehaviour
{
    public float entradaHorizontal ;

    public float movimentoHorizontal;
    public float velocidade = 3.0f;
    public Animator animator;
    private Rigidbody2D playerRigidbody2D;

    public bool podeAndar;
    
    void Start()
    {
        Debug.Log("Start de " + this.name);
        animator = GetComponent<Animator>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movimentoHorizontal = Input.GetAxis("Horizontal");
        podeAndar = true;
        if (podeAndar == true)
       {
        transform.Translate(Vector3.right * Time.deltaTime * velocidade * movimentoHorizontal);
        Movimento();
       }
       else
       {

       }
        
    }

    private void Movimento()
    {
        Vector2 moveDirection = new Vector2(movimentoHorizontal,0).normalized;
        Vector2 newPosition = playerRigidbody2D.position + moveDirection * velocidade * Time.deltaTime;

        playerRigidbody2D.MovePosition(newPosition);
        
        if (movimentoHorizontal < 0)
        {
            animator.SetBool("Esquerda", true);
        }
        else
        {
            animator.SetBool("Esquerda", false);
        }

       if (movimentoHorizontal > 0)
        {
            animator.SetBool("Direita", true);
        }
        else
        {
            animator.SetBool("Direita", false);
        }

/*        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Pulo", true);
            transform.position = new Vector2(transform.position.x,transform.position.y + 1);
        }
        else
        {
            animator.SetBool("Pulo", false);
        }
    } */
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("O objeto " + name + " colidiu com o objeto " + other.name);

        

        
         if (other.tag == "Parede")
        {
            animator.SetBool("Idle", true);
        }
        else
        {
            animator.SetBool("Idle", false);
        }
    }
}
