using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    // Es literalmente una clase de tuberías. Yo habia sacado la instancia concreta correspondiente al par de tuberias de los GameObject porque la idea era que se generen, ya que voy a tener infinitas
    // Para ello, voy a tener este fabricador de pares de tuberías, donde cada un par de segundos voy a crear unas nuevas con diferentes características.
    // Como la idea es que las tuberías se muevan hacia la izquierda, el spawner lo ponemos a la derecha del mapa (en el layout)
    // Start is called before the first frame update

    public GameObject pipe; // en unity, le linkeo el "pipe" que habia sacado de la instancia concreta, llamado ahora "prefab"
    public float spawnPeriod = 2; // cantidad de segundos entre cada spawn
    private float timer = 0; // privado ya que no voy a modificarlo desde unity, es el contador interno para ver si ya puede instanciar otro pipe
    private float heightMap = 8; // altura  del mapa o camara
    private float gap = 4; // espacio entre las tuberias

    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > spawnPeriod)
        {
            //Instantiate(pipe); spawnea en la posición del spawner
            spawn();
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime; // delta time es como un infinitesimal de tiempo. Sumo pequeños delta hasta llegar a 2 seg y lo reseteo
        }
    }

    void spawn()
    {
        // hacerlas spawnear en alturas random, la altura debe ser siempre la misma pero diferente para cada par de tuberías
        // Calculo un random que representará el límite de la tubería superior
        //float maxHeight = GameObject.MainCamera
        float random = Random.Range(-heightMap + gap/2, heightMap - gap/2);

        // Generar un número entero aleatorio entre 0 (inclusive) y 100 (exclusivo)
        //int randomNumber = random.Next(0, 100);
        //int rnd = Random.Range(-this.maxHeight + gap, this.maxHeight);

        Instantiate(pipe, new Vector3(transform.position.x, random, 0), transform.rotation);
    }
}
