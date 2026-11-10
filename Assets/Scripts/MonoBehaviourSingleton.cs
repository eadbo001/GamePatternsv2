using UnityEngine;

public abstract class MonoBehaviourSingleton<T> : MonoBehaviour
                        where T : MonoBehaviourSingleton<T> //generic constraint
{
    public static T Instance {get; private set;} 

    protected virtual void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this as T;
        DontDestroyOnLoad(gameObject);
    }
}
