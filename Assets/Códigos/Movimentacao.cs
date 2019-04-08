using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour {
       
    /*int moedas = 0;                      //MOEDA
    public TextMesh Total_Moeda;*/

    public Rigidbody2D player;

    public float velocidade;
    public float forcapulo;
    public float direcao = 0;

    private bool olhandodireita = true;
    //private bool pulo = false;
    private bool pisandochao = false;
    //public Transform chegachao;

    private Animator Anima;

    void Start ()                                               //Jogador
    {
        player = gameObject.GetComponent<Rigidbody2D>();
        Anima = gameObject.GetComponent<Animator>();
        //chegachao = gameObject.transform.Find("Checador");

	}

    private void FixedUpdate()
    {
        Mover();
        
        if (direcao > 0 && !olhandodireita)
        {
            Flip();
        }

        else if (direcao > 0 && !olhandodireita)
        {
            Flip();
        }
    }

    void Flip()
    {
        olhandodireita = !olhandodireita;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void Direita()
    {
        direcao = 5;
    }

    public void Esquerda()
    {
        direcao = -5;
    }

    public void Mover()
    {
        player.velocity = new Vector2(direcao * velocidade, player.velocity.y);
        //pisandochao = Physics2D.Linecast(transform.position, chegachao.position, 1 << LayerMask.NameToLayer("Chao"));
    }
    
    public void Pula()
    {
        if (pisandochao)                            //PULA com o botão
        {
            player.AddForce(new Vector2(0, forcapulo));                                         //SAI DO CHÃO                                                              //CONTATO COM O CHAO
        }
    }

    public void OnCollisionEnter2D(Collision2D Chao)
    {
        if (Chao.gameObject.CompareTag("Chao"))
        {
            pisandochao = true;
        }

    }

    /*public void OnTriggerEnter2D(Collider2D coletar)                         //COLETA E CONTA MOEDA
    {
        if (coletar.gameObject.CompareTag("coin"))
        {
            Destroy(coletar.gameObject);
            moedas += 1;
            Total_Moeda.text = moedas.ToString();
        }
    }*/
}     
