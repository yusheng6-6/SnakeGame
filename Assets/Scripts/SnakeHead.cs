using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    [SerializeField] float _timePerUnit = 0.5f;
    float _time;
    Vector2Int _previousDirection;
    bool _isturn = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _time = 0f;
        _previousDirection = Vector2Int.up;
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
        if ( _time > _timePerUnit)
        {
            transform.Translate(0, 1f, 0);
            _time -= _timePerUnit;
            _isturn = false; //�@�椺�u����V�@��
        }
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
}
