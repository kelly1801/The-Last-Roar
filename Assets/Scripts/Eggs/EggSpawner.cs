using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] Egg[] eggs;
    void Start()
    {
        AssignEggsPositions();
    }

    private void AssignEggsPositions()
    {
        List<Transform> availableSpawnPoints = new List<Transform>(spawnPoints);

        foreach (var egg in eggs)
        {
            if (availableSpawnPoints.Count > 0)
            {
                // Randomly select a spawn point from the available ones
                int randIndex = Random.Range(0, availableSpawnPoints.Count);
                Transform chosenSpawnPoint = availableSpawnPoints[randIndex];

                // Assign the chosen spawn point to the egg
                egg.transform.position = chosenSpawnPoint.position;

                // Remove the chosen spawn point from the available list to prevent reuse
                availableSpawnPoints.RemoveAt(randIndex);
            }
        }
    }
}
