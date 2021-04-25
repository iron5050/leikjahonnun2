using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;

    private Rigidbody2D _rigibody;



    private void Start()
    {
        _rigibody = GetComponent<Rigidbody2D>();
    }
    //kóði fyrir player movement 
    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        //lætur spilara snúast við til að vísa í þá átt sem hann fer
        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        //lætur spilarann hoppa ef space er ítt á
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigibody.velocity.y) < 0.001f)
        {
            _rigibody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }


    }
}
