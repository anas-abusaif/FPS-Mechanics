
using UnityEngine;

public class PlayerOnGroundController : Controller
{
    public float OnFootSpeed;
    public float JumpForce;
    public bool IsGrounded;
    public Rigidbody RB;
    public float playerHeight;
    public bool canSprint = true;
    public bool IsCrouched = false;
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        playerHeight = GetComponent<Renderer>().bounds.size.y;
    }
    private void Update()
    {
        IsGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.1f);
        if (!IsGrounded)
            RB.velocity += transform.up * -0.07f;


        if (Input.GetKeyDown(KeyCode.LeftShift) && canSprint)
            OnFootSpeed = 15;

        if (Input.GetKeyUp(KeyCode.LeftShift))
            OnFootSpeed = 7;

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (IsCrouched)
            {
                StandUp();
            }
            else
            {
                Crouch();
            }
        }

    }

    public override void ApplyMovement(Vector3 Direction)
    {

        RB.position += Direction * Time.deltaTime * OnFootSpeed;
    }

    public override void Jump()
    {
        if (IsGrounded)
            RB.AddForce(0, JumpForce, 0, ForceMode.Impulse);
        if (IsCrouched)
            StandUp();
    }

    public void Crouch()
    {
        OnFootSpeed = 3.5f;
        transform.localScale = new Vector3(1, 0.5f, 1);
        canSprint = false;
        IsCrouched = true;
    }

    public void StandUp()
    {
        OnFootSpeed = 7f;
        transform.localScale = Vector3.one;
        canSprint = true;
        IsCrouched = false;
    }

}
