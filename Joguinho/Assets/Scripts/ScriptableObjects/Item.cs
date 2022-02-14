///<summary>
/// Edições do código:
/// 15/04: Walter Oliveira: Código criado
/// </summary>
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]  // Adiciona um objeto scriptavel no menu de assets

public class Item : ScriptableObject
{       
    public string ObjectName;       // Variavel string que armazena o nome do item
    public Sprite Sprite;           // Variavel que armazena a sprite do item
    public int Quantity;            // Variavel inteira que armazena a quantidade de itens
    public bool Stackable;          // Variavel booleana que armazena se o item é stackavel no inventario 
    public enum ItemType            // Lista de possíveis itens do jogo
    {
        COIN,
        HEALTH,
        KEY,
        LIFE_POTION
    }

    public ItemType itemType;   // Variavel que armazena o tipo do item
}
