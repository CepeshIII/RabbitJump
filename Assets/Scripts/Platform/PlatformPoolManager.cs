using System.Collections.Generic;
using UnityEngine;

public class PlatformPoolManager : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject smallPlatformPrefab;
    public GameObject bigPlatformPrefab;

    [Header("Settings")]
    public Transform parent;

    private Dictionary<bool, List<CachedObject>> _initializedCachedObjectLists;
    private Queue<CachedObject> activeCachedObjects;


    private void Awake()
    {
        if (parent == null)
            parent = new GameObject("Platforms").transform;

        _initializedCachedObjectLists = new Dictionary<bool, List<CachedObject>>
        {
            { false, new List<CachedObject>() }, // small platforms
            { true, new List<CachedObject>() }   // big platforms
        };

        activeCachedObjects = new Queue<CachedObject>();
    }


    public CachedObject GetPlatform(bool isBig, Vector3 position)
    {
        var pool = _initializedCachedObjectLists[isBig];
        CachedObject platform;

        if (pool.Count > 0)
        {
            platform = pool[^1];
            pool.RemoveAt(pool.Count - 1);

            platform.transform.position = position;
        }
        else
        {
            var prefab = isBig ? bigPlatformPrefab : smallPlatformPrefab;
            var go = Instantiate(prefab, position, Quaternion.identity, parent);
            platform = go.AddComponent<CachedObject>();
        }

        platform.Activate();
        platform.Y = position.y;
        platform.IsBig = isBig;

        activeCachedObjects.Enqueue(platform);
        return platform;
    }


    public void HideBelowY(float y)
    {
        while (activeCachedObjects.Count > 0)
        {
            var platform = activeCachedObjects.Peek();
            if (platform.Y < y)
            {
                HidePlatform(platform);
                _initializedCachedObjectLists[platform.IsBig].Add(platform);
                activeCachedObjects.Dequeue();
            }
            else
            {
                break;
            }
        }
    }


    public void HidePlatform(CachedObject cachedObject)
    {
        cachedObject.Deactivate();
    }

    public void ClearPools()
    {
        foreach (var p in _initializedCachedObjectLists.Values)
        {
            if (p != null)
            {
                foreach(var obj in p)
                {
                    if (obj != null)
                        Destroy(obj.gameObject);
                }

                p.Clear();
            }
        }


        foreach (var p in activeCachedObjects)
        {
            if (p)
            {
                Destroy(p.gameObject);
            }
        }

        activeCachedObjects.Clear();
        _initializedCachedObjectLists.Clear();
    }
}

