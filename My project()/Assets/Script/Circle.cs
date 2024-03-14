using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    float time;
    float time1 = 0.5f;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(boom());
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= time1)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator boom()
    {
        while(true)
        {
            if(spriteRenderer.color == Color.white)
            {
                spriteRenderer.color = Color.red;
            }
            else
            {
                spriteRenderer.color = Color.white;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
