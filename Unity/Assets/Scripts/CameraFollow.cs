using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float smoothTime = 0.3f;
    private float xVelocity = 0.0f;
    private float yVelocity = 0.0f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        float newXPosition = Mathf.SmoothDamp(transform.position.x, target.position.x + 4.0f, ref xVelocity, smoothTime);

        float newYPosition = Mathf.SmoothDamp(transform.position.y, target.position.y + 2.0f, ref yVelocity, smoothTime);
        transform.position = new Vector3((newXPosition > transform.position.x) ? newXPosition : transform.position.x, 
            newYPosition, 
            transform.position.z);
    }
}