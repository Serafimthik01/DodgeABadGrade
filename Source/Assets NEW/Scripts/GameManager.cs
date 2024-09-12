using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float gameSpeed;

    private float gameSpeedRegulator;
    private float speedRate = 0.5f;

    void Update()
    {
        gameSpeedRegulator += speedRate * Time.deltaTime;
        gameSpeed = gameSpeedRegulator;
    }
}
