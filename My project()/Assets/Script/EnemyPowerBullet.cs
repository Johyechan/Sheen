using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPowerBullet : MonoBehaviour
{
    SpriteRenderer Sprite;
    public GameObject Bullet;
    float speed = 3f;
    int hp = 3;
    float time = 0;
    float time1 = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fire());
        Sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Sprite.color == Color.red)
        {
            time += Time.deltaTime;
        }
        if(time >= time1)
        {
            Sprite.color = Color.white;
        }
        Vector3 dir = Vector3.down;
        transform.position += dir * speed * Time.deltaTime;
        if(transform.position.y <= -5.5f)
        {
            Destroy(gameObject);
        }
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Fire()
    {
        while(true)
        {
            GameObject bullet = Instantiate(Bullet);
            bullet.transform.position = transform.position;
            yield return new WaitForSeconds(2f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Sprite.color = Color.red;
            hp -= 1;
        }
        if(collision.gameObject.CompareTag("Player"))
        {
            hp -= 1;
        }
    }
}
