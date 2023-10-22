using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawnManager : MonoBehaviour
{
    public GameObject meteoritoPrefab;
    public int initialAmount = 20;
    public GameObject spawnReference; // Objeto de referencia para el rango de spawn
    public float spawnInterval = 3.0f; // Intervalo de generación de meteoritos
    public bool spawnEnabled = true; // Habilitar o deshabilitar la generación de meteoritos
    public List<GameObject> activeMeteors = new List<GameObject>();
    public Vector3 spawnRange = new Vector3(10, 2, 10);

    void Start()
    {
        for (int i = 0; i < initialAmount; i++)
        {
            GameObject newMeteor = Instantiate(meteoritoPrefab);
            newMeteor.SetActive(false);
            activeMeteors.Add(newMeteor);
        }

        // Iniciar el proceso de spawn en un intervalo
        StartCoroutine(SpawnMeteorInterval());
    }

    IEnumerator SpawnMeteorInterval()
    {
        while (true)
        {
            if (spawnEnabled)
            {
                SpawnRandomMeteor();
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void SpawnRandomMeteor()
    {
        if (activeMeteors.Count > 0)
        {
            int randomIndex = Random.Range(0, activeMeteors.Count);
            GameObject meteor = activeMeteors[randomIndex];
            activeMeteors.RemoveAt(randomIndex);

            Vector3 spawnPosition = spawnReference.transform.position + new Vector3(
                Random.Range(-spawnRange.x, spawnRange.x),
                Random.Range(-spawnRange.y, spawnRange.y),
                Random.Range(-spawnRange.z, spawnRange.z)
            );

            meteor.transform.position = spawnPosition;
            meteor.SetActive(true);
        }
    }

    public void RecycleMeteor(GameObject meteorToRecycle)
    {
        meteorToRecycle.SetActive(false);
        activeMeteors.Add(meteorToRecycle);
    }


}
