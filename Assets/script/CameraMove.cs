using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
  /// 镜头偏移量
  private Vector3 offset;
  // 跟随对象
  public Transform player;

  private float sensitivityMouse = 2f;
  private float sensitivetyKeyBoard = 0.1f;
  private float sensitivetyMouseWheel = 10f;
  private void Start()
  {
    offset = player.position - transform.position;
  }

  private void Update()
  {
    transform.position = Vector3.Lerp(transform.position, player.position - offset, Time.deltaTime * 5);
    Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 3f);

    // 增加鼠标控件

    //按着鼠标右键实现视角转动
    if (Input.GetMouseButton(1))
    {
      transform.Rotate(-Input.GetAxis("Mouse Y") * sensitivityMouse, Input.GetAxis("Mouse X") * sensitivityMouse, 0);
    }

  }

}
