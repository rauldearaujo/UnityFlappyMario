using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float speed = 9f;
    public Vector2 direction = Vector2.right;

    void Start() 
    {
        if(direction == Vector2.left)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);        
    }
}
