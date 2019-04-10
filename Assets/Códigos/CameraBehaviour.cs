using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, player.position.z);
    }
}
