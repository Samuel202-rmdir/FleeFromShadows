
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    bool alive = true;
    public float speed;
    public float rate;
    public Rigidbody rb;
    public float originalHeight;
    //public Collider col;
    //public Transform target;


    public float cooldown;
    float cooldownTimestamp;

    float horizontalInput;
    public float horizontalMultiplier = 2;

    [SerializeField] float jumpForce;
    [SerializeField] LayerMask groundMask;

    private void FixedUpdate()
    {
        if (!alive) return;
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;

        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > cooldownTimestamp && speed < 25)
        {
           cooldownTimestamp = Time.time + cooldown;
            
            speed = speed + 1;
            jumpForce = jumpForce + 10f; 
            
        }
       
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
        if (transform.position.y < -5) {
            Die();
        }

        
    }

    public void Die(){
        alive = false;

        Invoke("Dead",2);
    }

    void Dead() {
        SceneManager.LoadScene("Dead");
    }

    void Jump() {

        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) * 0.1f);

        rb.AddForce(Vector3.up * jumpForce);
    }

}
