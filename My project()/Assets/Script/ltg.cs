using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ltg : MonoBehaviour
{
    float time;
    float time1 = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= time1)
        {
            Destroy(gameObject);
        }
    }
}
