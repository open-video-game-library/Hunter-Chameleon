using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackEye : MonoBehaviour
{
    public GameObject cursorAim;
    void Start()
    {

    }

    void Update()
    {
        var direction = cursorAim.transform.position - this.transform.position;
        var angle = GetAim(Vector3.zero, direction);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, angle + 90);
    }

    float GetAim(Vector2 from, Vector2 to)
    {
        float dx = to.x - from.x;
        float dy = to.y - from.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }
}
