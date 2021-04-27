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

    public void Update()
    {
        if (canThrow == false)
        {
            coolDown += Time.deltaTime;
        }
        
        if (coolDown >= 5f)
        {
            coolDown = 0f;
            canThrow = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canThrow == true)
        {
            GameObject Go = Instantiate(ballObj, transform.position, gameObject.transform.rotation);
            Go.GetComponent<Rigidbody>().AddForce(Vector3.forward * throwSpeed, ForceMode.Impulse);
            canThrow = false;
        }
    }
    
}
