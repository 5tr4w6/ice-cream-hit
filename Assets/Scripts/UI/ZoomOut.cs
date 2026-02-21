using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour
{
    public Camera cam;
    public float targetSize = 42f;
    public float duration = 2f;
    void Start()
    {
        if (cam == null) cam = Camera.main;
        StartCoroutine(ChangeCameraSize(targetSize, duration));
    }
    IEnumerator ChangeCameraSize(float newSize, float time)
    {
        float elapsedTime = 0f;
        float startSize = cam.orthographicSize;

        while (elapsedTime < time)
        {
            cam.orthographicSize = Mathf.Lerp(startSize, newSize, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cam.orthographicSize = newSize; // Ensure final value is set
    }
}
