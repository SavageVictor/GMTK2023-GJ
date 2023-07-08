using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Metior_behaviour : MonoBehaviour
{
    private Move camObj;

    public int camDethBorder = 10;

    private Vector3 topRight;
    private Vector3 topLeft;
    private Vector3 bottomRight;
    private Vector3 bottomLeft;

    // Start is called before the first frame update
    void Start()
    {
        camObj = GetComponent<Move>();

    }

    // Update is called once per frame
    void Update()
    {

        topRight = camObj.cam.ScreenToWorldPoint(new Vector3(camObj.cam.pixelWidth, camObj.cam.pixelHeight, camObj.cam.nearClipPlane));
        bottomLeft = camObj.cam.ScreenToWorldPoint(new Vector3(0, 0, camObj.cam.nearClipPlane));
        amIDeth();
    }

    private void amIDeth()
    {
        if (transform.position.x > bottomLeft.x + camDethBorder ||
            transform.position.x < topRight.x - camDethBorder ||
            transform.position.y > topRight.y + camDethBorder ||
            transform.position.y < bottomLeft.y - camDethBorder
            )
        {
            Deth();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Deth")
        {
            Destroy(gameObject);
        }
    }

    public void Deth()
    {
        Destroy(gameObject);
    }

}
