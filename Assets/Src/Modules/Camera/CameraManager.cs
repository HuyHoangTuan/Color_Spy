using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject target;

    [SerializeField] private float smoothSpeed = 0.0f;
    [SerializeField] private Vector3 offset = Vector3.zero;

    [SerializeField] private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    protected void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        if (target != null)
        {
            this.transform.position = Vector3.SmoothDamp(
                this.transform.position,
                this.target.transform.position + this.offset, 
                ref this.velocity, 
                this.smoothSpeed);
            
        }
    }
}
