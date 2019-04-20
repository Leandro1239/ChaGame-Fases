using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private Text Coleta_Total;
    //private Text EstadoSaude;

    private GameObject PainelLose;
    private GameObject PainelWin;
    private GameObject PainelPause;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += Carrega;
        LigaDesligaPainel();
    }

    void Carrega (Scene cena, LoadSceneMode modo)
    {
        Coleta_Total = GameObject.Find("TotalAçai_text").GetComponent<Text>();        //PROCURA SOZINHO O TEXTO
        //EstadoSaude = GameObject.Find("ValorSaude_text").GetComponent<Text>();

        PainelLose = GameObject.Find("Panel - Lose");
        PainelWin = GameObject.Find("Panel - Win");
        PainelPause = GameObject.Find("Panel - Pause");
    }

    public void UpdateUI()
    {
        Coleta_Total.text = ColectManager.instance.AcaiTotal.ToString();
       // EstadoSaude.text = Sintoma.instance.ValorAtual.ToString();
    }

    public void GameOverUI()
    {
        PainelLose.SetActive(true);
    }

    public void PassLevelUI()
    {
        PainelWin.SetActive(true);
    }

    public void PauseUI()
    {
        PainelPause.SetActive(true);
    }


    void LigaDesligaPainel()
    {
        StartCoroutine(Tempo());
    }

    IEnumerator Tempo()
    {
        yield return new WaitForSeconds(0.001f);
        /*PainelLose.SetActive(false);
        PainelWin.SetActive(false);
        PainelPause.SetActive(false);*/
    }
}
