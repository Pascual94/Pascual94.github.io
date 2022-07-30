using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Enemy : MonoBehaviour
{

    public float  visionRadious;
    public float speed;

    GameObject player;

    Vector3 initialPosition;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        initialPosition = transform.position;
    }

    void Update()
    {
        Vector3 target = initialPosition;

        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < visionRadious) target = player.transform.position;

        float fixedSpeed = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);

        Debug.DrawLine(transform.position, target, Color.red);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadious);
    }
}
