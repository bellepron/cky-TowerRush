using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CKY.Pooling
{
    public class PoolManager : SingletonPersistent<PoolManager>
    {
        [System.Serializable]
        public class Pool
        {
            public Transform prefabTr;
            public int size;
        }

        public List<Pool> pools;
        public Dictionary<Transform, Queue<GameObject>> poolDictionary;

        private void Start()
        {
            poolDictionary = new Dictionary<Transform, Queue<GameObject>>();

            foreach (Pool pool in pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                for (int i = 0; i < pool.size; i++)
                {
                    GameObject obj = Instantiate(pool.prefabTr.gameObject, this.transform);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }

                poolDictionary.Add(pool.prefabTr, objectPool);
            }
        }

        public GameObject Spawn(Transform prefabTr, Vector3 position, Quaternion rotation)
        {
            if (!poolDictionary.ContainsKey(prefabTr))
            {
                Debug.LogWarning($"Pool doesn't have {prefabTr}");
                return null;
            }

            GameObject objectToSpawn = poolDictionary[prefabTr].First();

            if (objectToSpawn.activeInHierarchy == false)
            {
                objectToSpawn = poolDictionary[prefabTr].Dequeue();
            }
            else
            {
                objectToSpawn = Instantiate(prefabTr.gameObject, this.transform);
            }

            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            if (objectToSpawn.TryGetComponent<IPooledObject>(out var pooledObj) == true)
            {
                pooledObj.OnObjectSpawn();
            }

            poolDictionary[prefabTr].Enqueue(objectToSpawn);

            return objectToSpawn;
        }

        public void Despawn(GameObject pooledObj)
        {
            pooledObj.SetActive(false);
            pooledObj.transform.parent = this.transform;
        }
        public void ResetPool()
        {
            foreach (Queue<GameObject> queue in poolDictionary.Values)
                foreach (GameObject obj in queue)
                    Despawn(obj);
        }
    }
}