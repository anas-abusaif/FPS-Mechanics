using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CanBePickedUp : MonoBehaviour
{
    public string PickUpMessege = "Pick Up";
    public string DropMessege = "Drop";
    private Rigidbody RB;
    public bool PickedUp = false;
    public Transform CarryPosition;
    public string ItemName;
    protected virtual void Start()
    {
        RB = GetComponent<Rigidbody>();
        ItemName = gameObject.name;
    }
    public virtual void PickUp()
    {
        PickedUp = true;
        RB.useGravity = false;
    }
    public virtual void Drop()
    {
        PickedUp = false;
        RB.useGravity = true;
    }
    protected virtual void Update()
    {
        if (PickedUp)
        {
            transform.position = CarryPosition.position;
            transform.rotation = CarryPosition.rotation;
        }
    }

}
