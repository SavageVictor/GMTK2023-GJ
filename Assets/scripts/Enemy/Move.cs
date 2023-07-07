using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    //input obj
    public Rigidbody2D rb;

    //input var
    public float power = 10f;
    public float _speed;
    public float _jump;
    public Vector2 minPower;
    public Vector2 maxPower;
    

     TrajectoryLine tl;

    float _moveVelocity;



    bool _isGrounded = true;
    private bool _isCharge = false;


    private Vector3 startPoint;
    private Vector3 endPoint;
    private Vector2 force;
    private Camera cam;


    
    void Start()
    {

        cam = Camera.main;
        tl = GetComponent<TrajectoryLine>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _isCharge = !_isCharge;
          
        }

        if (!_isCharge)
        {
            Movement();
        }
        else
        {
            Charge();
        }

    }

    void Charge()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 curentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            curentPoint.z = 15;
            tl.RenderLine(startPoint, curentPoint);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15;
            force = new Vector2(Math.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x),
                Math.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            rb.AddForce(force * power, ForceMode2D.Impulse);
            tl.EndLine();

        }


    }

    void Movement()
    {

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W))
        {
            if (_isGrounded)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, _jump);
                _isGrounded = false;
            }
        }

        _moveVelocity = 0;

        //Left Right Movement
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            _moveVelocity = -_speed;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            _moveVelocity = _speed;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(_moveVelocity, GetComponent<Rigidbody2D>().velocity.y);


    }

    //Check if Grounded
    void OnCollisionEnter2D()
    {
        _isGrounded = true;
        _isCharge = false;
    }
    
}
