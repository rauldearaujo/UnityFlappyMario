using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perigo : MonoBehaviour
{
    public virtual void WhenCollisionEnter(Collision2D coll) 
    {
        if (coll.gameObject.tag == Tags.PERIGO)
        {
            Physics2D.IgnoreCollision(coll.collider, GetComponent<Collider2D>());
        }
    }

}
