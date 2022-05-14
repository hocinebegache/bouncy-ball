using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float bulletSpeed = 5.0f;
    private Rigidbody enemyRigidbody;
    private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        enemy = GameObject.Find("Enemy(clone)");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 bulletDirection = ((enemy.transform.position - transform.position) * bulletSpeed).normalized;
        enemyRigidbody.AddForce(bulletDirection);
    }
}
