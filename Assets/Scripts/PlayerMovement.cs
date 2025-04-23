using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5;

    public Rigidbody rb;

    float horizontalInput;

    public float horizontalMultiplier = 2;

    private void FixedUpdate()
    {
        Vector3 fowardMove = transform.forward * speed * Time.deltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position +  fowardMove + horizontalMove);
    }



    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"); 
    }
}
