using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow2d : MonoBehaviour
{
    Camera camera;
    public float damping = 1.5f;
    public float horBound;//расстояние до границы по горизонтали
    public float vertBound;//расстояние до границы по вертикали
    public float leftBound, rightBound, upBound, downBound;
    public Vector2 offset = new Vector2(1f, 1f);
    public static bool faceLeft;
    private Transform player;
    private Vector3 min, max;
    //private int lastX;

    void Start()
    {
        camera = GetComponent<Camera>();
        vertBound = camera.orthographicSize;
        horBound = camera.orthographicSize / Screen.height * Screen.width;
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        CalculateBounds();
    }

    void Update()
    {
        if (player)
        {
            //int currentX = Mathf.RoundToInt(player.position.x);
            // if (currentX > lastX) faceLeft = false; else if (currentX < lastX) faceLeft = true;
            // lastX = Mathf.RoundToInt(player.position.x);
            //leftBound = transform.position.x - horBound;
            //rightBound = transform.position.x + horBound;
            //upBound = transform.position.y + vertBound;
            //downBound = transform.position.y - vertBound;
            Vector3 target;
            if (faceLeft)
            {
                target = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
            }
            else
            {
                target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
            }
            Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
            currentPosition = MoveInside(currentPosition, new Vector3(min.x, min.y, currentPosition.z), new Vector3(max.x, max.y, currentPosition.z));
            transform.position = currentPosition;
            
        }
    }
    public void CalculateBounds()
    {
        Bounds bounds = Camera2DBounds();
        min = bounds.max + Map.min;
        max = bounds.min + Map.max;
    }
    Bounds Camera2DBounds()
    {
        float height = camera.orthographicSize * 2;
        return new Bounds(Vector3.zero, new Vector3(height * camera.aspect, height, 0));
    }
    Vector3 MoveInside(Vector3 current, Vector3 pMin, Vector3 pMax)
    {
        //if (!useBounds || boundsMap == null) return current;
        current = Vector3.Max(current, pMin);
        current = Vector3.Min(current, pMax);
        return current;
    }
}
