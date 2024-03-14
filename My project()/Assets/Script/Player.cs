using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float time;
    public float time1 = 25f;
    public Slider slider;
    public GameObject Bullet;
    float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -4.5f, 0);
        StartCoroutine(Fire());
        time = 25f;
    }

    // Update is called once per frame
    void Update()
    {
        if(time < time1)
        {
            time += Time.deltaTime;
        }
        if(slider.value <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        if (Input.GetKeyDown(KeyCode.X) && time >= time1)
        {
            slider.value += 0.3f;
            time = 0;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0.08f)
        {
            pos.x = 0.08f;
        }
        if (pos.x > 0.92f)
        {
            pos.x = 0.92f;
        }
        if (pos.y < 0.05f)
        {
            pos.y = 0.05f;
        }
        if (pos.y > 0.95f)
        {
            pos.y = 0.95f;
        }
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
    IEnumerator Fire()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                GameObject bullet = Instantiate(Bullet);
                bullet.transform.position = transform.position;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("Enemy"))
        {
            slider.value -= 0.1f;
        }
        if(collision.gameObject.CompareTag("Lightning"))
        {
            slider.value -= 0.2f;
        }
    }
}
