///<summary>
/// Edi��es do c�digo:
/// 19/04: Walter Oliveira: C�digo criado
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public GameObject fadeDeath;            // Objeto que armazena o prefab de Fade ap�s a morte do personagem

    void Start()
    {
        StartCoroutine(DeathCoroutine());   // Inicia a Coroutine de morte
    }

    /* Coroutina de morte do personagem
     * Caso exista o prefab de fade, o instancia
     * Ap�s 9 segundos muda para a cena de menu e destroi esse objeto 
     */
    public IEnumerator DeathCoroutine()
    {
        Debug.Log("Started Coroutine");
        if (fadeDeath != null)
        {
            Instantiate(fadeDeath, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(9);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("MainMenu");    // Mudan�a de cena de maneira ass�ncrona ao fade out de morte
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
        Destroy(gameObject);
    }

}
