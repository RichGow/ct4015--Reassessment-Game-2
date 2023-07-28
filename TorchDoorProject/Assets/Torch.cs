using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Torch : MonoBehaviour
{
    [SerializeField]
    private GameObject torchTip;
    private Vector2 mousePosition;
    private float deltaX, deltaY;

    public static event Action SetDoorOnFire = delegate { };

    // Start is called before the first frame update
    void Start()
    {
        torchTip.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "BonFire")
        {
            torchTip.SetActive(true);
        }

        if (torchTip.activeSelf && collision.gameObject.name == "Door")
        {
            SetDoorOnFire();
        }
    }

    private void OnMouseDown()
    {
        deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
    }
}
