using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowIt : MonoBehaviour
{
    private Transform LookAt;
    private Vector3 startOffset;
    public string toFollow;
    
    // Start is called before the first frame update
    void Start()
    {
        LookAt = GameObject.FindGameObjectWithTag(toFollow).transform;
        startOffset = transform.position - LookAt.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = LookAt.position + startOffset;
    }
}
