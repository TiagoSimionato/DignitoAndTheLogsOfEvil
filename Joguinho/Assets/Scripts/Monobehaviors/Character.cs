///<summary>
/// Edições do código:
/// 15/04: Walter Oliveira: Código criado
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//classes abstracts não podem ser instanciadas, apenas herdadas
public abstract class Character : MonoBehaviour
{
    public float MaxDamagePoints;           // valor minimo inicial de vida do player
    public float StartDamagePoints;         // valor maximo permitido de vida do player
    public abstract void ResetCharactere(); // Função de reset do player
    public virtual IEnumerator FlickerCharacter()       // Corotina que pisca o personagem em vermelho quando ele tomar dano
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;

    }
    public abstract IEnumerator DanoCharactere(int damage, float interval);     // Corotina de dano ao personagem

    public virtual void KillCharactere()        // Função de destruir o personagem 
    {
        Destroy(gameObject);
    }
}
