using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float speed;
    public string gameOverSceneName;
    public Pontuacao pontuacao;
    public GameObject mainCamera;
    public AudioClip audioMorte;
    public GameObject fire;
    
    private Animator animator;
    private Rigidbody2D playerRigidBody;
    private int rotation = 1;
    public int Rotation 
    {
        get => rotation;
    }
    private bool estaMorto = false;
    private bool superPoder = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody2D>();
        pontuacao = new Pontuacao();
        pontuacao.AddCoins(10);
    }

    // Update is called once per frame
    void Update()
    {
        if(!estaMorto) 
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                playerRigidBody.AddForce(transform.up + new Vector3(0, 700, 0));
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                rotation = 1;
                playerRigidBody.gameObject.transform.eulerAngles = new Vector2 (0, 0);
            }
            else if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                rotation = -1;
                playerRigidBody.gameObject.transform.eulerAngles = new Vector2 (0, 180);
            }
            else if (Input.GetKeyDown(KeyCode.Space))// && superPoder)
            {
                Vector3 fireOffset;
                Vector2 fireDirection;
                if(rotation == 1) 
                {
                    fireOffset = new Vector3(1f, 0f, 0f);
                    fireDirection = Vector2.right;
                }
                else 
                {
                    fireOffset = new Vector3(-1f, 0f, 0f);
                    fireDirection = Vector2.right;
                }
                GameObject fireInstance = Instantiate(fire, transform.position + fireOffset, Quaternion.identity) as GameObject;
                fireInstance.GetComponent<Fire>().direction = fireDirection;
            }
        }

    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == Tags.PERIGO)
        {
            playerRigidBody.AddForce(transform.up + new Vector3(0, 700, 0));
            if(superPoder) 
            {
                superPoder = false;
            }
            else
            {
                pontuacao.RemoveCoins(10);
                if(pontuacao.GetCoins() <= 0) {
                    Morrer();
                    mainCamera.GetComponent<AudioSource>().Stop();
                    AudioSource.PlayClipAtPoint(audioMorte, transform.position);
                    StartCoroutine(LoadGameOverScene());
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D coll) 
    {
        if (coll.gameObject.tag == Tags.MOEDA) 
        {
            coll.GetComponent<Moeda>().PlayCollectedSound();
            Destroy(coll.gameObject);
            pontuacao.AddCoins(10);
        }

        else if (coll.gameObject.tag == Tags.FLOR)
        {
            coll.GetComponent<Flor>().PlayCollectedSound();
            Destroy(coll.gameObject);
            superPoder = true;
        }

    }

    private IEnumerator LoadGameOverScene() 
    {
        yield return new WaitForSecondsRealtime(3.344f);
        SceneManager.LoadScene(gameOverSceneName);
    }

    public void Morrer() 
    {
        estaMorto = true;
        animator.SetTrigger("jogador_morrendo");
        playerRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

}
