using UnityEngine;
using UnityEngine.UI;

public class Movimentacao : MonoBehaviour {
       
    public Rigidbody2D player;                      //JOGADOR
    public RawImage rImg;                           //IMAGEM DE FUNDO QUE FICA MEXENDO

    int forcapulo = 200;                            //FORÇA DE PULO
    int velocidade = 7;                             //VELOCIDADE DA CORRIDA
    int direcao = 0;                                //ORIENTAÇÃO NO EIXO X

    private bool olhandodireita = true;             //VERIFICA ORIENTAÇÃO
    private bool pisandochao = false;               //VERIFICA SE ESTÁ NO CHÃO

    void Start()                                               
    {
        player = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Rect temp = new Rect(rImg.uvRect);          //RAW IMG                                    
        temp.x += direcao * 0.003f;                 //VELOCIDADE
        rImg.uvRect = temp;

        transform.Translate(new Vector3((direcao * velocidade) * Time.deltaTime, 0, 0));        //MOVE O JOGADOR
    }

    void Flip()                                                 //VIRA PARA O OUTRO LADO
    {
        olhandodireita = !olhandodireita;                       //INVERTE A ORIENTAÇÃO
        Vector3 theScale = transform.localScale;                //PEGA O VALOR DA ESCALA
        theScale.x *= -1;                                       //INVERTE A ESCALA
        transform.localScale = theScale;                        //VALIDA
    }

    public void Direita()                                       //MÉTODO QUE VIRA PRO LADO
    {
        direcao = 1;                                            //ATRIBUI VALOR POSITIVO PARA ANDAR NO EIXO X
        if (direcao > 0 && olhandodireita == false)
        {
            Flip();                                             //VERIFICA SE ESTÁ ANDANDO NA DIREÇÃO DO EIXO POSITIVO
        }
    }

    public void Esquerda()                                      //MÉTODO QUE VIRA PRO LADO
    {
        direcao = -1;                                           //ATRIBUI VALOR NEGATIVO PARA ANDAR NO EIXO X
        if (direcao < 0 && olhandodireita == true)
        {
            Flip();                                             //VERIFICA SE ESTÁ ANDANDO NA DIREÇÃO DO EIXO NEGATIVO
        }
    }

    public void Para()                                          //PARA DE ANDAR
    {
        direcao = 0;                                            //PARADO NO EIXO X
    }

    public void Pula()                                           //SAI DO CHÃO
    {
        if (pisandochao)                            
        {
            player.AddForce(new Vector2(0, forcapulo));         //ADICIONA UMA FORÇA ATRAVÉS DA VARIÁVEL 'forcapulo'                            
            pisandochao = false;                                //SE PULOU, NÃO PDOE PULAR DE NOVO
        }
    }

    public void OnCollisionEnter2D(Collision2D Chao)            //COMPARA TAG COM O CHÃO
    {
        if (Chao.gameObject.CompareTag("Chao"))
        {
            pisandochao = true;                                 //SE ´TA TOCANDO NO CHÃO, PULO LIBERADO
        }
    }
}     
