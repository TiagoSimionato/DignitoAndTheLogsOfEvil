///<summary>
/// Edições do código:
/// 18/04: Lucas Tedim: Código criado
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject door;     // Objeto que recebe o prefab da porta da sala do boss
    public bool playerInRange;  // Booleano que verifica se o player está no range da porta
    int hasKey;                 // Inteiro que verifica se o player possui a chave da dungeon

    void Update()
    {
        // Se o player apertar a barra de espaço estando no range e com a chave

        if (Input.GetKeyDown(KeyCode.Space) && playerInRange && hasKey == 1)
        {
            door.gameObject.SetActive(false);   // Desabilita o objeto da porta

        }
    }
    /* Ao entrar em contato com o collider da porta
     * Se for o player, muda o playerInRange para true
     * Verifica nas PlayersPrefs de o player tem a chave
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            hasKey = PlayerPrefs.GetInt("hasKey", 0);
        }
    }
    // Ao sair do contato com o collider, se for o player, muda para falso o playerInRange
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

}
