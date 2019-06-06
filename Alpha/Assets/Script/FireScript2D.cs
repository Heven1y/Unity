using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript2D : MonoBehaviour
{
    //Наш пул объектов, который помогает 
    //сохранить память при его использовании
    //Ведь активировать объект гораздо проще, 
    //чем его опять создавать
    public static int boezapas = 30;
    public List<GameObject> ObjectPool;
    private void Start()
    {
        //Создаем новый список, так как List - 
        //ссылка на динамический массив
        ObjectPool = new List<GameObject>();
    }
    void Update()
    {
        //Выстрел будет производится при клике мышкой
        if ((Input.GetMouseButtonUp(0) == true) && (boezapas > 0))
        {
            //diff - будет смещением нашего нажатия от объекта
            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            //номализация приводит каждое значение в промежуток
            //от -1 до 1
            diff.Normalize();
            //по нормализованному виду мы находим угол, так как в diff
            //Показывает, нашли ли мы выключенный объект в нашем массиве
            bool freeBullet = false;
            //находится вектор, который можно перенести на тригонометрическую окружность
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            //и приваиваем наш угол персонажу
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
            //Теперь необходимо проверить, есть ли выключенный объект в нашем пуле
            for (int i = 0; i < ObjectPool.Count; i++)
            {
                //Смотрим, активен ли объект в игровом пространстве
                if (!ObjectPool[i].activeInHierarchy)
                {
                    //Если объект не активен
                    //То мы задаем ему все нужные параметры
                    //Позицию
                    ObjectPool[i].transform.position = transform.position;
                    //Поворот
                    ObjectPool[i].transform.rotation = transform.rotation;
                    //И опять его включаем
                    ObjectPool[i].SetActive(true);
                    //Ставим объект найденным, чтоб опять не создавать лишний
                    freeBullet = true;
                    break;
                }
            }
            //если свободный объект не был найден, то нужно создать еще один
            if (!freeBullet)
            {
                //Создаем объект с нужными значениями и заносим его в пул
                ObjectPool.Add(Instantiate(Resources.Load("Prefabs/bullet", typeof(GameObject)), transform.position, transform.rotation) as GameObject);
            }
            boezapas--;
        }
    }
    private void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 30), "Патронов: " + boezapas);
    }
}
