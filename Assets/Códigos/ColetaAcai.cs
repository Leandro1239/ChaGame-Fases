using UnityEngine;
using UnityEngine.SceneManagement;

public class ColetaAcai : MonoBehaviour
{
    int coleta = 0;                                             //MOEDA
    public TextMesh Total_coleta;

    public void OnTriggerEnter2D(Collider2D Coletar)                         //COLETA E CONTA MOEDA
    {
        if (Coletar.gameObject.CompareTag("Coletor"))
        {
            Destroy(Coletar.gameObject);
            coleta += 1;
            Total_coleta.text = coleta.ToString();
        }
    }

    public void OnCollisionEnter2D(Collision2D Saida)                        //GANHOU
    {
        if (Saida.gameObject.CompareTag("Saida"))       
        {
            if (coleta >= 5)
            {
                SceneManager.LoadScene("Passou");
            }
        }
    }
}
