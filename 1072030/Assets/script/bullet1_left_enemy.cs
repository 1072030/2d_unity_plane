using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet1_left_enemy : MonoBehaviour
{
    public GameObject Bullet_enemy; //長條子彈
    public GameObject explo;
    Vector2 _target = new Vector2(-2.5f, 2f);
    Vector2 _final = new Vector2(10f, -20f);
    float _moveTime = 5;
    float _timeCount = 0;
    bool change = true;
    // Start is called before the first frame update
    void Start()
    {
        Bullet_enemy.transform.Rotate(new Vector3(0, 0, 45));
    }

    // Update is called once per frame
    void Update()
    {
        _timeCount += Time.deltaTime;
        if (change == true)
        {
            this.transform.position = Vector2.Lerp(_target, _final, _timeCount / _moveTime);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ship")
        {
            Destroy(col.gameObject);//敵人子彈 打到飛船
            Destroy(gameObject);
            Instantiate(explo, col.gameObject.transform.position, col.gameObject.transform.rotation);//自己產生爆炸
            GameFunction.Instance.GameOver();//顯示結束
        }
    }
}
