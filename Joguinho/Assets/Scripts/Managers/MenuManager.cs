///<summary>
/// Edi��es do c�digo:
/// 20/04: Walter Oliveira: C�digo criado
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject fadeInPanel;      // Game Object que armazena o prefab de Fade In entre as cenas
    public GameObject fadeOutPanel;     // Game Object que armazena o prefab de Fade Out entre as cenas
    public float fadeWait;              // Vari�vel que armazena o tempo entre os fade


 /* Coroutine respons�vel pelo FadeOut de uma cena para a pr�xima
  * Caso o objeto n�o seja nulo, o instancia
  * Muda a cena de maneira ass�ncrona ap�s um tempo de espera
  */
    public IEnumerator FadeCoroutine(string scene)
    {
        if (fadeOutPanel != null)
        {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);                           // Aguarda pelo tempo armazenado em fadeWait para continuar a coroutine
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene); // Carrega a cena de maneira ass�ncrona
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }

    // Muda a cena para o in�cio do jogo
    public void StartGame()
    {
        SceneManager.LoadScene("InteriorCasa");
    }
    // Muda a cena para o menu inicial
    public void MenuGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
    // Muda a cena para o menu de cr�ditos
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
