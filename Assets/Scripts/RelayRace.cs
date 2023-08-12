using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelayRace : MonoBehaviour
{
    [SerializeField] float Speed;           // скорость передвижения объекта


    Queue<Transform> runners;                    // массив бегунов
    private const int RUNNERS_AMOUNT = 5;   // количество бегунов

    private Transform currentRunner;
    private Transform targetRunner;


    void Start()
    {
        runners = new Queue<Transform>();
        InitializeRunners();

        currentRunner = runners.Dequeue();
        targetRunner = runners.Peek();

        currentRunner.transform.LookAt(targetRunner.position);
    }

    private void InitializeRunners()
    {
        for (int i = 0; i < RUNNERS_AMOUNT; i++)
        {
            runners.Enqueue(transform.Find($"Runner {i + 1}"));
        }
    }
    void Update()
    {
        currentRunner.position = Vector3.MoveTowards(currentRunner.position, targetRunner.position, Speed * Time.deltaTime);

        if (currentRunner.position == targetRunner.position)
            SwitchRunner();
    }

    /// <summary>
    /// Меняет активного бегуна
    /// </summary>
    private void SwitchRunner()
    {
        runners.Enqueue(currentRunner);
        currentRunner = runners.Dequeue();
        targetRunner = runners.Peek();
    }

}
