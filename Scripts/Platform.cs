using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float moveDistance = 8f;
    private float initialPositionY; // ��������� ������� ���� �� ��� Y
    private bool movingDown = true; // ���� ��� ����������� ����������� ��������
    public int checkCounterSwitcher;

    bool moving;

    void Start()
    {
        initialPositionY = transform.position.y; // ��������� ��������� ������� ����
    }
    
    private void OnEnable()
    {
        LevelArm.movePlatform += MovePlatform;
    }
    private void OnDisable()
    {
        LevelArm.movePlatform -= MovePlatform;
    }
    void Update()
    {
        if (moving)
        {
            // ����������� ���� ������ � ����� �� �������� ����������
            if (movingDown)
            {
                transform.Translate(Vector2.down * moveSpeed * Time.deltaTime); // �������� ����
            }
            else
            {
                if(transform.position.y <= initialPositionY)
                {
                    transform.Translate(-Vector2.down * moveSpeed * Time.deltaTime); // �������� �����
                }
                else
                {
                    movingDown = !movingDown;
                }
            }

            // �������� ���������� �������� ����� ��� ��������� �����������
            if (Mathf.Abs(transform.position.y - initialPositionY) >= moveDistance)
            {
                movingDown = !movingDown; // ��������� �����������
            }
        }
        else
        {
            if (transform.position.y < initialPositionY)
            {
                transform.Translate(-Vector2.down * moveSpeed * Time.deltaTime); // �������� �����
            }
        }
    }
    void MovePlatform(bool move, int switcher)
    {
        if(switcher == checkCounterSwitcher)
        {
            moving = move;
        }
    }
}
