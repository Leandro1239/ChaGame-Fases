using UnityEngine;
using UnityEngine.UI;


public class ColectManager : MonoBehaviour
{
    public static ColectManager instance;           //DEFINE A CLASSE COMO PUBLICA
    public int AcaiTotal;

    void Awake()
    {
        if (instance == null)                       //FAZ COM QUE O CÓDIGO NÃO SEJA DESTRUIDO TODA VEZ QUE REINICIAR O JOGO
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
        GameStartScore();                           //FORÇA O INICIO DO MÉTODO
    }

    public void GameStartScore()
    {
        if (PlayerPrefs.HasKey("AcaiSalvo"))                //VERIFICA SE TEM ALGO SALVO NA CHAVE 'AcaiSalvo'
        {
            AcaiTotal = PlayerPrefs.GetInt("AcaiSalvo");    //SE TIVER, PEGA O VALOR DA CHAVE E ATRIBUI NA VARIÁVEL 'AcaiTotal'
        }
        else
        {
            AcaiTotal = 0;                                  //SE NÃO TEM NADA SALVO COMEÇA COM ZERO
            PlayerPrefs.SetInt("AcaiSalvo", AcaiTotal);     //ATRIBUI O ZERO NO VARIÁVEL
        }
    }

    public void PegouAcai(int Coletado)                     //Coletado É A VARIAVEL CRIADA PARA COMUNICAÇÃO ENTRE CÓDIGOS ATRAVÉS DO ARGUMENTO
    {
        AcaiTotal += Coletado;                              //SOMA À VARIÁVEL 'AcaiTotal' O VALOR COLETADO NO ARGUMENTO DADO NA CLASSE 'ColetaAcai'
        Salva(AcaiTotal);                                   //SALVA
    }

    public void PerdeuAcai(int Coletado)
    {
        AcaiTotal -= Coletado;                              //SUBTRAI À VARIÁVEL 'AcaiTotal' O VALOR COLETADO NO ARGUMENTO DADO NA CLASSE 'ColetaAcai'
        Salva(AcaiTotal);                                   //SALVA
    }

    public void Salva(int Coletado)
    {
        PlayerPrefs.SetInt("AcaiSalvo", AcaiTotal);         //GUARDA O VALOR DA VARIÁVEL NA CHAVE 'AcaiSalvo'
    }

    public void UpdateScore()
    {
        AcaiTotal = PlayerPrefs.GetInt("AcaiSalvo");        //ATUALIZA O VALOR QUE TEM NA CHAVE PARA A VARIÁVEL
    }
}
