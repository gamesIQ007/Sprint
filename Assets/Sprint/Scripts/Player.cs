using UnityEngine;
using UnityEngine.InputSystem;

namespace Sprint
{
    [RequireComponent(typeof(Rigidbody))]

    /// <summary>
    /// Класс, отвечающий за поведение игрока
    /// </summary>
    public class Player : MonoBehaviour
    {
        /// <summary>
        /// Скорость перемещения
        /// </summary>
        [SerializeField] private float m_MoveSpeed;

        [Header("Mouse")]
        /// <summary>
        /// Чувствительность мыши по осям X и Y
        /// </summary>
        [SerializeField] private float m_MouseSensitivityX;
        [SerializeField] private float m_MouseSensitivityY;

        /// <summary>
        /// Минимальный и максимальный углы наклона по оси Y
        /// </summary>
        [SerializeField] private float m_MouseMinY;
        [SerializeField] private float m_MouseMaxY;

        /// <summary>
        /// Ссылка на камеру
        /// </summary>
        private Camera сameraY;

        /// <summary>
        /// Изначальный поворот мыши по оси Y
        /// </summary>
        private float mouseRotationY = 0.0f;

        /// <summary>
        /// Вектор перемещения
        /// </summary>
        private Vector3 m_MoveVector = Vector3.zero;

        /// <summary>
        /// Ссылка на Rigidbody
        /// </summary>
        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            сameraY = GetComponentInChildren<Camera>();
        }

        private void FixedUpdate()
        {
            rb.AddForce(transform.forward * m_MoveVector.z * m_MoveSpeed, ForceMode.Impulse);
            rb.AddForce(transform.right * m_MoveVector.x * m_MoveSpeed, ForceMode.Impulse);
        }

        /// <summary>
        /// Управление перемещением
        /// </summary>
        /// <param name="input">Входные данные</param>
        private void OnMove(InputValue input)
        {
            Vector2 inputVector = input.Get<Vector2>();

            m_MoveVector = new Vector3(inputVector.x, 0, inputVector.y);
        }

        /// <summary>
        /// Вращение мышью
        /// </summary>
        /// <param name="input">Входные данные</param>
        private void OnMouseCameraMovement(InputValue input)
        {
            Vector2 inputVector = input.Get<Vector2>();

            float rotationX = transform.localEulerAngles.y + inputVector.x * m_MouseSensitivityX;

            mouseRotationY += inputVector.y * m_MouseSensitivityY;
            mouseRotationY = Mathf.Clamp(mouseRotationY, m_MouseMinY, m_MouseMaxY);

            transform.localEulerAngles = new Vector3(0, rotationX, 0);
            сameraY.transform.localEulerAngles = new Vector3(-mouseRotationY, 0, 0);
        }
    }
}