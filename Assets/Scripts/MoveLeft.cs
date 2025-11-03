using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
  

    public float speed = 35.0f;

    void Update()
    {
        // Move the obstacle left every frame
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }


}
