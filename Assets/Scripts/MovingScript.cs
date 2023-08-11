using UnityEngine;

public class MovingScript : MonoBehaviour
{
    [SerializeField] float Speed;       // �������� ������������ �������

    private Vector3[] vectorArr;        // ������ ��������
    private Vector3 targetPoint;        // �����, � ������� ��������� ������ �� �������
    private int currentPosition;        // ������� targetPoint � �������
    private bool isMovingForward;       // �������� �� ����� �� ������ ����� � ��������� ��� ��������

    private const int ARR_SIZE = 5;     // ������ ������� �������� vectorArr

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
    /// ����� ��������� target-����� �� ������� �������� vectorArr
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
