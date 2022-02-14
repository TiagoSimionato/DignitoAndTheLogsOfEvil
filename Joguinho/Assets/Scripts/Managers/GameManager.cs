///<summary>
/// Edições do código:
/// 14/04: Tiago Simionato: Código criado
/// 17/04: Walter Oliveira: Mudança ao adicionar o script de DontDestroyOnLoad
/// 21/04: Walter Oliveira: Comentários
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CameraManager CameraManager;     // Objeto do tipo CameraManager que armazena o script que comanda a camera

    public Spawner playerSpawn;             // Objeto do tipo Spawner que armazena o prefab de posição do spawn do player
    private GameObject player;              // Objeto que armazena o prefab do Player
    
    /* Ao iniciar o código, procura o Objeto PlayerO(Clone), caso não encontre, realiza o spawn do player
     * Caso encontre, faz a camera seguir o player
     */
    void Start()
    {
        player = GameObject.Find("PlayerO(Clone)");
        Debug.Log(player);
        if (player != null)
        {
            CameraManager.virtualCamera.Follow = player.transform;
        }
        else
        {
            SpawnPlayer();
        }
        
    }
    
    // Se o prefab de spawn não estiver vazio chama a função que spawna o player e faz a camera segui-lo 
    void SpawnPlayer()
    {
        if (playerSpawn != null)
        {
            
            GameObject player = playerSpawn.Spawn0();
            CameraManager.virtualCamera.Follow = player.transform;
        }   
    }
}
