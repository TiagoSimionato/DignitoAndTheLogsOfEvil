///<summary>
/// Edições do código:
/// 15/04: Walter Oliveira: Código criado
/// 16/04: Walter Oliveira: Adição do script para mudar os slots de vida
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public DamagePoints damagePoints;       // Objeto de leitura dos dados de quantos pontos tem o plauer
    public Player character;                // Receberá o objeto do player
    public GameObject HPStackPrefab;        // Receberá o GameObject do prefab do stackd e vida
    float StartHealth;                  // Armaena a quantidade limite de vida do player
    float currentHealth;                // Armazena a vida atual do player

    /* Ao iniciar o script
     * Pega o valor da vida inicial do player e, caso o ppersonagem não seja nulo
     * Instancia a healthbar com vida inicial e muda para vida atual
     */
    void Start()
    {
        StartHealth = character.StartDamagePoints;
        if (character != null)
        {
            StartHealthBar();
            currentHealth = StartHealth;
        }
    }
    /* Verifica, caso o player nao seja nulo se houve mudança na vida do player
     * Caso a vida aumente, adiciona um stack 
     * Caso a vida diminui, remove um stack
     */
    void Update()
    {
        if (character != null)
        {
            if (currentHealth < damagePoints.value)
            {
                Debug.Log("Vida aumentou");
                for(float i = currentHealth; i < damagePoints.value; i++)       // Para i = vida atual, i < valor de vida
                {
                    GameObject newStack = Instantiate(HPStackPrefab);               // Instancia um prefab de stack de vida
                    newStack.transform.SetParent(gameObject.transform.GetChild(1).transform);   // Transforma como filho da health bar
                    newStack.name = "HPStack_" + i;     // Muda o nome para HPStack_ numero do stack
                    currentHealth++;    //Aumenta a vida
                }
            }
            if (currentHealth > damagePoints.value)
            {
                Debug.Log("Vida diminuiu");
                for (float i = currentHealth; i > damagePoints.value; i--)  // Para i = vida atual, i > vida atual
                {
                    GameObject newStack = GameObject.Find("HPStack_" + (i - 1));    // Procura o HPStack que foi perdido
                    Destroy(newStack);      // Destroi o stack
                    currentHealth--;        // Diminui a vida
                }
            }
        }

    }

    // Função que instancia a health bar com valor de vida inicial do player
    public void StartHealthBar()
    {
        for (int i = 0; i < StartHealth; i++)
        {
            GameObject newStack = Instantiate(HPStackPrefab);
            newStack.transform.SetParent(gameObject.transform.GetChild(1).transform);
            newStack.name = "HPStack_" + i;
        }
    }
}
