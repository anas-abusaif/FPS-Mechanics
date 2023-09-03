using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLadderController : Controller
{
    Rigidbody RB;
    public float JumpForce;
    public float LadderSpeed = 1;
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    public override void ApplyMovement(Vector3 Direction)
    {
        RB.position += Vector3.up * Direction.x * Time.deltaTime * LadderSpeed;
        RB.velocity = Vector3.zero;

    }
    public override void Jump()
    {
        RB.AddForce(transform.forward * -JumpForce, ForceMode.Impulse);
    }
}
