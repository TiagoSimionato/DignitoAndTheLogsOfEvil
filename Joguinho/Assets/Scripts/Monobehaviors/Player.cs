///<summary>
/// Edicoes do codigo:
/// 15/04: Walter Oliveira: Codigo criado
/// 19/04: Tiago Simionato: Adicionados codigos de audio para as musicas do jogo e efeitos especiais
/// 20/04: Lucas Tedim: Incluido o item "key" nas possiveis interacoes
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    public HealthBar healthBarPrefab;       //Referencia ao objeto prefab criado da HealthBar
    HealthBar healthBar;                    //Variavel que guarda a barra de vida no codigo
    public Inventory inventoryPrefab;       //Referencia ao objeto prefab criado do Inventario
    Inventory inventory;                    //Variavel que guarda o inventario no codigo
    public DamagePoints damagePoints;       //Armazena o valor da vida do objeto
    public GameObject music;                //Referencia ao objeto da Audio Source
    public GameObject death;                //Objeto a ser instanciado quando o Player chega a 0 PV - chama o fade de volta para a tela principal
    public float fadeWait;                  //Variavel do tempo aguardado para o fade total quando a funcao death for chamada

    private void Start()
    {
        PlayerPrefs.SetInt("hasKey", 0);    //PlayerPref usada para ser herdada e modificada quando o player encontrar o item "key" (Usado no Script "Door")
        if (inventoryPrefab != null && healthBarPrefab != null && music != null)
        {
            /*Instanciando todos os elementos da UI necessarios ao iniciar o jogo*/
            inventory = Instantiate(inventoryPrefab);
            damagePoints.value = StartDamagePoints;
            healthBar = Instantiate(healthBarPrefab);
            healthBar.character = this;
            Instantiate(music, transform.position, Quaternion.identity);
        }
    }
    public override IEnumerator DanoCharactere(int damage, float interval)
    {
        while (true)
        {
            StartCoroutine(FlickerCharacter());        //Rotina de exibir uma animacao quando o Player recebe dano
            damagePoints.value = damagePoints.value - damage;       //Atualiza o valor de vida apos o dano recebido
            if (damagePoints.value <= float.Epsilon)        //Verifica se o Player ainda possui pontos de vida restantes para chamar a funcao de KillCharactere
            {
                KillCharactere();
                break;
            }
            if (interval > float.Epsilon)       //Intervalo de tempo em que o Player nao pode receber dano (Para evitar muitas fontes de dano simultaneas)
            {
                yield return new WaitForSeconds(interval);
            }
            else
            {
                break;
            }
        }
    }
    public override void ResetCharactere()      //Funcao para reiniciar os valores da UI do Player quando o jogo for reiniciado
    {
        inventory = Instantiate(inventoryPrefab);
        healthBar = Instantiate(healthBarPrefab);
        healthBar.character = this;
        damagePoints.value = StartDamagePoints;
    }
    public override void KillCharactere()       //Funcao para limpar elementos da UI quando o Player chegar a 0 pontos de vida
    {
        Instantiate(death);
        Destroy(healthBar.gameObject);
        Destroy(inventory.gameObject);
        Destroy(GameObject.Find("musicPlayer(Clone)"));
        base.KillCharactere();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)     //Funcao que detecta quando o personagem colide com algum objeto que seja possivel de interagir
    {
        if (collision.gameObject.CompareTag("Collectable")) //Verifica a tag dada a todos os objetos coletaveis no jogo
        {
            AudioSource[] audio = GetComponents<AudioSource>();         //Arquivo de efeito sonoro tocado sempre que o Player coleta um item
            audio[1].Play();
            Item DamageObject = collision.gameObject.GetComponent<Consumable>().item;
            Debug.Log(DamageObject);
            if (DamageObject != null)
            {
                bool Invisible = false;
                print("Get " + DamageObject.ObjectName);
                switch (DamageObject.itemType)              //Compara qual foi o objeto coletado e chama a funcao apropriada
                {
                    case Item.ItemType.COIN:
                        Invisible = inventory.AddItem(DamageObject);
                        break;

                    case Item.ItemType.HEALTH:
                        Invisible = DamagePointsUpdate(DamageObject.Quantity);
                        break;

                    case Item.ItemType.KEY:
                        Invisible = inventory.AddItem(DamageObject);
                        PlayerPrefs.SetInt("hasKey", 1);
                        break;

                    default:
                        break;
                }
                if (Invisible)
                    collision.gameObject.SetActive(false);
            }
        }
    }
    public bool DamagePointsUpdate(int quantity)        //Funcao chamada toda vez que o Player ganha ou perde pontos de vida
    {
        if (damagePoints.value < MaxDamagePoints)       //Calculo do novo valor de vida do Player
        {
            damagePoints.value = damagePoints.value + quantity;
            print("Health Update by " + quantity + " New Health = " + damagePoints.value);
            return true;
        }
        else return false;
    }

    void Update()
    {
        
    }
}
