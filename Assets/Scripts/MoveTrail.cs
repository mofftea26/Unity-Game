using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrail : MonoBehaviour
{
    public float speed=400f;

    // Update is called once per frame
    void Update()
    {   //to move the bullet trail
        transform.Translate(Vector3.right*Time.deltaTime*speed);
        //to destroy it after 1 sec
        Destroy(gameObject,1);
    }
}
