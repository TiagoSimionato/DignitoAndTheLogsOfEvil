///<summary>
/// Edições do código:
/// 17/04: Lucas Tedim: Código criado
/// 18/04: Tiago Simionato: Adição das músicas
/// 20/01: Walter Oliveira: Comentarios
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public int damage;          // Variavel de dano da espada
    Coroutine damageCoroutine;  // Variavel que armazena a coroutine de dano
    public AudioClip enemyhit;  // Variavel que armazena o clipe de audio ao acertar um inimigo
    public AudioClip swing;     // Variavel que armazena o clipe de audio ao errar o inimigo
    
    // Ao iniciar o script procura o objeto AudioSource do PlayerO da hierarquia e toda a musica de erro
    void OnEnable()
    {
        AudioSource audio = GameObject.Find("PlayerO(Clone)").GetComponent<AudioSource>();
        audio.Play();
    }

    /* Quando o collider da espada collidir com um inimigo
     * Inicia a coroutina de dano ao inimigo
     * Toca o audio de acerto no inimigo 
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is BoxCollider2D)
        {
            Debug.Log("Attack enemy");
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            damageCoroutine = StartCoroutine(enemy.DanoCharactere(damage, 0.0f));
            AudioSource audio = GameObject.Find("PlayerO(Clone)").GetComponent<AudioSource>();
            audio.clip = enemyhit;
            audio.Play();
        }
    }

    /* Ao sair da colisão 
     * Procura o objeto de audio do player e muda o audio para o de erro 
     */
    private void OnTriggerExit2D(Collider2D collision)
    {
        AudioSource audio = GameObject.Find("PlayerO(Clone)").GetComponent<AudioSource>();
        audio.clip = swing;
    }
}
