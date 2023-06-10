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
        transform.Translate(new Vector3(moveX, moveZ, 0f) * 0.1f);//������ �Ų������ϱ� ���� float�� ���

        Debug.DrawRay(transform.position, new Vector3(0,-1, 0) * 3f, new Color(0, 1, 0)); // �����ɽ�Ʈ �׸��� �Լ�
        if (Input.GetMouseButtonDown(0) && count <=0)//��Ŭ�� �ϸ�
        {
            count++;
            
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);//��ũ���� �ִ� ���콺 ��ǥ 
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);//�� ��ǥ���� �����ɽ�Ʈ�� ���� �����
            ghp = hit.collider.gameObject;
            ghp.GetComponent<Ground>().Damage(damage);

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);
               // Destroy(hit.collider.gameObject);//���� �Լ� ���߿� Damage()�Լ� ����� ������ �ɵ�
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