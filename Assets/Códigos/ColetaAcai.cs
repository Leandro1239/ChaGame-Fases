using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ColetaAcai : MonoBehaviour
{
    public int AcaiFase = 0;                                             //MOEDA
    public Text Total_Fase;

    public void OnTriggerEnter2D(Collider2D Coletar)                         //COLETA E CONTA MOEDA
    {
        if (Coletar.gameObject.CompareTag("Coletor"))
        {
            ColectManager.instance.PegouAcai(1);
            Destroy(Coletar.gameObject);
            AcaiFase += 1;
            Total_Fase.text = AcaiFase.ToString();
        }
    }
}
