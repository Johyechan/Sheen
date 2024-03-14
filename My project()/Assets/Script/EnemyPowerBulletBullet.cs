using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPowerBulletBullet : MonoBehaviour
{
    Vector3 dir;
    int a;
    float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        a = Random.Range(1, 4);
        if(a < 3)
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
        if(transform.position.y <= -5.5f || transform.position.y >= 5.5f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
