using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timer = 180;
    public int prettyTimer;
    private TextMeshProUGUI textMeshProUGUITimer;
    private TextMeshProUGUI textMeshProUGUIScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textMeshProUGUITimer = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (prettyTimer > 0)
        {
            timer -= Time.deltaTime;
            prettyTimer = Mathf.RoundToInt(timer);
            textMeshProUGUITimer.text = "Time left:" + prettyTimer;
        }
    }
}
