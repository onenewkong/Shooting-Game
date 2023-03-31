using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 필요 속성: 이동 속도
    public float speed = 5;
    
    GameObject player;

    // 방향을 전역 변수로 만들어 Start와 Update에서 사용
    Vector3 dir;

    public GameObject explosionFactory;

    // Start is called before the first frame update
    void Start()
    {
        // Vector3 dir;
        // 0부터 9까지 10개의 값 중에 하나를 랜덤으로 가져옴
        int randValue = UnityEngine.Random.Range(0, 10);
        // 만약 3보다 작으면 플레이어 방향
        if(randValue < 3)
        {
            // 플레이어를 찾아 target으로
            GameObject target = GameObject.Find("Player");
            // 방향 구함 target - me
            dir = target.transform.position - transform.position;
            // 방향 크기를 1로
            dir.Normalize();
        }
        // 그렇지 않으면 아래 방향으로 정함
        else
        {
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 방향을 구함
        // Vector3 dir = Vector3.down;

        // 2. 이동 공식 P = P0 + vt
        transform.position += dir * speed * Time.deltaTime;
    }

 
    private void OnCollisionEnter(Collision collision)
    {
        GameObject explosion = Instantiate(explosionFactory);

        explosion.transform.position = transform.position;

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
