using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogController : MonoBehaviour
{
    public GameObject ball;
    public GameObject player;
    public GameObject ballPos;

    public bool hasArrived;
    public bool hasBall;
    
    public void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= 10)
        {
            hasArrived = true;
        }

        if (hasArrived || gameObject.GetComponentInChildren<Seek>().enabled == true)
        {
            gameObject.GetComponentInChildren<Arrive>().enabled = false;
            gameObject.transform.LookAt(player.transform);
        }

        if (ball != null)
        {
            if (Vector3.Distance(gameObject.transform.position ,ball.transform.position) <= 2)
            {
                hasBall = true;
                hasArrived = false;
                ball.transform.position = ballPos.transform.position;
                ball.transform.rotation = ballPos.transform.rotation;
                ball.transform.parent = ballPos.transform;
                gameObject.GetComponentInChildren<Arrive>().enabled = true;
                gameObject.GetComponentInChildren<Seek>().enabled = false;
                
                if (hasBall)
                {
                    hasArrived = false;
                    gameObject.GetComponentInChildren<Arrive>().enabled = true;
                }
                
            }
        }
    }
}
