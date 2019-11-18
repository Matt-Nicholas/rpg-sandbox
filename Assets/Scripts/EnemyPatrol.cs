using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

    float originalY;
    float originalX;

    public float floatStrength = 1;
    float floatStrangthAdjuestment;

    void Start()
    {
        floatStrangthAdjuestment = Random.Range(-2, 2);
        this.originalY = this.transform.position.y;
        this.originalX = this.transform.position.x;
    }

    void Update()
    {
        transform.position = new Vector3(originalX,
            originalY + ((float)Mathf.Sin(Time.time) * (floatStrength + floatStrangthAdjuestment)),
            transform.position.z);
    }
}
