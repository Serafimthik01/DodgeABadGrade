using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float speed = 2f;

    [SerializeField] private RestartLevel restartLevel;

    private void Start() => Destroy(gameObject, 5f);

    private void Update() => transform.position = (Vector2)transform.position + (speed + GameManager.gameSpeed) * Time.deltaTime * Vector2.down;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Timer.hasFinished = true;
            Destroy(collider.gameObject);
        }
    }
}
