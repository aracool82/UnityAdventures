using System.Collections;
using UnityEngine;

namespace _Project31.Scripts
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private LoadingScreen _loadingScreen;
        [SerializeField] private ConfirmPopup _confirmPopup;
        
        private GameCycle _gameCycle;
        
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
            _gameCycle = new GameCycle(this,_confirmPopup);
            
            yield return new WaitForSeconds(1);
            
            _loadingScreen.Hide();
           
            _gameCycle.Launch();
        }

        private void Update()
        {
            _gameCycle?.Update(Time.deltaTime);
        }
    }
}