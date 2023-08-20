using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // se lo pongo como public asi puedo acceder a esta propiedad desde Unity.
    public Rigidbody2D birdBody;
    public GameManagerScript gameManager;
    public AudioSource jumpAudio;
    public AudioSource yayAudio;

    public float velocityRatio;
    private int deadZonex = -18;
    private int deadZoney = -18;
    public bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isAlive){
            birdBody.velocity += Vector2.up * velocityRatio;
            jumpAudio.Play();
        }
        if(transform.position.y < deadZoney || transform.position.x < deadZonex || transform.position.y > (-deadZoney))
        {
            Destroy(gameObject);
            gameManager.gameOver();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            isAlive = false;
            GameObject.Find("GameManager").GetComponent<GameManagerScript>().gameOver();
        }
    }

    public void yay()
    {
        if (isAlive)
        {
            yayAudio.Play();
        }
    }
}
