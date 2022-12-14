using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatform : MonoBehaviour
{
    [SerializeField] Transform  target;  
    [SerializeField] float      speed;
                     Vector3    start,  end;
    void Start()
    {
        if (target != null)
        {
            target.transform.parent = null; 
            start = transform.position;
            end = target.position;
        }
    }
    void FixedUpdate()
    {
        if(target != null)
        {
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, fixedSpeed);           
        }
        if(transform.position == target.position)
        {
            target.position = (target.position == start) ? end : start;
        }
    }
}
