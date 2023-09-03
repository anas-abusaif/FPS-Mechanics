using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Interactable
{
    //public static Vector3 onAngle = new Vector3(-30, 0, 0);
    //public static Vector3 offAngle = new Vector3(30f, 0, 0);
    public bool IsOn = false;
    //public Vector3 current = offAngle;
    void Awake()
    {

    }

    void Update()
    {
        GetComponent<Animator>().SetBool("IsOn", IsOn);

        if (IsOn)
            messege = "Switch Off";
        if (!IsOn)
            messege = "Switch On";


        //    if (current == offAngle && canRotate)
        //    {
        //        Quaternion targetRotation = Quaternion.Euler(onAngle);
        //        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 1f);

        //        if (transform.rotation == targetRotation)
        //        {
        //            canRotate = false;
        //            current = onAngle;
        //        }

        //    }

        //    if (current == onAngle && canRotate)
        //    {
        //        Quaternion targetRotation = Quaternion.Euler(offAngle);
        //        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 1f);

        //        if (transform.rotation == targetRotation)
        //        {
        //            canRotate = false;
        //            current = offAngle;
        //        }
        //    }

    }

    public override void Interact()
    {
        IsOn = !IsOn;
    }
}
