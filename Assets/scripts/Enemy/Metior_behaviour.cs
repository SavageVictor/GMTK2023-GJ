using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class Metior_behaviour : MonoBehaviour
{/*
    public Slider _slider;
    public GameObject _sliderObj;
*/
    private Move camObj;
    private Stats _stats;

    public int camDethBorder = 10;

    private Vector3 topRight;
    private Vector3 topLeft;
    private Vector3 bottomRight;
    private Vector3 bottomLeft;
    // Start is called before the first frame update
    void Start()
    {
        camObj = GetComponent<Move>();
        _stats  = GetComponent<Stats>();

     /*   _slider.value = _stats.maxHealth;
        _sliderObj.active = false;*/

    }

    // Update is called once per frame
    void Update()
    {
      /*  if (_stats._isSelected)
        {
            _sliderObj.active = true;
        }
        else
        {
            _sliderObj.active = false;
        }*/

        topRight = camObj.cam.ScreenToWorldPoint(new Vector3(camObj.cam.pixelWidth, camObj.cam.pixelHeight,
            camObj.cam.nearClipPlane));
        bottomLeft = camObj.cam.ScreenToWorldPoint(new Vector3(0, 0, camObj.cam.nearClipPlane));
        amIDead();
    }

    private void amIDead()
    {
        if (transform.position.x > bottomLeft.x + camDethBorder ||
            transform.position.x < topRight.x - camDethBorder / 2 ||
            transform.position.y > topRight.y + (camDethBorder / 2) ||
            transform.position.y < bottomLeft.y - (camDethBorder / 2)
            )
        {
            Deth();
        }

        if (_stats.health <= 0)
        {
            Deth();
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        
        if (coll.collider.tag == "asteroid")
        {
            _stats.health -= 10;
        }

      //  _slider.value = _stats.health;
    }

    public void Deth()
    {
        Destroy(gameObject);
    }

}
