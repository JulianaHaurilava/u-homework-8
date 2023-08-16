using System;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMenRelayRace : MonoBehaviour
{
    private const int RUNNERS_AMOUNT = 5;       // ���������� �������
    private const float MIN_DISTANCE = 5f;      // ����������� ���������� ���������� ����� ��������

    [SerializeField] float Speed;               // �������� ������������ ��������
    [SerializeField] GameObject Cake;           // ������, ������� ����� ���������� ������

    private Queue<Transform> runners;           // ������� �������

    private Transform previousRunner;           // ���������� �����
    private Transform currentRunner;            // ������� �����
    private Transform targetRunner;             // ���� �������� ������

    private Vector3 previousTarget;             // ���������� ���������� ����

    void Start()
    {
        runners = new Queue<Transform>();
        InitializeRunners();

        currentRunner = runners.Dequeue();
        targetRunner = runners.Peek();
    }


    /// <summary>
    /// ������������� ������� �� �������
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

        // ������� ��������� ����������� ������ 
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
        // ����� �������, ���� �������� ����� �������� �� ���������� MIN_DISTANCE � �������-����
        if (Vector3.Distance(currentRunner.position, targetRunner.position) <= MIN_DISTANCE)
        {
            SwitchCoordinates();
            SwitchRunner();
            // �������� ����� �������� ������
            Cake.transform.SetParent(currentRunner);
        }
    }

    /// <summary>
    /// ������ ��������� ������
    /// </summary>
    private void SwitchRunner()
    {
        runners.Enqueue(currentRunner);
        previousRunner = currentRunner;
        currentRunner = runners.Dequeue();
        targetRunner = runners.Peek();
    }

    /// <summary>
    /// ������ ���������� ��� ����������� ������
    /// </summary>
    private void SwitchCoordinates()
    {
        previousTarget = targetRunner.position;
    }

    /// <summary>
    /// ���������� "������" ���� �� ������� �������� �� ��������� ������
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
