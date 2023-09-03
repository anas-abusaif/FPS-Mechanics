using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractor : MonoBehaviour
{
    public float interactDistance = 5f;
    public LayerMask Layer;
    // Start is called before the first frame update
    Transform Cam;
    public Text prompt;
    public Image E;
    void Start()
    {
        Cam = GetComponent<FPLook>().Cam;
    }

    // Update is called once per frame
    void Update()
    {
        prompt.text = "";
        E.enabled = false;
        Debug.DrawRay(Cam.position, Cam.forward * interactDistance, Color.red);
        if (Physics.SphereCast(Cam.position, 0.2f, Cam.forward, out RaycastHit hitInfo, interactDistance, Layer))
        {
            prompt.text = hitInfo.collider.GetComponent<Interactable>().messege;
            E.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
                hitInfo.collider.gameObject.GetComponent<Interactable>().Interact();
        }

    }
}
