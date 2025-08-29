using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementRB : MonoBehaviour
{
public float speed = 5f;
public float jumpForce = 5f;
private Rigidbody rb;
private bool isGrounded;
void Start()
{
rb = GetComponent<Rigidbody>();
rb.freezeRotation = true; // evita que el jugador se voltee al chocar
}
void Update()
{
// --- Movimiento con física ---
float x = Input.GetAxis("Horizontal");
float z = Input.GetAxis("Vertical");
Vector3 move = new Vector3(x, 0, z) * speed;
Vector3 newVelocity = new Vector3(move.x, rb.velocity.y, move.z);
rb.velocity = newVelocity;
// --- Saltar ---
if (isGrounded && Input.GetKeyDown(KeyCode.Space))
{
rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
}
}
// Detección básica de suelo
private void OnCollisionEnter(Collision collision)
{
if (collision.contacts[0].normal.y > 0.5f) // superficie plana
{
isGrounded = true;
}
}
private void OnCollisionExit(Collision collision)
{
isGrounded = false;
}
}