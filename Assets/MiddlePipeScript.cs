using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddlePipeScript : MonoBehaviour
{
    /// <summary>
    /// Para saber cu�nndo el pajaro atraviesa la secci�n del medio, creamos un objeto invisible, sin renderizar, entre las 2 tuber�as.
    /// Lo creamos con un box collision 2D, asi podemos hacer que colisione con otras cosas.
    /// Este objeto nos proporciona un m�todo que se ejecuta cuando ocurre una colisi�n. En este caso, eso solo va a ocurrir con el p�jaro.
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

    // OnTriggerEnter dispara el evento cuando occure una colisi�n entre este objeto que es invisible o abstracto y otra cosa
    // Cuando quiero detectar la colisi�n entre 2 objetos s�lidos, uso onColission2D
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
