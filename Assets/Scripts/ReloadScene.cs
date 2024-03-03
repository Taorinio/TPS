using UnityEngine;
//подключить библиотеку управления сценами
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    void Update()
    {
        //Проверить, что была нажата клавиша Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Загрузить текущую сцену по ее имени
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
