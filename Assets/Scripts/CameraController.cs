using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 minValue, maxValue;
    [SerializeField] private float smoothFactor;

    void Start()
    {
        transform.position = player.position;
    }
    // Update is called once per frame
    void Update()
    {

        Vector3 targetPos = player.position;

        Vector3 boundPos = new Vector3(
        Mathf.Clamp(targetPos.x, minValue.x, maxValue.x),
        Mathf.Clamp(targetPos.y, minValue.y, maxValue.y),
        Mathf.Clamp(targetPos.z, minValue.z,maxValue.z));

        Vector3 lerpPos = Vector3.Lerp(transform.position, boundPos, smoothFactor*Time.deltaTime);
        transform.position = lerpPos;
    }
}
