using System.Collections.Generic;
using UnityEngine;

namespace Sprint
{
    /// <summary>
    /// Спавнер объектов
    /// </summary>
    public class EntitySpawner : MonoBehaviour
    {
        /// <summary>
        /// Спавнящиеся объекты
        /// </summary>
        [SerializeField] private GameObject[] m_EntityPrefabs;

        /// <summary>
        /// Точки спавна
        /// </summary>
        [SerializeField] private Transform[] m_SpawnPoints;

        /// <summary>
        /// Вероятность спавна
        /// </summary>
        [Range(0, 100)]
        [SerializeField] private int m_SpawnRate;

        /// <summary>
        /// Список заспавленных объектов
        /// </summary>
        private List<GameObject> spawnedEntities;

        private void Start()
        {
            spawnedEntities = new List<GameObject>();
        }

        /// <summary>
        /// Заспавнить объекты
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
        /// Уничтожение заспавленных элементов
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