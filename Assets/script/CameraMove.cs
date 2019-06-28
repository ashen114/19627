using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
  /// 镜头偏移量
  private Vector3 offset;
  // 跟随对象
  public Transform player;
  private void Start()
  {
    offset = player.position - transform.position;
  }

  private void Update()
  {
    transform.position = Vector3.Lerp(transform.position, player.position - offset, Time.deltaTime * 5);
    Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 3f);
  }
}
