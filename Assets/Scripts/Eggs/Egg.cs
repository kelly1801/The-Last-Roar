using System;
using UnityEngine;

public class Egg : MonoBehaviour
{
    private PlayerController player;
    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }
    private void Start()
    {
        GameManager.Instance.EggPicked += OnEggPicked;

    }
    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player") && !player.HasEgg())
    {
        GameManager.Instance.OnEggPicked();
    }
}

    private void OnEggPicked(object sender, EventArgs e)
    {
        GameManager.Instance.eggsPicked++;
        SetEggParent(player);

    }

    public void SetEggParent(PlayerController player)
    {
        transform.parent = player.GetEggNewTransform();
        transform.localPosition = Vector3.zero;
    }
    public void RemoveEggParent()
     {
    transform.parent = null;
    }

    private void OnDestroy()
    {
        GameManager.Instance.EggPicked -= OnEggPicked;
    }
    
  
}

