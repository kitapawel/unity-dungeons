using UnityEngine;
using System.Collections;

public class CameraLerp : MonoBehaviour
{

    float speed = 1f;

    [SerializeField]
    private Transform startPos;
    [SerializeField]
    private Transform endPos;

    protected void Start()
    {
        
    }

    protected void Update()
    {

        transform.position = Vector3.Lerp(transform.position, endPos.position, Time.deltaTime * speed);

    }
}