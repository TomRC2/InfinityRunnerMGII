using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float elapsedTime;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        timerText.text = elapsedTime.ToString("F3") + " s";
    }
}