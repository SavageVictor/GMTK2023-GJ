using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    //TODO  need to siparate helth logick and move

    //input obj
    public Rigidbody2D rb;

    public Stats _stats;
    //input var

    public float power = 10f;
    public Vector2 minPower;
    public Vector2 maxPower;

    private bool _isSelected = false;

    TrajectoryLine tl;
    
    
    


    private Vector3 startPoint;
    private Vector3 endPoint;
    private Vector2 force;
    private Camera cam;



    void Start()
    {
        _stats = new Stats();


        transform.localScale += new Vector3(_stats._size, _stats._size, 0); ;
        
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

        _stats._speed = 0;
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
                    Math.Clamp(startPoint.y - endPoint.y,minPower.y, maxPower.y));
                rb.AddForce(force * power * _stats._speed_mem  / _stats._size / 5, ForceMode2D.Impulse);
                tl.EndLine();
                _isSelected = false;
            }
        
    }

    void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (transform.position.x + _stats._size / 2 > cam.ScreenToWorldPoint(Input.mousePosition).x &&
                transform.position.x - _stats._size / 2 < cam.ScreenToWorldPoint(Input.mousePosition).x &&
                transform.position.y + _stats._size / 2 > cam.ScreenToWorldPoint(Input.mousePosition).y &&
                transform.position.y - _stats._size / 2 < cam.ScreenToWorldPoint(Input.mousePosition).y)
            {

                _isSelected = true;
               // Debug.Log("Uhu");
            }
        }

        transform.position += Vector3.left * (_stats._speed / 1000)/ _stats._size;
        transform.Rotate(0, 0, _stats._rot * Time.deltaTime); 
    }

    //Check if Grounded
    void OnCollisionEnter2D()
    {
       // _isGrounded = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Deth")
        {
            Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
    }
   /* private void OnMouseOver()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        _isSelected = true;
        Debug.Log("Uhu");
        // Your logic here.
    }*/

}
