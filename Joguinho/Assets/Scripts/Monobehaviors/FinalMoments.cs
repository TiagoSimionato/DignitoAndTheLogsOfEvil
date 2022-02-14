///<summary>
/// Edições do código:
/// 19/04: Tiago Simionato: Código criado
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalMoments : MonoBehaviour
{
    public GameObject fadeVictory;      // Armazena o objeto de fade de cena ao player ganhar do boss

    void Start()
    {
        StartCoroutine(VictoryCoroutine()); // Inicia a corotina de vitoria
    }
    /* Corotina após o player ganhar do boss
     * Instancia o fade entre as cenas para a vitoria
     * Espera por 15 segundos
     * Muda para a cena de creditos de maneira assincrona
     * Destroi os objetos do player, healthbar e inventario
     * Se autodestroi
     */
    public IEnumerator VictoryCoroutine()
    {
        if (fadeVictory != null)
        {
            Instantiate(fadeVictory, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(15);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Creditos");
        Destroy(GameObject.Find("PlayerO(Clone)"));
        Destroy(GameObject.Find("HealthBarO(Clone)"));
        Destroy(GameObject.Find("InventoryO(Clone)"));
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
        Destroy(gameObject);
    }
}
