using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField]
    public Vector2 direction;
    public int damage;
    int count=0;
    float totaltime=3;
    GameObject ghp;
    void Start()
    {
        damage = 1;
    }

    void Update()
    {

        float moveZ = 0f;
        float moveX = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            moveZ += 0.2f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveZ -= 0.2f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX -= 0.2f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX += 0.2f;
        }
        transform.Translate(new Vector3(moveX, moveZ, 0f) * 0.1f);//움직임 매끄럽게하기 위해 float를 사용

        Debug.DrawRay(transform.position, new Vector3(0,-1, 0) * 3f, new Color(0, 1, 0)); // 레이케스트 그리는 함수
        if (Input.GetMouseButtonDown(0) && count <=0)//좌클릭 하면
        {
            count++;
            
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);//스크린에 있는 마우스 좌표 
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);//그 좌표까지 레이케스트를 쏴서 맞춘다
            ghp = hit.collider.gameObject;
            ghp.GetComponent<Ground>().Damage(damage);

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);
               // Destroy(hit.collider.gameObject);//삭제 함수 나중에 Damage()함수 만들어 넣으면 될듯
            }
        }
        if (totaltime > 1)
        {
            totaltime -= Time.deltaTime;
            Debug.Log(totaltime);
            Debug.Log(count);

            if (totaltime < 1 && count <= 0)
            {
                totaltime = 3;
                count--;
            }
        }
    }
}