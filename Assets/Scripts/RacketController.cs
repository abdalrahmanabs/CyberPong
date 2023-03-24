using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] KeyCode up, down;
    bool isPlayer=true;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
            if(isPlayer)
                MoveByPlayer();
    }

    private void MoveByPlayer()
    {
        if (Input.GetKey(KeyCode.None)) return;

        if (Input.GetKey(up))
            rb.velocity = Vector3.forward * _moveSpeed * Time.deltaTime;

        if (Input.GetKey(down))
            rb.velocity = Vector3.back * _moveSpeed * Time.deltaTime;


    }
}
