using UnityEngine;

public class Player : MonoBehaviour
{
    //Rigidbody
    private Rigidbody _rb;
    
    //Movement forces
    [SerializeField] private float _moveSpeed = 0f;
    [SerializeField] private float _jumpForce = 0f;

    //UI Elements
    public GameObject levelCompleteUI;
    public GameObject gameOverUI;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Movement()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Time.deltaTime * _moveSpeed * Vector3.forward;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Time.deltaTime * _moveSpeed * Vector3.back;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Time.deltaTime * _moveSpeed * Vector3.left;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Time.deltaTime * _moveSpeed * Vector3.right;
        }

    }
    private void Jump()
    {
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.5f);

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
               _rb.velocity = new Vector3(_rb.velocity.x, _jumpForce * Time.deltaTime, _rb.velocity.z);
            }
        }
    }
    private void Update()
    {
        Movement();
        Jump();
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Ground")
        {
            Time.timeScale = 0f;
            gameOverUI.SetActive(true);
        }

        if (collisionInfo.collider.tag == "EndLine")
        {
            Time.timeScale = 0f;
            levelCompleteUI.SetActive(true);
        }
    }
}
