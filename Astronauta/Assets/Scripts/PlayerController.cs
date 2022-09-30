using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D body;

    Vector2 direccion;

    [SerializeField]

    float impulse = 10f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        //body.AddForce(transform.right, ForceMode2D.Impulse);
    }


    // Update is called once per frame
    void Update()
    {
        direccion.x = Input.GetAxis("Horizontal") * Time.deltaTime * impulse;

        direccion.y = Input.GetAxis("Vertical") * Time.deltaTime * impulse;
    }

    private void FixedUpdate()
    {
        body.AddForce(direccion, ForceMode2D.Impulse);

    }
}
