using UnityEngine;
public class WingFlap : MonoBehaviour
{
    public float flapSpeed = 2f;
    public float minAngle = -10f;
    public float maxAngle = 10f; 

    private float t = 0f; // Timer for interpolation

    void Update()
    {
        t = Mathf.PingPong(Time.time * flapSpeed, 1f);
        float angle = Mathf.Lerp(minAngle, maxAngle, t);

        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}

