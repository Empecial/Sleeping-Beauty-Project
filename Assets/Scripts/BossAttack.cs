using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{

    public float speed;

    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
