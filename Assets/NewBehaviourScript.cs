using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class PlayerMovementRB : MonoBehaviour
{


public float speed = 5f;
public float jumpForce = 5f;
 private Rigibody rb;   
private bool isGrounded;


    void Start()
    {
        rb= GetComponent<Rigibody>()
        rb.freezeRotation = true;
        
    }
}
