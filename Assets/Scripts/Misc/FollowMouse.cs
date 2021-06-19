using UnityEngine;
using NaughtyAttributes;


public class FollowMouse : MonoBehaviour
{
    public Transform proj = null;
    [Range(-1f, 1f)] public float launchPointOffset = 0f;
    [ReadOnly] public float angle = 0f;


    void Start()
    {
        proj.localPosition = new Vector3(launchPointOffset, 0f, 0f);
    }

    void Update()
    {
        Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        // if (angle > 90 || angle < -90)
        // {
        //     // angle += 180f;
        //     proj.localPosition = new Vector3(launchPointOffset, 0f, 0f);
        // }
        // else
        // {
        //     proj.localPosition = new Vector3(launchPointOffset, 0f, 0f);
        // }

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}