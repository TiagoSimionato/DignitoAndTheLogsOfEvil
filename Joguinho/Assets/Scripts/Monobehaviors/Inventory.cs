///<summary>
/// Edições do código:
/// 15/04: Walter Oliveira: Código criado
/// </summary>
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject SlotPrefabStart;               // objeto que recebe o prefab Slot
    public GameObject SlotPrefabMiddle;               // objeto que recebe o prefab Slot
    public GameObject SlotPrefabEnd;               // objeto que recebe o prefab Slot

    public const int numSlots = 5;              // Numero fixo de Slots;
    Image[] itemImages = new Image[numSlots];   // array de imagens
    Item[] items = new Item[numSlots];          // array de itens
    GameObject[] slots = new GameObject[numSlots]; // GameObject que armazena os slots de inventario
    void Start()
    {
        CreateSlot();       // Chama a função que cria os slots
    }

    /* Verifica se as 3 partes dos slots não são nulos, caso não sejam
     * Se for o primeiro slot, utiliza o prefab Start, se for algum do meio o prefabMiddle e no último prefabEnd
     */
    public void CreateSlot()
    {
        if (SlotPrefabStart != null && SlotPrefabMiddle != null &&SlotPrefabEnd != null)
        {
            for( int i = 0; i < numSlots; i++)
            {
                if(i == 0)  
                {
                    // Primeiro Slot
                    GameObject novoSlot = Instantiate(SlotPrefabStart);                         // Instancia o slot
                    novoSlot.name = "ItemSlot_" + i;                                            // Renomeia o slot
                    novoSlot.transform.SetParent(gameObject.transform.GetChild(0).transform);   // Transforma ele filho do Canvas do Inventario
                    slots[i] = novoSlot;                                                        // Adiciona o novo Slot na lista de slots
                    itemImages[i] = novoSlot.transform.GetChild(1).GetComponent<Image>();       // Muda a imagem do item

                }
                else if(i == numSlots - 1) 
                {
                    // Slots do meio
                    GameObject novoSlot = Instantiate(SlotPrefabEnd);
                    novoSlot.name = "ItemSlot_" + i;
                    novoSlot.transform.SetParent(gameObject.transform.GetChild(0).transform);
                    slots[i] = novoSlot;
                    itemImages[i] = novoSlot.transform.GetChild(1).GetComponent<Image>();

                }
                else 
                {
                    // Ultimo slot
                    GameObject novoSlot = Instantiate(SlotPrefabMiddle);
                    novoSlot.name = "ItemSlot_" + i;
                    novoSlot.transform.SetParent(gameObject.transform.GetChild(0).transform);
                    slots[i] = novoSlot;
                    itemImages[i] = novoSlot.transform.GetChild(1).GetComponent<Image>();

                }
            }
        }
    }
    /* Função que adiciona o item no inventário
     * Verifica se o item ainda não foi adicionado, caso tenha sido, aumenta a quantidade
     * Se não for, adiciona a imagem no item no primeiro slot vazio e seta a quantidade para 1 
     */
    public bool AddItem(Item itemToAdd)
    {
        for(int i=0; i <items.Length; i++)
        {
            if (items[i]!=null && items[i].itemType == itemToAdd.itemType && itemToAdd.Stackable == true) // Quando o item já foi colocado no inventario
            {
                items[i].Quantity = items[i].Quantity + 1;
                Slot slotScript = slots[i].gameObject.GetComponent<Slot>();     // Armazena o Scriptable Object Slot
                Text TextQtd = slotScript.TextQtd;                      // Variavel que contem o objeto do tipo texto que armazena a quantidade de itens
                TextQtd.enabled = true;                                 // Ativa o texto
                TextQtd.text = items[i].Quantity.ToString();            // Atualiza com a quantidade de itens
                return true;                                            // Retorna que foi possivel adicionar o item
            }
            if(items[i] == null)                // Quando é um item novo
            {
                items[i] = Instantiate(itemToAdd);      // Instancia o item a ser adicionado
                items[i].Quantity = 1;
                Slot slotScript = slots[i].gameObject.GetComponent<Slot>();
                Text TextQtd = slotScript.TextQtd;
                itemImages[i].sprite = itemToAdd.Sprite;        // Armazena na lista de itens a sprite do item
                itemImages[i].enabled = true;
                TextQtd.enabled = true;
                TextQtd.text = items[i].Quantity.ToString();
                return true;
            }
        }
        return false;               // Retorna que falho a adição dos itens
    }
}
