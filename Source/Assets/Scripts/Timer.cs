using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static bool hasFinished = false;

    public float minutes;
    public float seconds;

    public float hgmin;
    public float hgsec;

    public TextMeshProUGUI textMeshProUGUI;

    public TextMeshProUGUI hGtextMeshProUGUI;

    private void Awake()
    {
        hgmin = PlayerPrefs.GetFloat("min", 0);
        hgsec = PlayerPrefs.GetFloat("sec", 0);
    }

    private void Start()
    {
        int hGm = Mathf.RoundToInt(hgmin);
        int hGs = Mathf.RoundToInt(hgsec);
        hGtextMeshProUGUI.text = $"{hGm:00}:{hGs:00}";
    }

    void Update()
    {
        if (!hasFinished)
        {
            seconds += Time.deltaTime;
        }
        if (seconds >= 60)
        {
            seconds = 0;
            minutes++;
        }
        int m = Mathf.RoundToInt(minutes);
        int s = Mathf.RoundToInt(seconds);

        textMeshProUGUI.text = $"{m:00}:{s:00}";
    }
}
