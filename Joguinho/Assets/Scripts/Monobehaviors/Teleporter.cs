///<summary>
/// Edições do código:
/// 16/04: Walter Oliveira: Código criado
/// 17/04: Walter Oliveira: Adição de variável para mudar a cena do teleporte
/// 20/04: Walter Oliveira: Adição da corrotina para o fade entre as cenas
/// 21/04: Walter Oliveira: Comentários
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public string destination;          // Variável string que armazena o nome da cena que o player irá 
    public TeleportLocation teleport;   // Variável do tipo TeleportLocation que armazena a posição inicial do player na próxima cena
    public GameObject fadeInPanel;      // Variável que armazena o prefab do objeto que realiza o Fade In da cena
    public GameObject fadeOutPanel;     // Variável que armazena o prefab do objeto que realiza o Fade Out da cena
    public float fadeWait;              // Variável que armazena o tempo total de fade entre as cenas

    /* Ao ser chamada a função
     * Caso o objeto de FadeIn esteja instanciado
     * Instancia o objeto e o destroi após 1 segundo 
     */
    private void Awake()
    {
        if(fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1.0f);
        }
    }

    // Ao ocorrer uma colisão, caso a tag do objeto seja Player, inicia a coroutine de Fade Out          
    private void OnTriggerEnter2D(Collider2D collision)
    {       

        if (collision.gameObject.CompareTag("Player"))
        {        
            StartCoroutine(FadeCoroutine());
        }
    }
    /* Coroutine responsável pelo FadeOut de uma cena para a próxima
     * Caso o objeto não seja nulo, o instancia
     * Muda a cena de maneira assíncrona após um tempo de espera
     */
    public IEnumerator FadeCoroutine()
    {
        if(fadeOutPanel != null)
        {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);                              // Aguarda pelo tempo armazenado em fadeWait para continuar a coroutine
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(destination); // Inicia uma operação assíncrona chamada asyncOperation que mudará de cena
        while (!asyncOperation.isDone)          // Enquando a cena que está sendo carregada a cena não tiver terminado
        {
            GameObject player = GameObject.Find("PlayerO(Clone)");      // Procura o player object do player
            player.transform.position = teleport.initialValue;          // Muda a posição dele para a posição inicial do objeto TeleportLocation
            yield return null;                                          // Retorna nulo enquanto o carregamento não concluir
        }


    }
}
