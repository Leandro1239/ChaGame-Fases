using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()    
    {
        if (instance == null)                                //FAZ COM QUE O CÓDIGO NÃO SEJA DESTRUIDO TODA VEZ QUE REINICIAR O JOGO
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ColectManager.instance.GameStartScore();            //INICIA O MÉTODO 'GameStartScore' DA CLASSE 'ColectManager'
    }

    void Update()
    {
        ColectManager.instance.UpdateScore();               //INICIA O MÉTODO 'UpdateScore' DA CLASSE 'ColectManager'
        UIManager.instance.UpdateUI();                      //INICIA O MÉTODO 'UpdateUI' DA CLASSE 'UIManager'

        /*if (Sintoma.instance.ValorAtual == 0)
        {
            GameOver();
        }*/
    }

    void GameOver()
    {
        UIManager.instance.GameOverUI();
    }

    void PassLevel()
    {
        UIManager.instance.PassLevelUI();
    }

    void Pause()
    {
        UIManager.instance.PauseUI();
    }
}
