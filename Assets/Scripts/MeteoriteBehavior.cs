using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteBehavior : MonoBehaviour
{
    public float velocidadInicial = 10f; // Velocidad inicial de caída
    public float rotacionMaxima = 20f; // Máxima velocidad de rotación

    private Rigidbody rb;
    public MeteoriteSpawnManager controlSpawn;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.down * velocidadInicial; // Iniciar la caída hacia abajo
        rb.angularVelocity = Random.insideUnitSphere * rotacionMaxima; // Asignar rotación aleatoria
    }


    void OnCollisionEnter(Collision collision)
    {
        // Llama al método de reciclaje del MeteoriteSpawnManager para reciclar este meteorito
        controlSpawn.RecycleMeteor(gameObject);
    }
}
