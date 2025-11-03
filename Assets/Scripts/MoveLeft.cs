using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    private float leftBound = -35;
    private PlayerJump playerJumpScript;
    private bool hasScored = false;


    public float speed = 35f;

    
    void Start()
    {
        playerJumpScript = GameObject.Find("Player").GetComponent<PlayerJump>();
    }

    void Update()
    {


        if (!playerJumpScript.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        if (!hasScored && transform.position.x < playerJumpScript.transform.position.x && gameObject.CompareTag("Obstacle"))
        {
            hasScored = true;
            ScoreManager.instance.IncreaseScore(1);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerJumpScript.gameOver = true;
        }
    }
}
