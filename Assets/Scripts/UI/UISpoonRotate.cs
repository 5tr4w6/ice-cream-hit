using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISpoonRotate : MonoBehaviour
{
    float speed = 5.0f;
    float rotation = 0.0f;

    void Update()
    {
       // if (rotation < 2205.0f) {
            RotateSpoon();
        //}
    }

    void RotateSpoon()
    {
        rotation += speed;
        // speed += 0.10f;
        // transform.rotation = Quaternion.Euler(0, 0, -Mathf.Clamp(rotation, 0, 2205.0f));
        transform.rotation = Quaternion.Euler(0, 0, -rotation);
    }
}
