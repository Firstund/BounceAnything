using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoolManager : MonoBehaviour
{
    private static PoolManager instance;
    public static PoolManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PoolManager>();

                if (instance == null)
                {
                    GameObject temp = new GameObject("PoolManager");
                    instance = temp.AddComponent<PoolManager>();
                }
            }

            return instance;
        }
    }

    [SerializeField]
    private Queue<GameObject> textObjQueue = new Queue<GameObject>();
    public Queue<GameObject> TextObjQueue
    {
        get { return textObjQueue; }
        set { textObjQueue = value; }
    }
    [SerializeField]
    private Queue<AfterImage> afterImages = new Queue<AfterImage>();
    public Queue<AfterImage> AfterImages
    {
        get { return afterImages; }
        set { afterImages = value; }
    }
}
