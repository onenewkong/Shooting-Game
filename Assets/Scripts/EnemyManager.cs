using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // 최소 시간
    float minTime = 1;
    // 최대 시간
    float maxTime = 5;
    // 현재 시간
    float currentTime;
    // 일정 시간
    public float createTime = 1;
    // 적 공장
    public GameObject enemyFactory;
   
    // Start is called before the first frame update
    void Start()
    {
        // 태어날 때 적의 생성 시간을 설정하고
        createTime = UnityEngine.Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 시간이 흐르다가
        currentTime += Time.deltaTime;
        // 2. 현재 시간이 일정 시간을 초과하면
        if (currentTime > createTime)
        {
            // 3. 적 공장에서 적을 생성해
            GameObject enemy = Instantiate(enemyFactory);
            // 내 위치에 갖다 놓음
            enemy.transform.position = transform.position;
            // 현재 시간을 0으로 초기화
            currentTime = 0;
            // 적을 생성한 후 적의 생성 시간을 다시 설정하고 싶음
            createTime = UnityEngine.Random.Range(minTime, maxTime);
        }
    }
}
