using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float moveDistance = 8f;
    private float initialPositionY; // Начальная позиция бота по оси Y
    private bool movingDown = true; // Флаг для определения направления движения
    public int checkCounterSwitcher;

    bool moving;

    void Start()
    {
        initialPositionY = transform.position.y; // Сохраняем начальную позицию бота
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
            // Перемещение бота вперед и назад на заданное расстояние
            if (movingDown)
            {
                transform.Translate(Vector2.down * moveSpeed * Time.deltaTime); // Движение вниз
            }
            else
            {
                if(transform.position.y <= initialPositionY)
                {
                    transform.Translate(-Vector2.down * moveSpeed * Time.deltaTime); // Движение назад
                }
                else
                {
                    movingDown = !movingDown;
                }
            }

            // Проверка достижения конечной точки для изменения направления
            if (Mathf.Abs(transform.position.y - initialPositionY) >= moveDistance)
            {
                movingDown = !movingDown; // Изменение направления
            }
        }
        else
        {
            if (transform.position.y < initialPositionY)
            {
                transform.Translate(-Vector2.down * moveSpeed * Time.deltaTime); // Движение назад
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
