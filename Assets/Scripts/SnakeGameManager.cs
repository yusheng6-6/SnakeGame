using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGameManager : MonoBehaviour
{
    [SerializeField] GameObject _apple;
    [SerializeField] GameObject _snake;

    [SerializeField] float _noAppleTime = 1.0f;

    float _duration = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _apple.SetActive(false); //遊戲一開始看不見蘋果
    }

    // Update is called once per frame
    void Update()
    {
        if (_apple.activeSelf == false)
        {
            _duration += Time.deltaTime;
            if (_duration >= _noAppleTime)
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
        Debug.Log("Show Apple");
        _apple.SetActive(true);
        _apple.transform.position = new Vector3(Random.Range(-9, 10), Random.Range(-9, 10), 0);
    }

    void EatApple()
    {
        Debug.Log("Eat Apple");
        _apple.SetActive(false);
        _duration = 0f;
    }
}
