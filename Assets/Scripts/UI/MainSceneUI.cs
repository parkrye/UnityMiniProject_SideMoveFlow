using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class MainSceneUI : MonoBehaviour
{
    [SerializeField] TMP_Text speedText, enemyText;
    public UnityEvent<float> SpeedButtonEvent;
    float time;
    string[] speedTextContent;

    void Awake()
    {
        SpeedButtonEvent = new UnityEvent<float>();
        time = 1f;
        speedTextContent = new string[] { ">", ">>", ">>>" };
    }

    public void OnSpeedButtonClicked()
    {
        if (time < 1.5f)
        {
            speedText.text = speedTextContent[1];
            time = 2f;
        }
        else if (time < 2.5f)
        {
            speedText.text = speedTextContent[2];
            time = 3f;
        }
        else
        {
            speedText.text = speedTextContent[0];
            time = 1f;
        }

        SpeedButtonEvent?.Invoke(time);
    }
}
