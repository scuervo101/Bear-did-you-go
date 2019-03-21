using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float smoothing = 5f;

    Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
        //Vector3 test = new Vector3(0.0f, offset.y, 0.0f);
        //Debug.Log();
    }

    void FixedUpdate()
    {

        //Vector3 offsetAdj = new Vector3(offset.x, offset.y, 0.0f);
        Vector3 targetCamPos = target.position + offset;
        Vector3 proper = new Vector3(targetCamPos.x, targetCamPos.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, proper, smoothing * Time.deltaTime);
    }
}
