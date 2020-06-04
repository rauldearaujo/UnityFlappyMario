using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : Perigo
{
    public float speed = 7f;
    public GameObject jogador;
    public GameObject explosao;
    public AudioClip audioEfeitoDisparo;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        // toca o som de disparo quando a bala fica próxima ao jogador
        if(transform.position.x < jogador.transform.position.x + 30)
        {
            AudioSource.PlayClipAtPoint(audioEfeitoDisparo, transform.position);
        }

        // destroi o gameObject da bala depois que ela sai da câmera
        if(transform.position.x < jogador.transform.position.x - 20)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D coll) 
    {
        WhenCollisionEnter(coll);
    }

    public override void WhenCollisionEnter(Collision2D coll) 
    {
        base.WhenCollisionEnter(coll);

        if (coll.gameObject.tag == Tags.JOGADOR)
        {
            Destroy(gameObject);
            Vector2 hitPoint = coll.contacts[0].point;
            GameObject explosaoInsnciada =  Instantiate(explosao, hitPoint, Quaternion.identity);
        }

    }
}
