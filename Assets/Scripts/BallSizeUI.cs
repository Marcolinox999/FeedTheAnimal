using TMPro;
using UnityEngine;

public class BallSizeUI : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUIScore;

    
    [SerializeField] Ball ball;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textMeshProUGUIScore = GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        textMeshProUGUIScore.text = "Ball Size: " + ball.ballSize;
    }
}
