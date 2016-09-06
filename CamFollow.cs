using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {

    public Transform target;
    private Vector3 offset;
    


    void Start()
    {
        offset = transform.position - target.transform.position;
        transform.position = target.transform.position + offset;
    }
    
    void FixedUpdate()
    {
        CameraFollow();        
    }

    public void CameraFollow()
    {
        transform.position = target.transform.position + offset;
    }
    
}
