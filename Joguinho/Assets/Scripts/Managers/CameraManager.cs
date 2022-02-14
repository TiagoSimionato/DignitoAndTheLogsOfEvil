///<summary>
/// Edi��es do c�digo:
/// 14/04: Walter Oliveira: C�digo criado
/// 16/04: Walter Oliveira: Adi��o do Cinemachine
/// 21/04: Walter Oliveira: Coment�rios
/// </summary>

using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager sharedInstance = null;          // Vari�vel que armazena uma objeto do tipo camera manager

    [HideInInspector]
    public CinemachineVirtualCamera virtualCamera;              // Vari�vel que armazena um objeto de camera do Cinemachine 
    /*
     * Ao chamar o camera manager
     * Caso j� tenha um objeto Camera manager e ele seja diferente deste objeto
     * Destroi o Objeto
     * Caso contrario
     * Procura um objeto na hierarquia com a tag Virtual Camera e busca o componente de Camera virtual do Cinemachine 
     */
    private void Awake()
    {
        if (sharedInstance != null && sharedInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            sharedInstance = this;
        }
        GameObject vCamGameObject = GameObject.FindWithTag("Virtual Camera");
        virtualCamera = vCamGameObject.GetComponent<CinemachineVirtualCamera>();
    }
}
