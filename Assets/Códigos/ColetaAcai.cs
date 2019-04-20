using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ColetaAcai : MonoBehaviour
{
    public int AcaiFase;                                             //AÇAI
    public Text Coleta_Fase;                                        //TEXTO

    public void OnTriggerEnter2D(Collider2D Coletar)                    //COLETA E CONTA AÇAI
    {
        if (Coletar.gameObject.CompareTag("Coletor"))
        {
            ColectManager.instance.PegouAcai(1);                        //CHAMA O METODO 'PegouAcai' DA CLASSE 'ColectManager' E CONTA +1 EM SEU ARGUMENTO, ACUMULANDO PARA O TOTAL RESGATADO
            Destroy(Coletar.gameObject);                                //DESTROI O "Coletor", QUE É A TAG DO ACAI
            AcaiFase += 1;                                              //CONTA O AÇAI OBTIDO NA FASE
            Coleta_Fase.text = AcaiFase.ToString();                     //MOSTRA EM TEXTO 
        }
    }
}
