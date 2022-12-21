using UnityEngine;
using TMPro;

namespace Sprint
{
    /// <summary>
    /// Отображение таймера в интерфейсе
    /// </summary>
    public class UITimer : MonoBehaviour
    {
        /// <summary>
        /// Текст со временем
        /// </summary>
        [SerializeField] private TextMeshProUGUI m_TimeText;

        /// <summary>
        /// Текст с лучшим временем
        /// </summary>
        [SerializeField] private TextMeshProUGUI m_BestTimeText;

        /// <summary>
        /// Ссылка на таймер
        /// </summary>
        [SerializeField] private Timer m_Timer;

        private void Awake()
        {
            m_Timer.NewBestTime.AddListener(OnNewBestTime);
        }

        private void OnDestroy()
        {
            m_Timer.NewBestTime.RemoveListener(OnNewBestTime);
        }

        private void Update()
        {
            if (m_Timer.IsEnabled == false) return;

            m_TimeText.text = FloatToTimeConvert(m_Timer.CurrentTime);
        }

        /// <summary>
        /// Реакция на событие обновления лучшего времени
        /// </summary>
        private void OnNewBestTime()
        {
            m_BestTimeText.text = FloatToTimeConvert(m_Timer.BestTime);
        }

        /// <summary>
        /// Конвертируем время из float в привычный формат времени
        /// </summary>
        /// <param name="time">Время</param>
        /// <returns>Время в привычном формате</returns>
        private string FloatToTimeConvert(float time)
        {
            float minutes = Mathf.FloorToInt(time / 60);
            float seconds = Mathf.FloorToInt(time % 60);

            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}