using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeHead : MonoBehaviour
{
    [SerializeField] SnakeGameManager _snakeGameManager;

    [SerializeField] float _timePerUnit = 0.5f;
    [SerializeField] GameObject _snakeBodyPrefab;

    float _time;
    Vector2Int _previousDirection;
    bool _isturn = false;

    List<GameObject> _snakeBodies;
    Collider2D _justCreatebody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _time = 0f;
        _previousDirection = Vector2Int.up;
        _snakeBodies = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Turn(Vector2Int.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Turn(Vector2Int.right);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Turn(Vector2Int.up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Turn(Vector2Int.down);
        }

        //�@��@��e�i
        _time += Time.deltaTime;
        if ( _time >= _timePerUnit)
        {
            Move();
            _time -= _timePerUnit;
            _isturn = false; //�@�椺�u����V�@��
        }
    }

    void Move()
    {
        for(int i = _snakeBodies.Count - 1; i > 0; --i)
        {
            _snakeBodies[i].transform.position = _snakeBodies[i - 1].transform.position;
        }
        if (_snakeBodies.Count > 0)
        {
            _snakeBodies[0].transform.position = transform.position;            
        }
        if(_justCreatebody != null && _justCreatebody.isTrigger)
        {
            _justCreatebody.isTrigger = false;
            _justCreatebody = null;
        }
        transform.Translate(0, 1f, 0);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Body"))
        {
            GameOver();
        }

        if (collision.gameObject.CompareTag("Apple"))
        {
            _snakeGameManager.EatApple();
        }

    }


    void GameOver()
    {
        _isturn = true;
        Time.timeScale = 0;
    }

    void Turn(Vector2Int direction)
    {
        if (_isturn == false) //�@�椺�u����V�@��
        {
            var angle = Vector2.SignedAngle(_previousDirection, direction); //��e��V�P�����V������
            if (angle != 0 && angle != 180)
            {
                transform.Rotate(Vector3.forward, angle); //2D��forward
                _previousDirection = direction;
                _isturn = true;
            }
        }
    }
    
    public void AddBody()
    {
        var bodyClone = Instantiate(_snakeBodyPrefab);
        bodyClone.transform.position = transform.position;
        _justCreatebody = bodyClone.GetComponent<Collider2D>();
        _justCreatebody.isTrigger = true; //�]����}�l�K�[�D�Y�D����m�ۦP�A�|�o�͸I����bug
        _snakeBodies.Add(bodyClone);

    }
}
