using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sintoma : MonoBehaviour {

    public Text Saude;

    int ValorAtual = 30;
    int Dano = 10;
    int Energia = 10;

    public void OnCollisionEnter2D(Collision2D Dano)                        //TOMOU DANO
    {
        if (Dano.gameObject.CompareTag("Inimigo"))              
        {
            Destroy(Dano.gameObject);
            VidaPerde();
        }
    }

    public void OnTriggerEnter2D(Collider2D Vida)                         //GANHA VIDA AO PASSAR NA BARRACA
    {
        if (Vida.gameObject.CompareTag("Vida"))
        {
            VidaGanha();
            Destroy(Vida.gameObject);
        }
    }

    public void VidaPerde()
    {
        if (ValorAtual > 0)
        {
            ValorAtual -= Dano;
            EstadoSaude();         
        }
    }

    public void VidaGanha()
    {
        if (ValorAtual < 30)
        {
            ValorAtual += Energia;
            EstadoSaude();
        }
    }

    public void EstadoSaude()
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

        if (ValorAtual == 0)                    //MORREU
        {
            SceneManager.LoadScene("Morreu");
        }
    }
   
}
