using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddlePipeScript : MonoBehaviour
{
    /// <summary>
    /// Para saber cuánndo el pajaro atraviesa la sección del medio, creamos un objeto invisible, sin renderizar, entre las 2 tuberías.
    /// Lo creamos con un box collision 2D, asi podemos hacer que colisione con otras cosas.
    /// Este objeto nos proporciona un método que se ejecuta cuando ocurre una colisión. En este caso, eso solo va a ocurrir con el pájaro.
    /// </summary>
    /// 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // OnTriggerEnter dispara el evento cuando occure una colisión entre este objeto que es invisible o abstracto y otra cosa
    // Cuando quiero detectar la colisión entre 2 objetos sólidos, uso onColission2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision)
        {
            GameManagerScript gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
            gameManager.addScore();
            BirdScript bird = GameObject.Find("Bird").GetComponent<BirdScript>();
            bird.yay();
        }
    }
}
