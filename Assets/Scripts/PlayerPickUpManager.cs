using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPickUpManager : MonoBehaviour
{
    private Transform Cam;
    public Image Q;
    public Text Midddle;
    public Text BottomRight;
    public Image E;
    private float PickUpDistance = 5f;
    public LayerMask Layer;
    private CanBePickedUp Item;
    private bool Occupied = false;
    void Start()
    {
        Cam = GetComponent<FPLook>().Cam;

    }
    void Update()
    {
        Midddle.text = "";
        E.enabled = false;
        BottomRight.text = "";
        Q.enabled = false;

        if (Physics.SphereCast(Cam.position, 0.2f, Cam.forward, out RaycastHit hitInfo, PickUpDistance, Layer) && Occupied == false)
        {
            Item = hitInfo.collider.gameObject.GetComponent<CanBePickedUp>();
            Midddle.text = Item.PickUpMessege + " " + Item.ItemName;
            E.enabled = true;
            Debug.Log("hit");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Occupied = true;
                Item.PickUp();
            }
        }
        if (Occupied == true)
        {
            BottomRight.text = Item.DropMessege;
            Q.enabled = true;
        }


        if (Input.GetKeyDown(KeyCode.Q) && Occupied == true)
        {
            BottomRight.text = "";
            Q.enabled = false;
            Item.Drop();
            Occupied = false;
        }

    }
}

