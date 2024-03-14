using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public GameObject lgt2;
    GameObject line2;
    public GameObject Line2;
    GameObject line;
    public float t;
    float t1 = 1f;
    float time;
    float time1 = 3f;
    public GameObject lgt;
    public GameObject enemy;
    bool doit = false;
    public GameObject Line;
    int r;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.GetComponent<Enemy>().HP == 1)
        {
            doit = true;
        }
        if(doit == true)
        {
            time += Time.deltaTime;
        }
        if(r == 1 || r == 2 || r == 3)
        {
            t += Time.deltaTime;
        }
        if (t >= t1)
        {
            
            if(r == 1)
            {
                GameObject light = Instantiate(lgt);
                light.transform.position = new Vector3(0, 0, 0);
                t = 0;
                
            }
            else if(r == 2)
            {
                for(int i = 0; i < 3; i++)
                {
                    GameObject light = Instantiate(lgt);
                    light.transform.position = new Vector3(-2 + 2 * i, 0, 0);
                }
                t = 0;
                
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    GameObject light = Instantiate(lgt);
                    light.transform.position = new Vector3(-2 + 2 * i, 0, 0);
                }
                for (int i = 0; i < 5; i++)
                {
                    GameObject light2 = Instantiate(lgt2);
                    light2.transform.position = new Vector3(0, 4 - 2 * i, 0);
                }
                t = 0;
                
            }
            r = 0;
        }
        if (time >= time1)
        {
            r = Random.Range(1, 4);
            if (r == 1 && doit == true)
            {
                line = Instantiate(Line);
                line.transform.position = new Vector3(0, 0, 0);
            }
            if(r == 2 && doit == true)
            {
                for(int i= 0; i < 3; i++)
                {
                    line = Instantiate(Line);
                    line.transform.position = new Vector3(-2 + 2 * i, 0, 0);
                }
            }
            if(r == 3 && doit == true)
            {
                for (int i = 0; i < 3; i++)
                {
                    line = Instantiate(Line);
                    line.transform.position = new Vector3(-2 + 2 * i, 0, 0);
                }
                for(int i = 0; i < 5; i++)
                {
                    line2 = Instantiate(Line2);
                    line2.transform.position = new Vector3(0, 4 - 2 * i, 0);
                }
            }
            time = 0;
        }
        
    }
}
