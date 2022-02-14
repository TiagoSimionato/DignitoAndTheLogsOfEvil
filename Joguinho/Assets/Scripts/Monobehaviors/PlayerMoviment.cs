///<summary>
/// Edições do código:
/// 15/04: Walter Oliveira: Código criado
/// 17/04: Walter Oliveira: Adição do animação de andar
/// 18/04: Tiago Simionato: Adição da animação de ataque
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public float MovimentSpeed;                 // Velocidade de movimento do player
    Vector3 Moviment = new Vector3();           // Detectar movimento pelo teclado
    Rigidbody2D Rb2D;                           // Armazena o Rigidbody do player
    Animator Animator;                          // Armazena o controlador de animação do player
    bool attacking;                             // Booleano para armazenar se o player está atacando ou não

    void Start()
    {
        // Carrega o Rigidbody e o Animator do player e seta attacking para falso
        Rb2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        attacking = false;
    }

    /* Pega os inputs dos botões de entrada e normaliza
     * Caso o botão de ataque (F) seja acionado, seta attacking para true
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
    // Muda a animação de direção e ataque
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
            Rb2D.velocity = Vector3.zero;           // Zera a velocidade do player, já que ele está parado
        }

    }
}
