using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGameManager : MonoBehaviour
{
    [SerializeField] GameObject _apple;
    [SerializeField] SnakeHead _snake;

    [SerializeField] float _appleShowTime = 1.0f;

    float _duration = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _apple.SetActive(false); //遊戲一開始看不見蘋果
    }

    // Update is called once per frame
    void Update()
    {
        if (!_apple.activeSelf)
        {
            _duration += Time.deltaTime;
            if (_duration >= _appleShowTime)
            {
                ShowApple();
            }
        }
        else
        {
            if (_apple.transform.position == _snake.transform.position)
            {
                EatApple();
            }
        }
    }

    void ShowApple()
    {
        _apple.SetActive(true);
        _apple.transform.position = new Vector3(Random.Range(-9, 10), Random.Range(-9, 10), 0);
        _duration = 0;
    }

    void EatApple()
    {
        _apple.SetActive(false);
        _snake.AddBody();
    }
}
