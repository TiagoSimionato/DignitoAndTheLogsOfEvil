/// <summary>
/// Edicoes do codigo:
/// 19/04: Lucas Tedim: Código Criado
/// 20/04: Lucas Tedim: Funcao Update alterada para ser usada no Npc
/// O objetivo deste Script eh associar corretamente o texto de cada placa e caixa de dialogo no jogo ao seu respectivo collider
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public GameObject dialogBox;    //Guarda o objeto da caixa de dialogo na cena
    public GameObject item;         //Guarda um possivel item consumivel que possa ser usado
    public Text dialogText;         //Guarda o objeto do texto de dialogo na cena
    public string dialog;           //Objeto com o texto que deve aparecer ao interagir (personalizado no Unity)
    public bool playerInRange;      //Variavel que diz se o Player está próximo o suficiente para interagir com a caixa de dialogo

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (dialogBox.activeInHierarchy)    //Revela o objeto caixa de dialogo ao interagir com o objeto        
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
            if (!item.activeInHierarchy)        //Revela um item que pode ser dado de recompensa ao Player
            {
                item.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)     //Usando um colisor (trigger) para saber se o player está próximo o suficiente.
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Player in range");
            playerInRange = true;
        }   
    }
    private void OnTriggerExit2D(Collider2D collision)      //Detectando quando o Player sair do range do dialogo. Tambem fecha a caixa de dialogo existente
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Player left range");
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
