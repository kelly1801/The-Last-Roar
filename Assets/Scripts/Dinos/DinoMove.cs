using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoMove : MonoBehaviour
{
    private Animator animatorWalk;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        animatorWalk = GetComponent<Animator>();
        animatorWalk.SetBool("isWalking", true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
