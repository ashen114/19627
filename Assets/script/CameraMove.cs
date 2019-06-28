using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
  /// 摄像机对于跟随对象的偏移量
  private Vector3 offset;
  // 跟随对象-改用private，采用查找标签的方式寻找跟随对象
  public Transform player;

  // 距离
  private float distance;

  // 5个点作为摄像机可选位置
  private Vector3[] points = new Vector3[5];

  // 筛选后的摄像机位置
  private Vector3 targetPos;

  private void Awake()
  {
    // player = GameObject.FindWithTag("Player").transform;
    offset = transform.position - player.position;
    distance = offset.magnitude;
  }

  private void FixedUpdate()
  {
    // 更新5个点的位置
    points[0] = player.position + offset;
    points[4] = player.position + Vector3.up * distance;

    points[1] = Vector3.Lerp(points[0], points[4], 0.25f);
    points[2] = Vector3.Lerp(points[0], points[4], 0.5f);
    points[3] = Vector3.Lerp(points[0], points[4], 0.75f);
    points[4] = Vector3.Lerp(points[0], points[4], 0.9f);

    targetPos = FindCameraTarget();

    AdjustCamera();
  }

  private Vector3 FindCameraTarget()
  {
    // 头顶位置
    Vector3 result = points[points.Length - 1];

    // 从低到高遍历
    for (int i = 0; i < points.Length; ++i)
    {
      // 如果挡住了player
      if (IsHitPlayer(points[i], player.position))
      {
        result = points[i];
        break;
      }
    }
    return result;
  }

  private Ray ray;
  private RaycastHit hit;
  /// <summary> 检查跟随对象是否被物体遮挡
  /// 从origin发射射线检测是否触碰到跟随对象
  /// 碰到则摄像机位置在此可看到跟随对象
  /// </summary>
  /// <param name="origin">发射源</param>
  /// <param name="target">目标对象</param>
  /// <returns></returns>
  bool IsHitPlayer(Vector3 origin, Vector3 target)
  {
    bool result = false;

    Vector3 dir = target - origin;
    ray = new Ray(origin, dir);
    if (Physics.Raycast(ray, out hit))
    {
      if (hit.transform.tag == "Player")
      {
        result = true;
      }
    }
    return result;
  }

  /// <summary> 调整摄像机位置
  /// </summary>
  private void AdjustCamera()
  {
    transform.position = Vector3.Slerp(transform.position, targetPos, Time.deltaTime * 6);

    Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 33f);
  }

}