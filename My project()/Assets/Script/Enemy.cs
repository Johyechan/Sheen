using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameObject nextBullet;
    public float et;
    float et1 = 3f;
    GameObject Line;
    int r;
    GameObject circle;
    public bool hp = true;
    public int a = 0;
    public float tt = 0;
    float t2 = 0.5f;
    public float t = 0;
    float t1 = 1f;
    public GameObject Circle;
    public GameObject EPB;
    public Slider slider;
    public GameObject EB;
    float speed = 5f;
    public bool way = true;
    float time;
    float time1;
    bool OnOff = true;
    public int HP = 2;
    public TextMeshProUGUI X;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 3.9f, 0);
        X.text = "X " + HP;
        StartCoroutine(Fire());
        time = 0;
        time1 = Random.Range(0.5f, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value <= 0.5f && HP == 1)
        {
            et += Time.deltaTime;
        }
        if (et >= et1)
        {
            GameObject nb = Instantiate(nextBullet);
            nb.transform.position = transform.position;
            et = 0;
        }
        if(HP == 1)
        {
            hp = false;
        }
        if(HP <= 1)
        {
            t += Time.deltaTime;
        }
        if (a == 1)
        {
            tt += Time.deltaTime;
        }
        if (t >= t1)
        {
            if (a == 0)
            {
                a = 1;
                circle = Instantiate(Circle);
                circle.transform.position = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-2f, 4.5f), 0);
            }
            if (tt > t2)
            {
                transform.position = circle.transform.position;
                tt = 0;
                t = 0;
                a = 0;
            }
        }
        if (slider.value == 0 && HP > 0)
        {
            HP -= 1;
            X.text = "X " + HP;
            if(HP > 0)
            {
                slider.value = 1;
            }
        }
        if(slider.value == 0 && HP == 0)
        {
            SceneManager.LoadScene("Win");
        }
        if (slider.value <= 0.5f && HP == 2)
        {
            time += Time.deltaTime;
            if(time >= time1)
            {
                GameObject epb = Instantiate(EPB);
                epb.transform.position = transform.position;
                time = 0;
                time1 = Random.Range(0.5f, 2);
            }
        }
        if (way == false && hp == true)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            if (transform.position.x >= 2.6f)
            {
                way = true;
            }
        }
        if (way == true && hp == true)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            if (transform.position.x <= -2.6f)
            {
                way = false;
            }
        }
    }
    IEnumerator Fire()
    {
        while (OnOff)
        {
            GameObject eb = Instantiate(EB);
            eb.transform.position = transform.position;
            if(slider.value <= 0.5f && HP == 2)
            {
                OnOff = false;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            slider.value -= 0.01f;
        }
    }
}
