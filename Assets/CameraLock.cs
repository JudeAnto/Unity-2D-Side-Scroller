using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{

    public Transform target;
    public float smoothing;

    Vector3 offset;
    float lowY, highY, lowX, highX;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
        lowY = transform.position.y;
        highY = transform.position.y + 490;
        lowX = transform.position.x ;
        highX = transform.position.x + 850;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetCanPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCanPos, smoothing * Time.fixedDeltaTime);


        if (transform.position.y < lowY) transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        if (transform.position.y > highY) transform.position = new Vector3(transform.position.x, highY, transform.position.z);

        if (transform.position.x < lowX) transform.position = new Vector3(lowX, transform.position.y, transform.position.z);
        if (transform.position.x > highX) transform.position = new Vector3(highX, transform.position.y, transform.position.z);

    }
}
