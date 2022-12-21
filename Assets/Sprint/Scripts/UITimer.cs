using UnityEngine;
using TMPro;

namespace Sprint
{
    /// <summary>
    /// ����������� ������� � ����������
    /// </summary>
    public class UITimer : MonoBehaviour
    {
        /// <summary>
        /// ����� �� ��������
        /// </summary>
        [SerializeField] private TextMeshProUGUI m_TimeText;

        /// <summary>
        /// ����� � ������ ��������
        /// </summary>
        [SerializeField] private TextMeshProUGUI m_BestTimeText;

        /// <summary>
        /// ������ �� ������
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
        /// ������� �� ������� ���������� ������� �������
        /// </summary>
        private void OnNewBestTime()
        {
            m_BestTimeText.text = FloatToTimeConvert(m_Timer.BestTime);
        }

        /// <summary>
        /// ������������ ����� �� float � ��������� ������ �������
        /// </summary>
        /// <param name="time">�����</param>
        /// <returns>����� � ��������� �������</returns>
        private string FloatToTimeConvert(float time)
        {
            float minutes = Mathf.FloorToInt(time / 60);
            float seconds = Mathf.FloorToInt(time % 60);

            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}