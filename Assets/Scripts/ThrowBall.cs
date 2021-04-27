using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    public GameObject ballObj;
    //public GameObject throwPosition;
    public float coolDown;
    public float throwSpeed;
    public bool canThrow;

    public GameObject dog;

    public AudioSource bark;

    public void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && canThrow == true)
        {
            bark.Play();
            GameObject Go = Instantiate(ballObj, transform.position, gameObject.transform.rotation);
            Go.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * throwSpeed, ForceMode.Impulse);
            dog.gameObject.GetComponent<dogController>().ball = Go;
            canThrow = false;
        }
    }
    
}
