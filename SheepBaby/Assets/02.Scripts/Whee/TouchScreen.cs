using UnityEngine;

public class TouchScreen : MonoBehaviour
{
    public float sensitivity = 1f;      // 이동 감도

    private Vector3 lastPosition;       // 마우스가 이동한 마지막 위치

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastPosition = Input.mousePosition;
            Debug.Log(323);
        }

        if (Input.GetMouseButton(0))
        {
            Camera.main.ScreenToWorldPoint(lastPosition);
            Vector3 delta = Input.mousePosition - lastPosition;
            transform.Translate(delta.x * sensitivity * Time.deltaTime, 0, 0);
            lastPosition = Input.mousePosition;
        }

        if (Input.touchCount > 0)
        {
            Debug.Log(22);
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = touch.position;
            }
        }
    }
}
