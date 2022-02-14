///<summary>
/// Edi��es do c�digo:
/// 15/04: Walter Oliveira: C�digo criado
/// 17/04: Walter Oliveira: Adi��o do anima��o de andar
/// 18/04: Tiago Simionato: Adi��o da anima��o de ataque
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public float MovimentSpeed;                 // Velocidade de movimento do player
    Vector3 Moviment = new Vector3();           // Detectar movimento pelo teclado
    Rigidbody2D Rb2D;                           // Armazena o Rigidbody do player
    Animator Animator;                          // Armazena o controlador de anima��o do player
    bool attacking;                             // Booleano para armazenar se o player est� atacando ou n�o

    void Start()
    {
        // Carrega o Rigidbody e o Animator do player e seta attacking para falso
        Rb2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        attacking = false;
    }

    /* Pega os inputs dos bot�es de entrada e normaliza
     * Caso o bot�o de ataque (F) seja acionado, seta attacking para true
     * Atualiza a o estado do player
     */
    void Update()
    {
        Moviment = Vector3.zero;
        Moviment.x = Input.GetAxisRaw("Horizontal");
        Moviment.y = Input.GetAxisRaw("Vertical");
        Moviment.Normalize();
        if (Input.GetButtonDown("attack"))
        {
            attacking = true;
        }
        UpdateState();
    }
    // Muda a velocidade do rb2d do player pela moviment speed 
    private void MoveCharacter()
    {
        Rb2D.velocity = Moviment * MovimentSpeed;
    }
    // Muda a anima��o de dire��o e ataque
    private void UpdateState()
    {
        if (attacking)
        {
            Animator.SetBool("Attacking", true);
            attacking = false;
        }
        else
        {
            Animator.SetBool("Attacking", false);
        }

        if (Moviment != Vector3.zero)
        {
            Animator.SetBool("Walking", true);
            MoveCharacter();                        // Move o personagem
            Animator.SetFloat("dirX", Moviment.x);
            Animator.SetFloat("dirY", Moviment.y);
        }
        else
        {
            Animator.SetBool("Walking", false);
            Rb2D.velocity = Vector3.zero;           // Zera a velocidade do player, j� que ele est� parado
        }

    }
}
