
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    //TODO  need to siparate health logick and move

    //input obj
    public Rigidbody2D rb;
   // public CapsuleCollider2D col;

   private Stats _stats;
    //input var

    public float power = 10f;
    public Vector2 minPower;
    public Vector2 maxPower;


    TrajectoryLine tl;
    
    
    


    private Vector3 startPoint;
    private Vector3 endPoint;
    private Vector2 force;
    [SerializeField]
    public Camera cam;



    void Start()
    {
        _stats = new Stats();

        _stats = GetComponent<Stats>();

        transform.localScale += new Vector3(_stats._size, _stats._size, 0); 
        rb.mass = _stats._size;
        
        cam = Camera.main;
        tl = GetComponent<TrajectoryLine>();
    }

    void Update()
    {
            Movement();

        if  (_stats._isSelected)Charge();
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
                rb.AddForce(force * power * _stats._speed_mem  / _stats._size / 2, ForceMode2D.Impulse);
                tl.EndLine();
            _stats._isSelected = false;
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

                if (!_stats._WasSelected)
                {
                    _stats._isSelected = true;
                    _stats._WasSelected = true;
                }
                // Debug.Log("Uhu");
            }
        }

        transform.position += Vector3.left * (_stats._speed / 1000)/ _stats._size;
        transform.Rotate(0, 0, _stats._rot * Time.deltaTime); 
    }


    public Camera getCam()
    {
        return cam;
    }
}
