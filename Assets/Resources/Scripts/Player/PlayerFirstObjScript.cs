using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFirstObjScript : MonoBehaviour
{
    private GameManager gameManager = null;
    private SphereCollider myCol = null;
    public SphereCollider MyCol
    {
        get { return myCol; }
    }
    [Header("플레이어의 처음 사이즈")]
    [SerializeField]
    private float playerOriginSize = 0f;
    private float playerTotalSize = 0f;
    public float PlayerTotalSize
    {
        get { return playerTotalSize; }
        set
        {
            playerTotalSize = value;
            gameManager.Score = playerTotalSize * 100f;
        }
    }
    private float plusTotalSize = 0f;
    public float PlusPlayerTotalSize
    {
        get { return plusTotalSize; }
        set { plusTotalSize = value; }
    }
    void Start()
    {
        gameManager = GameManager.Instance;

        myCol = GetComponent<SphereCollider>();

        playerTotalSize = playerOriginSize;
        // playerTotalSize = myCol.bounds.extents.x * myCol.bounds.extents.y * myCol.bounds.extents.z; 
        //// 모양에 따라 알맞는 크기를 구하기 힘들다고 판단, 크기를 구하는 식을 하나로 통일한다.
        gameManager.PlayerFirstObjScript = this;
    }

    void FixedUpdate()
    {
        // SetPlayerTotalSize();
    }
    private void OnCollisionEnter(Collision other) // 붙을 수 있는 오브젝트와 충돌했을 때
    {
        GlueableObj glueableObj = other.transform.GetComponent<GlueableObj>();

        if (glueableObj != null && !glueableObj.socreUp)
        {
            if (playerTotalSize >= glueableObj.Size)
            {
                Debug.Log("p" + playerTotalSize);
                Debug.Log("t" + glueableObj.Size);

                glueableObj.gameObject.AddComponent<GlueToPlayerFirstObj>();

                glueableObj.socreUp = true;
            }
        }
    }
    // OnCollisionStay 처리
    private void SetPlayerTotalSize() // 나도 내가 왜넣었는지 기억 안남, 일단 남겨둠
    {
        if (plusTotalSize > 0f)
        {
            playerTotalSize += Time.fixedDeltaTime;
            playerTotalSize -= Time.fixedDeltaTime;

            if (plusTotalSize < 0f)
            {
                playerTotalSize -= plusTotalSize;
                plusTotalSize = 0f;
            }
        }
        else
        {
            plusTotalSize = 0f;
        }
    }
}
