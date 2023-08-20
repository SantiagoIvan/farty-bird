using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PipeMovementScript : MonoBehaviour
{
    //Lo que se va a mover en el sentido de las "x" son las tuberías. Se mueven juntas y siempre van a estar de a 2 asi que el comportamiento lo va a tener el padre
    public float ms = 4;
    private int deadZone = -18;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * ms * Time.deltaTime;
        // si esta fuera del mapa, borro el objeto asi libero memoria
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
            Debug.Log("Pipe deleted");
        }
    }
}
