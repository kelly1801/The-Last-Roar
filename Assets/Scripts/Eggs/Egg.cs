using System;
using UnityEngine;

public class Egg : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.EggPicked += OnEggPicked;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.OnEggPicked();
        }
    }

    private void OnEggPicked(object sender, EventArgs e)
    {
        Debug.Log("Pickeeeeeeeeeeeeeeeeeeeeeed");
        GameManager.Instance.eggsPicked++;

    }

    private void OnDestroy()
    {
        GameManager.Instance.EggPicked -= OnEggPicked;
    }
}

