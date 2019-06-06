using UnityEngine;

public class MouseFollow2D : MonoBehaviour
{

    private Vector3 mousePosition;
    private Transform player;
    //private Transform gun;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        //Check = GameObject.FindGameObjectWithTag("GameController").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //gun = GameObject.FindGameObjectWithTag("Gun").transform;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(player.position.x, player.position.y + 0.5f, transform.position.z);
        // Тот самый поворот
        // вычисляем разницу между текущим положением и положением мыши
        Vector3 difference = mousePosition - transform.position;
        difference.Normalize();
        // вычисляемый необходимый угол поворота
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        // Применяем поворот вокруг оси Z
        transform.rotation = Quaternion.Euler(0, 0, rotation_z);
    }
}