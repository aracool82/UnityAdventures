using System.Collections;
using UnityEngine;

namespace _Project_L1
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private LoadingScreen _loadingScreen;
        [SerializeField] private ConfirmPopup _confirmPopup;
        
        private void Awake()
        {
            StartCoroutine(ProcessStart());
        }

        private IEnumerator ProcessStart()
        {
            _loadingScreen.Show();
            //создание каких то вспомогательных сервисов
            //процесс создания рекламных аналитик,сервисов
            //подгрузка настроек
            //загрузка или генерация уровня.окружения
            //другие подготовительные операции
            
            //симуляции какой-то инициализации
            
            yield return new WaitForSeconds(1);
            
            _loadingScreen.Hide();
        }

        private void Update()
        {

        }
    }
}