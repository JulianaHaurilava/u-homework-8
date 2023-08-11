using UnityEngine;

public class MovingScript : MonoBehaviour
{
    [SerializeField] float Speed;       // скорость передвижения объекта

    private Vector3[] vectorArr;        // массив векторов
    private Vector3 targetPoint;        // точка, к которой стремится объект на отрезке
    private int currentPosition;        // позиция targetPoint в массиве
    private bool isMovingForward;       // движется ли точка от первой точки к последней или наоборот

    private const int ARR_SIZE = 5;     // размер массива векторов vectorArr

    void Start()
    {
        currentPosition = 1;
        isMovingForward = true;

        vectorArr = new Vector3[ARR_SIZE] { new(0, 0, 0), new(1, 0, 6), new(2, 0, 3), new(5, 0, 3), new(4, 0, 7) };
        transform.position = vectorArr[currentPosition - 1];
        targetPoint = vectorArr[currentPosition];
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, Speed * Time.deltaTime);

        if (transform.position == targetPoint)
            SwitchTargetPoint();
    }

    /// <summary>
    /// Задаёт следующую target-точку из массива векторов vectorArr
    /// </summary>
    private void SwitchTargetPoint()
    {
        if (currentPosition == ARR_SIZE - 1 || currentPosition == 0)
        {
            isMovingForward = !isMovingForward;
        }

        if (isMovingForward)
            currentPosition++;
        else
            currentPosition--;

        targetPoint = vectorArr[currentPosition];
    }
}
