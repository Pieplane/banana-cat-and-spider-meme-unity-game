using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBot : MonoBehaviour
{
    public float moveSpeed = 3f; // Скорость перемещения бота
    public float moveDistance = 5f; // Расстояние, на которое должен переместиться бот

    private float initialPositionX; // Начальная позиция бота по оси X
    private bool movingForward = true; // Флаг для определения направления движения

    private SpriteRenderer spriteRenderer;
    private GameObject child2;
    private GameObject child3;

    void Start()
    {
        initialPositionX = transform.position.x; // Сохраняем начальную позицию бота
        movingForward = (Random.Range(0, 2) == 1);

        // Кэширование компонентов для улучшения производительности
        spriteRenderer = GetComponent<SpriteRenderer>();
        child2 = transform.GetChild(2).gameObject;
        child3 = transform.GetChild(3).gameObject;
    }

    void FixedUpdate()
    {
        // Проверка достижения конечной точки для изменения направления
        if (Mathf.Abs(transform.position.x - initialPositionX) >= moveDistance)
        {
            movingForward = !movingForward; // Изменение направления
        }
        // Перемещение бота вперед и назад на заданное расстояние
        if (movingForward)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.fixedDeltaTime); // Движение вперед
            spriteRenderer.flipX = true;
            child2.SetActive(false);
            child3.SetActive(true);
        }
        else
        {
            transform.Translate(-Vector2.right * moveSpeed * Time.fixedDeltaTime); // Движение назад
            spriteRenderer.flipX = false;
            child2.SetActive(true);
            child3.SetActive(false);
        }
    }
}
