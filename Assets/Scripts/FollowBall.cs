using System.Security.Cryptography;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        if(player.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        }
    }
}
