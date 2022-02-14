///<summary>
/// Edições do código:
/// 20/04: Walter Oliveira: Código criado
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject fadeInPanel;      // Game Object que armazena o prefab de Fade In entre as cenas
    public GameObject fadeOutPanel;     // Game Object que armazena o prefab de Fade Out entre as cenas
    public float fadeWait;              // Variável que armazena o tempo entre os fade


 /* Coroutine responsável pelo FadeOut de uma cena para a próxima
  * Caso o objeto não seja nulo, o instancia
  * Muda a cena de maneira assíncrona após um tempo de espera
  */
    public IEnumerator FadeCoroutine(string scene)
    {
        if (fadeOutPanel != null)
        {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);                           // Aguarda pelo tempo armazenado em fadeWait para continuar a coroutine
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene); // Carrega a cena de maneira assíncrona
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }

    // Muda a cena para o início do jogo
    public void StartGame()
    {
        SceneManager.LoadScene("InteriorCasa");
    }
    // Muda a cena para o menu inicial
    public void MenuGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
    // Muda a cena para o menu de créditos
    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    // Fecha o jogo
    public void Exit()
    {
        Application.Quit();
    }

}
