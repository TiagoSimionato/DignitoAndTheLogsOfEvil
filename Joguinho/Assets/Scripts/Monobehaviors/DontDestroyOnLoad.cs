/// <summary>
/// Edições do código:
/// 15/04: Walter Olivera: Implementação do código
/// Código criado com o intuito de salvar os elementos do UI que deveriam ser mantidos ao trocar de cena (Barra de vida e Inventário)
/// Salva os elementos do prefab e os carrega para evitar que os itens coletados em uma cena sejam perdidos ao passar por um teleporter
/// 16/04: Script associado aos prefabs de coletáveis, Player e HpBar
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour 
{
    public string Tag;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(Tag);     // Procura por todos os Game Objects com a Tag desejada

        if (objs.Length > 1)        // Caso existam mais de um objeto com a mesma tag
        {
            Destroy(this.gameObject);   // Destroi esse objeto
        }

        DontDestroyOnLoad(this.gameObject);     // Muda a cena deste objeto para a que não destroi ao carregar cena
    }
}
