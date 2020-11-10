using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armRotation : MonoBehaviour
{
    public int rotationOffset = 0;
    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; // subtracting the mouse position from the players position
        difference.Normalize(); //normalizing the vector means that all the sum of the vector will be equal to 1
        float rotationz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;//finding the angle using Mathf.Atan2 and converting it to degrees using Mathf.Rad2Deg
        transform.rotation = Quaternion.Euler(0f, 0f, rotationz+rotationOffset);
    }
}
