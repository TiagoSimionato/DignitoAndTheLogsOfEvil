/// <summary>
/// Edições do código:
/// 15/04: Tiago Simionato: Código criado, implementado para o Spawn do player em cada cena
/// 17/04: Lucas Tedim: Função update criada para terminar os Spawns após um determinado número de Caracteres já ter spawnado (usado para inimigos)
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject thingToSpawn;

    public float spawnPeriod;   //Tempo entre cada Spawn 
    public float spawnStart;    //Tempo entre o carregamento da cena e início dos Spawns
    public int spawnAmount;     //Quantidade total de entidades a serem implementadas na cena
    float timer;                //Variável que guarda o tempo desde o início da cena

    void Start()
    {
        timer = 0;
        if (spawnPeriod > 0)
        {
            InvokeRepeating("Spawn0", spawnStart, spawnPeriod);
        }
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > (spawnAmount*spawnPeriod) + spawnStart)
        {
            CancelInvoke("Spawn0");
        }
    }

    public GameObject Spawn0()
    {
        if (thingToSpawn != null)
        {
            return Instantiate(thingToSpawn, transform.position, Quaternion.identity);
        }
        return null;
    }
}
