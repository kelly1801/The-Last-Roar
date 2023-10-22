using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteBehavior : MonoBehaviour
{
    public float velocidadInicial = 10f; // Velocidad inicial de ca�da
    public float rotacionMaxima = 20f; // M�xima velocidad de rotaci�n

    private Rigidbody rb;
    public MeteoriteSpawnManager controlSpawn;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.down * velocidadInicial; // Iniciar la ca�da hacia abajo
        rb.angularVelocity = Random.insideUnitSphere * rotacionMaxima; // Asignar rotaci�n aleatoria
    }


    void OnCollisionEnter(Collision collision)
    {
        // Llama al m�todo de reciclaje del MeteoriteSpawnManager para reciclar este meteorito
        controlSpawn.RecycleMeteor(gameObject);
    }
}
