using UnityEngine;

public class TouchScreen : MonoBehaviour
{
    public float sensitivity = 1f;
    public float range = 5f;
    private Vector3 lastPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Camera.main.ScreenToWorldPoint(lastPosition);
            Vector3 delta = Input.mousePosition - lastPosition;
            Vector3 newPos = transform.position + new Vector3(delta.x * sensitivity * Time.deltaTime, 0, 0);

            // 이동 가능 범위 제한
            if (Mathf.Abs(newPos.x) < range)
            {
                transform.Translate(delta.x * sensitivity * Time.deltaTime, 0, 0);
                lastPosition = Input.mousePosition;
            }
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
