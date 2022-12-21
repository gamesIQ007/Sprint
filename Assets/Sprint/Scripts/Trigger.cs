using UnityEngine;
using UnityEngine.Events;

namespace Sprint
{
    /// <summary>
    /// �������, ����������� �� ����/����� ������
    /// </summary>
    public class Trigger : MonoBehaviour
    {
        public UnityEvent Enter;
        public UnityEvent Exit;

        private void OnTriggerEnter(Collider other)
        {
            Player fps = other.GetComponent<Player>();

            if (fps != null)
            {
                Enter.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Player fps = other.GetComponent<Player>();

            if (fps != null)
            {
                Exit.Invoke();
            }
        }
    }
}