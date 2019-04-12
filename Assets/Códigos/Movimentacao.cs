using UnityEngine;

public class Movimentacao : MonoBehaviour {
       
    public Rigidbody2D player;                                  //JOGADOR
    int forcapulo = 200;
    int velocidade = 7;
    int direcao = 0;
    private bool olhandodireita = true;
    private bool pisandochao = false;

    void Start()                                               
    {
        player = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.Translate(new Vector3((direcao * velocidade) * Time.deltaTime, 0, 0));        //MOVE O PERSONAGEM
    }

    void Flip()                                                             //VIRA PARA O OUTRO LADO
    {
        olhandodireita = !olhandodireita;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void Direita()                                                   //MÉTODO QUE VIRA PRO LADO
    {
        direcao = 1;
        if (direcao > 0 && olhandodireita == false)
        {
            Flip();
        }
    }

    public void Esquerda()                                                  //MÉTODO QUE VIRA PRO LADO
    {
        direcao = -1;
        if (direcao < 0 && olhandodireita == true)
        {
            Flip();
        }
    }

    public void Para()                                                      //PARA DE ANDAR
    {
        direcao = 0;
    }

    public void Pula()                                                      //SAI DO CHÃO
    {
        if (pisandochao)                            
        {
            player.AddForce(new Vector2(0, forcapulo));                                         
            pisandochao = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D Chao)                        //COMPARA TAG COM O CHÃO
    {
        if (Chao.gameObject.CompareTag("Chao"))
        {
            pisandochao = true;
        }
    }
}     
