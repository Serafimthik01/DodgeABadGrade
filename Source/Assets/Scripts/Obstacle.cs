using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float speed = 2f;

    public RestartLevel restartLevel;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        transform.position = (Vector2)transform.position + Vector2.down * (speed + GameManager.gameSpeed) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Timer.hasFinished = true;
            Destroy(collider.gameObject);
        }
    }
}
