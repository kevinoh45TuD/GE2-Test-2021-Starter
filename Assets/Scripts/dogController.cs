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

    public float waitTime;

    public GameObject tail;
    public bool tailMove;
    public Vector3 rotateVector;
    
    public void Update()
    {

        if (tailMove)
        {
            rotateVector += new Vector3(0f, 10f, 0f);
            tail.transform.rotation = Quaternion.Euler(rotateVector);
        }
        
        if (waitTime > 0)
        {
            waitTime--;
        }

        if (ball == null)
        {
            gameObject.GetComponent<Arrive>().enabled = true;
            gameObject.GetComponent<Seek>().enabled = false;
            
            
            if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= 10f)
            {
                hasArrived = true;
                

            }
            
            if (hasArrived)
            {
                gameObject.GetComponent<Arrive>().targetGameObject = null;
                gameObject.GetComponent<Arrive>().enabled = false;
                gameObject.GetComponent<Boid>().velocity = Vector3.zero;
                
            }

        }
        
        if (ball != null)
        {
            if (!hasBall)
            {
                gameObject.GetComponent<Seek>().enabled = true;
                gameObject.GetComponent<Seek>().targetGameObject = ball;
                tailMove = true;
            }
            
            
            if (Vector3.Distance(gameObject.transform.position ,ball.transform.position) <= 2f && waitTime <= 0f && hasBall == false)
            {
                ballPickedUp();
                
            }
            
            /*
            if (hasBall)
            {
                hasArrived = false;
                gameObject.GetComponentInChildren<Arrive>().enabled = true;
            }
            */
            if (hasBall)
            {
                if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= 10f)
                {
                    ball.transform.parent = null;
                    ball = null;
                    waitTime = 2f;
                    tailMove = false;
                    tail.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }
            }
            
            
        }
    }

    public void ballPickedUp()
    {
        gameObject.GetComponent<Arrive>().enabled = true;
        gameObject.GetComponent<Arrive>().targetGameObject = player;
        gameObject.GetComponent<Seek>().enabled = false;
        hasBall = true;
        hasArrived = false;
        ball.transform.position = ballPos.transform.position;
        ball.transform.rotation = ballPos.transform.rotation;
        ball.transform.parent = ballPos.transform;
        
        
    }
}
