using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Prefab;
    public GameObject Parent;
    private GameObject CurrentClone;
    private static Loader sInstance;
    private static readonly object _syncRoot = new object();
    private void Awake()
    {
        sInstance = this;
    }
    public static Loader GetInstance()
    {
        return sInstance;
    }
    private void Init()
    {
        CurrentClone = Instantiate(Prefab, new Vector3(0, 0, 0), Quaternion.identity, Parent.transform);
        CurrentClone.transform.parent = Parent.transform;
        CurrentClone.transform.localPosition = Vector3.zero;
    }
    public void Show()
    {
        Debug.Log("show");
        Init();
    }
    public void Hide()
    {
        DestroyImmediate(CurrentClone);
    }
}
