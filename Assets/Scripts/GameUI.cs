using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] TMP_Text _scoreText;
    int _score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetScore()
    {
        _score = 0;
        _scoreText.text = "Score: " + _score.ToString();
    }

    public void AddScore()
    {
        _score++;
        _scoreText.text = "Score: " + _score.ToString();
    }
}
