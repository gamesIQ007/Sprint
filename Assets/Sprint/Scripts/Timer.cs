using UnityEngine;
using UnityEngine.Events;

namespace Sprint
{
    [RequireComponent(typeof(AudioSource))]

    /// <summary>
    /// Таймер
    /// </summary>
    public class Timer : MonoBehaviour
    {
        /// <summary>
        /// Активность таймера
        /// </summary>
        private bool isEnabled = false;
        public bool IsEnabled => isEnabled;

        /// <summary>
        /// Время
        /// </summary>
        private float time;
        public float CurrentTime => time;

        /// <summary>
        /// Лучшее время
        /// </summary>
        private float bestTime;
        public float BestTime => bestTime;

        /// <summary>
        /// Событие при новом лучшем времени
        /// </summary>
        [HideInInspector] public UnityEvent NewBestTime;

        private AudioSource audioSource;

        private void Start()
        {
            time = 0;
            bestTime = 0;
            audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (isEnabled == false) return;

            time += Time.deltaTime;
        }

        /// <summary>
        /// Запуск таймера
        /// </summary>
        public void StartTimer()
        {
            isEnabled = true;
            time = 0;
            audioSource.Play();
        }

        /// <summary>
        /// Отключить таймер
        /// </summary>
        public void StopTimer()
        {
            isEnabled = false;
            audioSource.Stop();

            if (bestTime > time || bestTime == 0)
            {
                bestTime = time;
                NewBestTime.Invoke();
            }
        }
    }
}