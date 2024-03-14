using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    float time;
    float time1 = 1f;
    int hp;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(lazer());
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
    IEnumerator lazer()
    {
        while(true)
        {
            if (GetComponent<SpriteRenderer>().color == new Color(1,1,1,0))
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            }
            else
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
