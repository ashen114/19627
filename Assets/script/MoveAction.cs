using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MoveAction : MonoBehaviour
{
  public int speed = 2;
  Vector3 targetObject;
  // Start is called before the first frame update
  void Start()
  {
    string startTitle = "the game is beging";
    print("start:" + startTitle);

    targetObject = new Vector3(0, 0, 0);
  }

  // Update is called once per frame
  void Update()
  {
    // 持续更新     
    if (Input.GetKey(KeyCode.M))
    {
      MoveToTargetPosition(targetObject, 3);
    }

    MoveWithRigid();
  }

  private void OnDestroy()
  {
    print("destroy");
  }

  /// <summary> 函数作用解析：使用物体力移动物体
  /// <param name="x">speed</param>
  /// </summary>
  public void MoveWithRigid(float speed = 2)
  {
    float moveSpeed = speed * Time.deltaTime;

    // 前
    if (Input.GetKey(KeyCode.W))
    {
      if (this.gameObject.GetComponent<Rigidbody>() == null)
      {
        this.gameObject.AddComponent<Rigidbody>();
      }
      this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * moveSpeed, ForceMode.Impulse);
    }

    // 后
    if (Input.GetKey(KeyCode.S))
    {
      if (this.gameObject.GetComponent<Rigidbody>() == null)
      {
        this.gameObject.AddComponent<Rigidbody>();
      }
      this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * moveSpeed, ForceMode.Impulse);
    }
    // 左
    if (Input.GetKey(KeyCode.A))
    {
      if (this.gameObject.GetComponent<Rigidbody>() == null)
      {
        this.gameObject.AddComponent<Rigidbody>();
      }
      this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * moveSpeed, ForceMode.Impulse);
    }
    // 右
    if (Input.GetKey(KeyCode.D))
    {
      if (this.gameObject.GetComponent<Rigidbody>() == null)
      {
        this.gameObject.AddComponent<Rigidbody>();
      }
      this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * moveSpeed, ForceMode.Impulse);
    }
    // 上
    if (Input.GetKey(KeyCode.Q))
    {
      if (this.gameObject.GetComponent<Rigidbody>() == null)
      {
        this.gameObject.AddComponent<Rigidbody>();
      }
      this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * moveSpeed * 10, ForceMode.VelocityChange);
    }
  }



  /// <summary> 处理物体移动
  /// <param name="targetPos">目标位置</param>
  /// <param name="moveMethod">移动方式</param>
  /// <param name="speed">速度</param>
  /// </summary>
  public void MoveToTargetPosition(Vector3 targetPos, int moveMethod = 0, float speed = 2)
  {
    float moveSpeed = speed * Time.deltaTime;
    if (targetPos != null && speed > 0)
    {
      switch (moveMethod)
      {
        case 0:
          this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, targetPos, moveSpeed);
          break;
        case 1:
          this.transform.localPosition = new Vector3(Mathf.Lerp(this.transform.localPosition.x, targetPos.x, moveSpeed), Mathf.Lerp(this.transform.localPosition.y, targetPos.y, moveSpeed), Mathf.Lerp(this.transform.localPosition.z, targetPos.z, moveSpeed));
          break;
        case 2:
          this.transform.Translate(Vector3.forward * moveSpeed);
          this.transform.Translate(Vector3.right * moveSpeed);
          break;
        case 3:
          if (this.gameObject.GetComponent<Rigidbody>() == null)
          {
            this.gameObject.AddComponent<Rigidbody>();
          }
          this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * moveSpeed, ForceMode.Impulse);
          break;
        default:
          this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, targetPos, moveSpeed);
          break;
      }
    }

  }
}

