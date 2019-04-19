using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    //private Text pontosUI;
    private GameObject PainelLose;

    private void Awake()
    {
        LigaDesligaPainel();
    }
    void Carrega (Scene cena, LoadSceneMode modo)
    {
        PainelLose = GameObject.Find("Panel - Pause");
    }

    public void GameOverUI()
    {
        PainelLose.SetActive(true);
    }

    void LigaDesligaPainel()
    {
        StartCoroutine(tempo());
    }

    IEnumerator tempo()
    {
        yield return new WaitForSeconds(0.0001f);
        PainelLose.SetActive(false);
    }
    void Update()
    {
        
    }
}
