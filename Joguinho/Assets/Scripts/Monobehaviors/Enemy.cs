///<summary>
/// Edições do código:
/// 15/04: Lucas Tedim: Código criado
/// 16/07: Tiago Simionato: Adição de drop ao matar o inimigo
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{

    float healthPoints;         // Vida o Enemy
    public int forceDamage;     // Dano causado pelo Enemy
    public GameObject heart;    // GameObject do coração
    public GameObject coin;     // GameObject de moeda
    public GameObject victory;  // GameObject do objeto de vitoria do jogo

    Coroutine damageCoroutine;  // Coroutine de causar dano

    // Ao iniciar, reinicia o Enemy com seus valores iniciais herdados de Character
    private void OnEnable()
    {
        ResetCharactere();
    }
    /* Ao entrar em colisão, se for um objeto com a tag Player
     *  Inicia corotina de causar dano ao Player por 1.0f segundos
     */
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (damageCoroutine == null)
            {
                Debug.Log("Hit enemy");
                damageCoroutine = StartCoroutine(player.DanoCharactere(forceDamage, 1.0f));
            }
        }
    }
    /* Ao sair da colisão, se for com um objeto com a tag Player
     *  Para a corotine de dano
     */
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
                   
            }
        }
    }
    /* Corotina herdada de Character 
     * Entrar na corotine, diminui a vida do Enemy pelo dano causado
     * Se a vida for menor ou igual a 0, mata o Enemy 
     */
    public override IEnumerator DanoCharactere(int damage, float interval)
    {
        while (true)
        {
            StartCoroutine(FlickerCharacter());
            healthPoints = healthPoints - damage;
            if (healthPoints <= float.Epsilon)
            {
                KillCharactere();
                break;
            }
            if (interval > float.Epsilon) // Intervalo entre cada instância de dano
            {
                yield return new WaitForSeconds(interval);  // Espera um tempo para a continuação da corotina
            }
            else
            {
                break;
            }
        }
    }
   
    public override void ResetCharactere()
    {
        healthPoints = StartDamagePoints; // Seta a quantidade de vida do Enemy
    }
    /* Ao Destruir o Enemy
     * Escolhe um numero de 1 a 10, se for menor que 2 dropa um coração
     * Se for acima de 2 dropa uma moeda
     * Se for o Boss, instancia o objeto de vitoria
     */
    void OnDestroy()
    {
        if (healthPoints <= float.Epsilon)
        {
            int drop = Random.Range(1,11);
            if (drop < 2)
            {
                Instantiate(heart, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(coin, transform.position, Quaternion.identity);
            }
        }
        if (gameObject.CompareTag("Boss"))
        {
            Destroy(GameObject.Find("musicPlayer(Clone)"));
            Instantiate(victory);
        }
        
    }
}
