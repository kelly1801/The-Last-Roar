using System;
using UnityEngine;

public class Egg : MonoBehaviour
{
    private PlayerController player;
    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }
   
    private void OnTriggerEnter(Collider other)
{
        if (other.CompareTag("Player") && !player.HasEgg())
        {
            player.pickedEgg = this;
            SetEggParent(player);
    }
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


  
}

