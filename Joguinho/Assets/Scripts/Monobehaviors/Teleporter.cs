///<summary>
/// Edi��es do c�digo:
/// 16/04: Walter Oliveira: C�digo criado
/// 17/04: Walter Oliveira: Adi��o de vari�vel para mudar a cena do teleporte
/// 20/04: Walter Oliveira: Adi��o da corrotina para o fade entre as cenas
/// 21/04: Walter Oliveira: Coment�rios
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public string destination;          // Vari�vel string que armazena o nome da cena que o player ir� 
    public TeleportLocation teleport;   // Vari�vel do tipo TeleportLocation que armazena a posi��o inicial do player na pr�xima cena
    public GameObject fadeInPanel;      // Vari�vel que armazena o prefab do objeto que realiza o Fade In da cena
    public GameObject fadeOutPanel;     // Vari�vel que armazena o prefab do objeto que realiza o Fade Out da cena
    public float fadeWait;              // Vari�vel que armazena o tempo total de fade entre as cenas

    /* Ao ser chamada a fun��o
     * Caso o objeto de FadeIn esteja instanciado
     * Instancia o objeto e o destroi ap�s 1 segundo 
     */
    private void Awake()
    {
        if(fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1.0f);
        }
    }

    // Ao ocorrer uma colis�o, caso a tag do objeto seja Player, inicia a coroutine de Fade Out          
    private void OnTriggerEnter2D(Collider2D collision)
    {       

        if (collision.gameObject.CompareTag("Player"))
        {        
            StartCoroutine(FadeCoroutine());
        }
    }
    /* Coroutine respons�vel pelo FadeOut de uma cena para a pr�xima
     * Caso o objeto n�o seja nulo, o instancia
     * Muda a cena de maneira ass�ncrona ap�s um tempo de espera
     */
    public IEnumerator FadeCoroutine()
    {
        if(fadeOutPanel != null)
        {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);                              // Aguarda pelo tempo armazenado em fadeWait para continuar a coroutine
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(destination); // Inicia uma opera��o ass�ncrona chamada asyncOperation que mudar� de cena
        while (!asyncOperation.isDone)          // Enquando a cena que est� sendo carregada a cena n�o tiver terminado
        {
            GameObject player = GameObject.Find("PlayerO(Clone)");      // Procura o player object do player
            player.transform.position = teleport.initialValue;          // Muda a posi��o dele para a posi��o inicial do objeto TeleportLocation
            yield return null;                                          // Retorna nulo enquanto o carregamento n�o concluir
        }


    }
}
