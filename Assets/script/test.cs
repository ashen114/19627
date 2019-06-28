using UnityEngine;
using System.Collections;

public class CamFollow1 : MonoBehaviour
{

  private Vector3 offset;
  public Transform player;

  void Start()
  {
    offset = player.position - transform.position;
  }

  void Update()
  {
    transform.position = Vector3.Lerp(transform.position, player.position - offset, Time.deltaTime * 5);
    // 增加注视效果
    Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 3f);

  }
}