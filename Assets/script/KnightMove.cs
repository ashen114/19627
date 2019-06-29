using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Anim//游戏控制动画
{
  public AnimationClip idle;
  public AnimationClip jump;
  public AnimationClip runForward;
  public AnimationClip runBackward;
  public AnimationClip runRight;
  public AnimationClip runleft;
  // 攻击
  public AnimationClip attackStrength;
  public AnimationClip attackQuick;
  // 防御
  public AnimationClip defend;
  public AnimationClip hit;
}


public class KnightMove : MonoBehaviour
{
  public float h = 0.0f;
  public float v = 0.0f;
  //分配变量,
  private Transform tr;
  //移动速度变量
  public float movespeed = 0.1f;

  // 跳跃速度变量
  public float jumpspeed = 10.0f;
  private bool isJumpFlag = false;
  public float jumpMargin = 1f;
  //旋转可使用Rotate函数，
  public float rotSpeed = 100.0f;
  //要显示到检视视图的动画类变量
  public Anim anim;
  //要访问下列3d模型animation组件对象的变量
  private Animation _animation;

  // Use this for initialization
  void Start()
  {
    //向脚本初始部分分配Tr组件
    tr = GetComponent<Transform>();

    //查找位于自身下级的anim组件并分配到变量。
    _animation = GetComponentInChildren<Animation>();


    _animation.clip = anim.idle;
    _animation.Play();

  }

  private void OnCollisionEnter(Collision col)  // 碰撞检测
  {
    if (col.gameObject.tag == "Ground")  // 地面的标签(tag) 是 “Ground”
    {
      isJumpFlag = false;
    }
  }

  // Update is called once per frame
  void Update()
  {


    h = Input.GetAxis("Horizontal");
    v = Input.GetAxis("Vertical");


    // Debug.Log("H=" + h.ToString());
    // Debug.Log("V=" + v.ToString());

    //计算左右前后的移动方向向量。
    Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);


    //translate（移动方向*time.deltatime*movespeed,space.self）
    tr.Translate(moveDir.normalized * Time.deltaTime * movespeed, Space.Self);


    //vector3.up轴为基准，以rotspeed速度旋转
    tr.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));



    //以键盘输入值为基准，执行要操作的动画

    if (v >= 0.1f)
    {
      //前进动画
      if (isJumpFlag)
      {
        _animation.CrossFade(anim.jump.name, 0.3f);
      }
      else
      {
        _animation.CrossFade(anim.runForward.name, 0.3f);
      }
    }
    else if (v <= -0.1f)
    {
      //back animation
      if (isJumpFlag)
      {
        _animation.CrossFade(anim.jump.name, 0.3f);
      }
      else
      {
        _animation.CrossFade(anim.runBackward.name, 0.3f);
      }
    }
    else if (h >= 0.1f)
    {
      //right animation
      if (isJumpFlag)
      {
        _animation.CrossFade(anim.jump.name, 0.3f);
      }
      else
      {
        _animation.CrossFade(anim.runRight.name, 0.3f);
      }
    }
    else if (h <= -0.1f)
    {
      //left animation 
      if (isJumpFlag)
      {
        _animation.CrossFade(anim.jump.name, 0.3f);
      }
      else
      {
        _animation.CrossFade(anim.runleft.name, 0.3f);
      }
    }
    else
    {
      _animation.CrossFade(anim.idle.name, 0.3f);
    }




    if (Input.GetKey(KeyCode.Space))
    {
      if (!isJumpFlag)
      {
        if (this.gameObject.GetComponent<Rigidbody>() == null)
        {
          this.gameObject.AddComponent<Rigidbody>();
        }
        isJumpFlag = true;
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpspeed * Time.deltaTime, ForceMode.VelocityChange);
      }
    }


    if (Input.GetKey(KeyCode.J) || Input.GetMouseButton(0))
    {
      _animation.CrossFade(anim.attackStrength.name, 0.3f);
    }

    if (Input.GetKey(KeyCode.K))
    {
      _animation.CrossFade(anim.attackQuick.name, 0.3f);
    }

    if (Input.GetKey(KeyCode.L) || Input.GetMouseButton(1))
    {
      _animation.CrossFade(anim.defend.name, 0.3f);
    }

    if (Input.GetKeyDown(KeyCode.H))
    {
      //   _animation[anim.hit.name].speed = 1.5f;
      _animation.Play(anim.hit.name);
      _animation[anim.hit.name].speed = 0f;
    }

    // if (Input.GetKeyUp(KeyCode.H))
    // {
    //   _animation[anim.hit.name].speed = -0.05f;
    //   _animation.Play(anim.hit.name);
    // }

  }
}
