using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ceu : MonoBehaviour
{
    public float speed;
    public GameObject mainCamera;
    private float startPos, length;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = mainCamera.transform.position.x * (1 - speed);
        float dist = mainCamera.transform.position.x * speed;
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if (temp > startPos + length) startPos += length;
        else if(temp < startPos - length) startPos -= length;

    }
}
