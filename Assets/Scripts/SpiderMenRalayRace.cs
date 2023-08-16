using System;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMenRelayRace : MonoBehaviour
{
    private const int RUNNERS_AMOUNT = 5;       // количество бегунов
    private const float MIN_DISTANCE = 5f;      // минимальное допустимое расстояние между бегунами

    [SerializeField] float Speed;               // скорость передвижения объектов
    [SerializeField] GameObject Cake;           // объект, который будут передавать бегуны

    private Queue<Transform> runners;           // очередь бегунов

    private Transform previousRunner;           // предыдущий бегун
    private Transform currentRunner;            // текущий бегун
    private Transform targetRunner;             // цель текущего бегуна

    private Vector3 previousTarget;             // координаты предыдущей цели

    void Start()
    {
        runners = new Queue<Transform>();
        InitializeRunners();

        currentRunner = runners.Dequeue();
        targetRunner = runners.Peek();
    }


    /// <summary>
    /// Инициализация очереди из бегунов
    /// </summary>
    private void InitializeRunners()
    {
        for (int i = 0; i < RUNNERS_AMOUNT; i++)
        {
            Transform runnerToAdd = transform.Find($"Runner {i + 1}");
            runners.Enqueue(runnerToAdd);
        }
    }
    void Update()
    {
        currentRunner.position = Vector3.MoveTowards(currentRunner.position,
                                 targetRunner.position, Speed * Time.deltaTime);
        currentRunner.LookAt(targetRunner);
        LookAtRunner();

        // плавная остановка предыдущего бегуна 
        if (previousRunner && previousRunner.position != previousTarget)
        {
            previousRunner.position = Vector3.Lerp(previousRunner.position,
                                      previousTarget, 0.1f);
            float distance = Vector3.Distance(previousTarget, previousRunner.position);
            double distanceRounded = Math.Round(distance, 2);
            if (distanceRounded == 0)
            {
                previousRunner.position = previousTarget;
            }
        }
        // смена бегунов, если активный бегун подбежал на расстояние MIN_DISTANCE к объекту-цели
        if (Vector3.Distance(currentRunner.position, targetRunner.position) <= MIN_DISTANCE)
        {
            SwitchCoordinates();
            SwitchRunner();
            // передача торта актівному бегуну
            Cake.transform.SetParent(currentRunner);
        }
    }

    /// <summary>
    /// Меняет активного бегуна
    /// </summary>
    private void SwitchRunner()
    {
        runners.Enqueue(currentRunner);
        previousRunner = currentRunner;
        currentRunner = runners.Dequeue();
        targetRunner = runners.Peek();
    }

    /// <summary>
    /// Меняет координаты для предыдущего бегуна
    /// </summary>
    private void SwitchCoordinates()
    {
        previousTarget = targetRunner.position;
    }

    /// <summary>
    /// Направляет "взгляд" всех не бегущих объектов на активного бегуна
    /// </summary>
    private void LookAtRunner()
    {
        foreach (Transform runner in runners)
        {
            if (runner != currentRunner)
            {
                runner.LookAt(currentRunner);
            }
        }
    }

}
