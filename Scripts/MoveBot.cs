using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBot : MonoBehaviour
{
    public float moveSpeed = 3f; // �������� ����������� ����
    public float moveDistance = 5f; // ����������, �� ������� ������ ������������� ���

    private float initialPositionX; // ��������� ������� ���� �� ��� X
    private bool movingForward = true; // ���� ��� ����������� ����������� ��������

    private SpriteRenderer spriteRenderer;
    private GameObject child2;
    private GameObject child3;

    void Start()
    {
        initialPositionX = transform.position.x; // ��������� ��������� ������� ����
        movingForward = (Random.Range(0, 2) == 1);

        // ����������� ����������� ��� ��������� ������������������
        spriteRenderer = GetComponent<SpriteRenderer>();
        child2 = transform.GetChild(2).gameObject;
        child3 = transform.GetChild(3).gameObject;
    }

    void FixedUpdate()
    {
        // �������� ���������� �������� ����� ��� ��������� �����������
        if (Mathf.Abs(transform.position.x - initialPositionX) >= moveDistance)
        {
            movingForward = !movingForward; // ��������� �����������
        }
        // ����������� ���� ������ � ����� �� �������� ����������
        if (movingForward)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.fixedDeltaTime); // �������� ������
            spriteRenderer.flipX = true;
            child2.SetActive(false);
            child3.SetActive(true);
        }
        else
        {
            transform.Translate(-Vector2.right * moveSpeed * Time.fixedDeltaTime); // �������� �����
            spriteRenderer.flipX = false;
            child2.SetActive(true);
            child3.SetActive(false);
        }
    }
}
