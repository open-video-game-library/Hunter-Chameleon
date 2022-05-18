using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JudgmentText : MonoBehaviour
{
    SpriteRenderer _renderer;
    const int SPR_GREAT = 0;
    const int SPR_NICE = 1;

    [SerializeField]
    public Sprite[] SPR_LIST;

    float alfa;
    float timeCount;

    void Start()
    {
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        _renderer = GetComponent<SpriteRenderer>();
        var color = _renderer.color;
        color.a = alfa;
        _renderer.color = color;
        if (timeCount <= 0.5f) alfa += 0.2f;
        else if (timeCount >= 1.5f) alfa -= 0.2f;
    }

    public void Init(float _hitDis, Vector3 _hitPos)
    {
        alfa = 0;
        _renderer = GetComponent<SpriteRenderer>();
        transform.localPosition = _hitPos;
        // Debug.Log("_hitDis: " + _hitDis);
        if (_hitDis >= 2.0f && _hitDis < 4.0f) _renderer.sprite = SPR_LIST[SPR_GREAT];
        else if (_hitDis >= 4.0f) _renderer.sprite = SPR_LIST[SPR_NICE];
    }
}
