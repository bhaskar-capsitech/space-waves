//using UnityEngine;

//public class PlayerJump : MonoBehaviour
//{
//    private Rigidbody rb;
//    private bool isGrounded = true;
//    public bool gameOver = false;

//    public float jumpForce = 700f; 
//    public float gravityModifier = 2.25f;


//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        Physics.gravity = new Vector3(0, -9.81f * gravityModifier, 0);
//        ScoreManager.instance.ResetScore();

//    }

//    void Update()
//    {
//        // Check for spacebar on PC
//        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !gameOver)
//        {
//            Jump();
//        }

//        // Check for mobile touch input
//        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && isGrounded && !gameOver)
//        {
//            Jump();
//        }
//    }

//    void Jump()
//    {
//        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
//        isGrounded = false;
//    }

//    // Simple ground check using collision
//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.CompareTag("Platform"))
//        {
//            isGrounded = true;
//        }
//    }
//}





using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerJump : MonoBehaviour
{
    private Rigidbody rb;
    private bool isGrounded = true;
    public bool gameOver = false;

    public float jumpForce = 700f;
    public float gravityModifier = 2.25f;

    private bool restartScheduled = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -9.81f * gravityModifier, 0);
        ScoreManager.instance.ResetScore();
    }

    void Update()
    {
        if (!gameOver)
        {
            // Spacebar input
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
                Jump();

            // Mobile touch input
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && isGrounded)
                Jump();
        }
        else if (!restartScheduled)
        {
            restartScheduled = true;
            Invoke(nameof(RestartGame), 1.5f); 
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }

   
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
