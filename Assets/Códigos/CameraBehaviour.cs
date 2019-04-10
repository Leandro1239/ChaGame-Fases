using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour
{
    public float dampTime = 0.15f;                  //SUAVIDADE DA CAMERA
    private Vector3 velocity = Vector3.zero;        //VELOCIDADE
    public Transform player;

    void Update()
    {
        if (player)                                 //SEGUE O PLAYER
        {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(player.position);
            Vector3 delta = player.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
        
    }
}
