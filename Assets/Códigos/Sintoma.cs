using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sintoma : MonoBehaviour {

    public static Sintoma instance;

    public Text Saude;                                      //RECEBE O TEXTO ONDE ESCREVE O ATUAL ESTADO

    public int ValorAtual = 30;                             //VALOR TOTAL DA VIDA
    public int Dano = 10;                                          //VALOR QUANDO LEVA DANO
    public int Energia = 10;                                       //VALOR QUANDO RECUPERA VIDA

    public void OnCollisionEnter2D(Collision2D Dano)                        //TOMOU DANO
    {
        if (Dano.gameObject.CompareTag("Inimigo"))              
        {
            Destroy(Dano.gameObject);                       //DESTROI O INIMIGO QUANDO TOCA
            VidaPerde();                                    //CHAMA O METODO 'VidaPerde'

        }
    }

    public void OnTriggerEnter2D(Collider2D Vida)                         //GANHA VIDA AO PASSAR NA BARRACA
    {
        if (Vida.gameObject.CompareTag("Vida"))
        {
            VidaGanha();                                    //CHAMA O METODO 'VidaGanha'
            Destroy(Vida.gameObject);                       //DESTROI A CURA

        }
    }

    public void VidaPerde()                                 //MÉTODO QUE TIRA VIDA
    {
        if (ValorAtual > 0)
        {
            ValorAtual -= Dano;
            EstadoSaude();                                  //CHAMA O MÉTODO 'EstadoSaúde' PARA VALIDAR 
        }
    }

    public void VidaGanha()                                 //MÉTODO QUE DÁ VIDA
    {
        if (ValorAtual < 30)
        {
            ValorAtual += Energia;
            EstadoSaude();                                  //CHAMA O MÉTODO 'EstadoSaúde' PARA VALIDAR 
        }
    }

    public void EstadoSaude()                               //DIFINE TODOS OS ESTADOS E O QUE ACONTECE NELES
    {
        if (ValorAtual == 30)
        {
            Saude.text = "Saudável";
        }

        if (ValorAtual == 20)
        {
            Saude.text = "Doente";
        }

        if (ValorAtual == 10)
        {
            Saude.text = "Muito Doente";
        }

    }
}
