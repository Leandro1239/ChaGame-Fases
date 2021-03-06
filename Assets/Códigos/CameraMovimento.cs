﻿using UnityEngine;
using System.Collections;

public class CameraMovimento : MonoBehaviour
{
    public float dampTime = 0.15f;                  //SUAVIDADE DA CAMERA
    private Vector3 velocity = Vector3.zero;        //VELOCIDADE
    float x = 0.3f;                                 //AJUSTE NO EIXO X
    float y = 0.2f;                                 //AJUSTE NO EIXO X
    public Transform player;                        //DEFINE O PLAYER

    void Update()
    {
        if (player)                                 //SEGUE O PLAYER
        {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(player.position);
            Vector3 delta = player.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(x, y, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
        
    }
}
