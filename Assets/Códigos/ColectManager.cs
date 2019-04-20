using UnityEngine;
using UnityEngine.UI;


public class ColectManager : MonoBehaviour
{
    public static ColectManager instance;
    public int AcaiTotal = 0;

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
    }

    void Start()
    {
        GameStartScore();
    }


    public void GameStartScore()
    {
        if (PlayerPrefs.HasKey("AcaiSalvo"))
        {
            AcaiTotal = PlayerPrefs.GetInt("AcaiSalvo");
            Salva(AcaiTotal);
        }
        else
        {
            AcaiTotal = 0;
            PlayerPrefs.SetInt("AcaiSalvo", AcaiTotal);
            Salva(AcaiTotal);
        }
    }

    public void UpdateScore()
    {
        AcaiTotal = PlayerPrefs.GetInt("AcaiSalvo");
    }

    public void PegouAcai(int Coletado)
    {
        AcaiTotal += Coletado;
        Salva(AcaiTotal);
    }

    public void PerdeuAcai(int Coletado)
    {
        AcaiTotal -= Coletado;
        Salva(AcaiTotal);
    }

    public void Salva(int Coletado)
    {
        PlayerPrefs.SetInt("AcaiSalvo", AcaiTotal);
    }
}
