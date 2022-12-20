using UnityEngine;
using UnityEngine.InputSystem;

namespace Sprint
{
    [RequireComponent(typeof(Rigidbody))]

    /// <summary>
    /// �����, ���������� �� ��������� ������
    /// </summary>
    public class Player : MonoBehaviour
    {
        /// <summary>
        /// �������� �����������
        /// </summary>
        [SerializeField] private float m_MoveSpeed;

        [Header("Mouse")]
        /// <summary>
        /// ���������������� ���� �� ���� X � Y
        /// </summary>
        [SerializeField] private float m_MouseSensitivityX;
        [SerializeField] private float m_MouseSensitivityY;

        /// <summary>
        /// ����������� � ������������ ���� ������� �� ��� Y
        /// </summary>
        [SerializeField] private float m_MouseMinY;
        [SerializeField] private float m_MouseMaxY;

        /// <summary>
        /// ������ �� ������
        /// </summary>
        private Camera �ameraY;

        /// <summary>
        /// ����������� ������� ���� �� ��� Y
        /// </summary>
        private float mouseRotationY = 0.0f;

        /// <summary>
        /// ������ �����������
        /// </summary>
        private Vector3 m_MoveVector = Vector3.zero;

        /// <summary>
        /// ������ �� Rigidbody
        /// </summary>
        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            �ameraY = GetComponentInChildren<Camera>();
        }

        private void FixedUpdate()
        {
            rb.AddForce(transform.forward * m_MoveVector.z * m_MoveSpeed, ForceMode.Impulse);
            rb.AddForce(transform.right * m_MoveVector.x * m_MoveSpeed, ForceMode.Impulse);
        }

        /// <summary>
        /// ���������� ������������
        /// </summary>
        /// <param name="input">������� ������</param>
        private void OnMove(InputValue input)
        {
            Vector2 inputVector = input.Get<Vector2>();

            m_MoveVector = new Vector3(inputVector.x, 0, inputVector.y);
        }

        /// <summary>
        /// �������� �����
        /// </summary>
        /// <param name="input">������� ������</param>
        private void OnMouseCameraMovement(InputValue input)
        {
            Vector2 inputVector = input.Get<Vector2>();

            float rotationX = transform.localEulerAngles.y + inputVector.x * m_MouseSensitivityX;

            mouseRotationY += inputVector.y * m_MouseSensitivityY;
            mouseRotationY = Mathf.Clamp(mouseRotationY, m_MouseMinY, m_MouseMaxY);

            transform.localEulerAngles = new Vector3(0, rotationX, 0);
            �ameraY.transform.localEulerAngles = new Vector3(-mouseRotationY, 0, 0);
        }
    }
}