using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    public GameObject panelGameOver;
    public GameObject musicGame;
    public Timer timer;

    [SerializeField] private TextMeshProUGUI gameOvertextMeshProUGUI;

    private void Update()
    {
        if (Timer.hasFinished == true)
        {
            Time.timeScale = 0f;
            panelGameOver.SetActive(true);
            musicGame.SetActive(false);
            gameOvertextMeshProUGUI.text = $"{timer.minutes:00}:{timer.seconds:00}";

            if (timer.minutes > timer.hgmin || (timer.minutes == timer.hgmin && timer.seconds > timer.hgsec))
            {
                PlayerPrefs.SetFloat("min", timer.minutes);
                PlayerPrefs.SetFloat("sec", timer.seconds);
                PlayerPrefs.Save();
            }
        }
    }

    public void OnClickRestart()
    {
        Timer.hasFinished = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickMainMenu()
    {
        Timer.hasFinished = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
