using UnityEngine;

//带有一个参数的事件频道
public class OneParameterEventChannel<T> : ScriptableObject
{
    event System.Action<T> Delegate;

    public void BroadCast(T obj)
    {
        Delegate?.Invoke(obj);
    }

    public void AddListener(System.Action<T> action)
    {
        Delegate += action;
    }

    public void RemoveListener(System.Action<T> action)
    {
        Delegate -= action;
    }
}
