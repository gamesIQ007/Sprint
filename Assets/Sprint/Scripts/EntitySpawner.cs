using System.Collections.Generic;
using UnityEngine;

namespace Sprint
{
    /// <summary>
    /// ������� ��������
    /// </summary>
    public class EntitySpawner : MonoBehaviour
    {
        /// <summary>
        /// ����������� �������
        /// </summary>
        [SerializeField] private GameObject[] m_EntityPrefabs;

        /// <summary>
        /// ����� ������
        /// </summary>
        [SerializeField] private Transform[] m_SpawnPoints;

        /// <summary>
        /// ����������� ������
        /// </summary>
        [Range(0, 100)]
        [SerializeField] private int m_SpawnRate;

        /// <summary>
        /// ������ ������������ ��������
        /// </summary>
        private List<GameObject> spawnedEntities;

        private void Start()
        {
            spawnedEntities = new List<GameObject>();
        }

        /// <summary>
        /// ���������� �������
        /// </summary>
        public void SpawnEntities()
        {
            DestroyEntities();

            for (int i = 0; i < m_SpawnPoints.Length; i++)
            {
                if (Random.Range(0, 100) < m_SpawnRate)
                {
                    int entityNum = Random.Range(0, m_EntityPrefabs.Length);
                    GameObject obj = Instantiate(m_EntityPrefabs[entityNum], m_SpawnPoints[i].position, Quaternion.Euler(0, Random.Range(0, 360), 0));
                    spawnedEntities.Add(obj);
                }
            }
        }

        /// <summary>
        /// ����������� ������������ ���������
        /// </summary>
        public void DestroyEntities()
        {
            foreach (GameObject entity in spawnedEntities)
            {
                Destroy(entity);
            }
            spawnedEntities.Clear();
        }
    }
}