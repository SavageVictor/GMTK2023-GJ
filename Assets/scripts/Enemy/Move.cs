using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

using Random = System.Random;
public class Move : MonoBehaviour
{
    //input obj
    public Rigidbody2D rb;

    //input var
    public float power = 10f;
    public Vector2 minPower;
    public Vector2 maxPower;

    public int max_speed = 10;
    public int min_speed = 1;
    public int max_rot = 10;
    public int min_rot = 1;
    public int max_size = 3;
    public int min_size = 1;

    public float _speed;
    public float _rot;
    public float _size;

    private bool _isSelected = false;

    TrajectoryLine tl;

    float _moveVelocity;



    bool _isGrounded = true;
    


    private Vector3 startPoint;
    private Vector3 endPoint;
    private Vector2 force;
    private Camera cam;


    Random r = new Random();

    void Start()
    {

        _size = r.Next(min_size, max_size);
        _speed = r.Next(min_speed, max_speed);
        _rot = r.Next(min_rot, max_rot);

        transform.localScale += new Vector3(_size, _size, 0); ;
        
        cam = Camera.main;
        tl = GetComponent<TrajectoryLine>();
    }

    void Update()
    {
            Movement();
  
           if(_isSelected)Charge();
    }


    
    void Charge()
    {
        if (_isGrounded)
        {
            _speed = 0;
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
                _isGrounded = false;
                _isSelected = false;
            }
        }
    }

    void Movement()
    {
        transform.position += Vector3.left * _speed / 1000;
        transform.Rotate(0, 0, _rot * Time.deltaTime); 
    }

    //Check if Grounded
    void OnCollisionEnter2D()
    {
        _isGrounded = true;
    }

    void OnMouseDown()
    {
        _isSelected = true;
    }
    
}
