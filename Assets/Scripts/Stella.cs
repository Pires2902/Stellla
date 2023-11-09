using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stella : MonoBehaviour
{
    [SerializeField] Transform barraDeVida;

    private float porcent;

    [SerializeField] float vidaTotal, vidaAtual;

    public float velocidade = 3f;
    public Animator animator;
    private Rigidbody2D playerRigidbody2D;

    public bool podeAndar;

    public float movimentoHorizontal;
    
    void Start()
    {
        porcent = barraDeVida.localScale.x / vidaTotal;
    
        Debug.Log("Start de " + this.name);
        animator = GetComponent<Animator>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");

        if (podeAndar == true)
       {
        transform.Translate(Vector3.right * Time.deltaTime * velocidade * movimentoHorizontal);
        Movimento();
       }
       else
       {

       }
        barraDeVida.localScale = new Vector3(porcent * vidaAtual, barraDeVida.localScale.y, barraDeVida.localScale.z);
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Pulo", true);
            transform.position = new Vector2(transform.position.x,transform.position.y + 1);
        }
        else
        {
            animator.SetBool("Pulo", false);
        }
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