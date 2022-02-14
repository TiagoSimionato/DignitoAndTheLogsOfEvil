///<summary>
/// Edições do código:
/// 18/04: Tiago Simionato: Código criado
/// 19/04: Tiago Simionato: Adição de novas trilhas para as cenas
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{

    Scene cenaAtual;                //guarda a cena na qual o player se encontra
    string lastScene;               //guarda o nome da cena na qual o player se encontra
    string beforeChange;            //guarda o nome de cena na qual o player estava
    public AudioClip overworld;     //guarda a musica usada no overworld
    public AudioClip overworld2;    //guarda a musica usada no menu principal do jogo
    public AudioClip cave;          //guarda a musica usada na caverna
    public AudioClip cave2;
    public AudioClip boss;          //guarda a musica usada no boss
    public AudioClip credits;       //guarda a musica usada apos vencer o boss
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();    //pega o componente de audio do objeto do music player
        cenaAtual = SceneManager.GetActiveScene();          //carrega a cena atual
        beforeChange = cenaAtual.name;                      //atualiza o nome da cena
        lastScene = beforeChange;                           //atualiza o nome da cena
        if (lastScene == "Cave" || lastScene == "BossLair") //caso o jogo cena iniciado na cena da caverna ou no boss lair
        {
            audio.clip = cave;                              //troca a musica do audiosource
            audio.Play();                                   //toca a musica da caverna
        }
    }

    // Update is called once per frame
    void Update()
    {
        cenaAtual = SceneManager.GetActiveScene();                          //carrega a cena atual
        lastScene = cenaAtual.name;                                         //pega o nome da cena atual para usar na comparação
        if (lastScene != beforeChange)                                      //caso tenha trocado de cena
        {
            AudioSource audio = GetComponent<AudioSource>();                //pega o componente de audio do objeto
            if (lastScene == "InteriorCasa" || lastScene == "OverWorld")    //se o player estiver na cena da casa ou do overworld
            {
                audio.clip = overworld;                                     //troca o clipe para a musica de overworld/casa
                audio.Play();                                               //toca a musica
            }
            else if (lastScene == "Cave")                                   //se o player estiver na cena da caverna
            {
                audio.clip = cave;                                          //troca a musica para a da caverna
                audio.Play();                                               //toca a musica da caverna
            }                                                               //a unica forma de acessar a cena boss é pela caverna, então já estará com a musica da caverna
            beforeChange = lastScene;                                       //atualiza o nome da cena para as comparaçoes seguintes
        }
    }
}
