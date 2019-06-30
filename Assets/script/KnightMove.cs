using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Anim//游戏控制动画
{
  public AnimationClip idle;
  public AnimationClip jump;
  public AnimationClip runForward;
  public AnimationClip walkForward;
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


  public SimpleTouchController leftController;
  public SimpleTouchController rightController;

  public float h = 0.0f;
  public float v = 0.0f;
  //分配变量,
  private Transform tr;
  //移动速度变量
  public float movespeed = 0.1f;

  // 跳跃速度变量
  public float jumpspeed = 150.0f;
  private bool isJumpFlag = false;
  public float jumpMargin = 1f;

  public AudioClip AudioPlayerJump;
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


    // this.gameObject.GetComponent<AudioSource>().clip = anim.audioAttackStrength;

  }

  private void OnCollisionEnter(Collision col)  // 碰撞检测
  {
    if (col.gameObject.tag == "Ground")  // 地面的标签(tag) 是 “Ground”
    {
      isJumpFlag = false;
    }
  }

  private void stopFight()
  {
    attackClick.isFight = false;
    // Debug.Log("打完了");
  }

  // Update is called once per frame
  void Update()
  {


    // h = Input.GetAxis("Horizontal");
    h = leftController.GetTouchPosition.x;
    // v = Input.GetAxis("Vertical");
    v = leftController.GetTouchPosition.y;


    // Debug.Log("H=" + h.ToString());
    // Debug.Log("V=" + v.ToString());

    //计算左右前后的移动方向向量。
    Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);


    //translate（移动方向*time.deltatime*movespeed,space.self）
    tr.Translate(moveDir.normalized * Time.deltaTime * movespeed, Space.Self);


    //vector3.up轴为基准，以rotspeed速度旋转
    // tr.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));
    tr.Rotate(Vector3.up * Time.deltaTime * rotSpeed * leftController.GetTouchPosition.x);



    //以键盘输入值为基准，执行要操作的动画

    // if (v >= 0.1f)
    if (v > 0f)
    {
      //前进动画
      if (isJumpFlag)
      {
        _animation.CrossFade(anim.jump.name, 0.3f);
      }
      else
      {
        if (v > 0.5f)
        {
          _animation.CrossFade(anim.runForward.name, 0.3f);
        }
        else
        {
          _animation.CrossFade(anim.walkForward.name, 0.3f);
        }
      }
    }
    // else if (v <= -0.1f)
    else if (v < 0f)
    {
      //back animation
      if (isJumpFlag)
      {
        _animation.CrossFade(anim.jump.name, 0.3f);
      }
      else
      {
        if (v > -0.5f)
        {
          _animation.CrossFade(anim.runBackward.name, 0.3f);

        }
        else
        {
          _animation.CrossFade(anim.walkForward.name, 0.3f);
        }
      }
    }
    // else if (h >= 0.1f)
    else if (h > 0f)
    {
      //right animation
      if (isJumpFlag)
      {
        _animation.CrossFade(anim.jump.name, 0.3f);
      }
      else
      {
        if (h > 0.5f)
        {
          _animation.CrossFade(anim.runRight.name, 0.3f);
        }
        else
        {
          _animation.CrossFade(anim.walkForward.name, 0.3f);
        }
      }
    }
    // else if (h <= -0.1f)
    else if (h < 0f)
    {
      //left animation 
      if (isJumpFlag)
      {
        _animation.CrossFade(anim.jump.name, 0.3f);
      }
      else
      {
        if (h > -0.5f)
        {
          _animation.CrossFade(anim.runleft.name, 0.3f);
        }
        else
        {
          _animation.CrossFade(anim.walkForward.name, 0.3f);
        }
      }
    }
    else
    {
      _animation.CrossFade(anim.idle.name, 0.3f);
    }

    // if (Input.GetKey(KeyCode.Space))
    if (jumpClick.isJump)
    {
      if (!isJumpFlag)
      {
        // if (this.gameObject.GetComponent<Rigidbody>() == null)
        // {
        //   this.gameObject.AddComponent<Rigidbody>();
        // }
        isJumpFlag = true;
        jumpClick.isJump = false;
        // this.gameObject.GetComponent<AudioSource>().clip = AudioPlayerJump;
        // this.gameObject.GetComponent<AudioSource>().volume = 0.2f;
        // this.gameObject.GetComponent<AudioSource>().Play();
        AudioSource.PlayClipAtPoint(AudioPlayerJump, transform.position);
        // tr.Translate(Vector3.up * jumpspeed * Time.deltaTime);
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpspeed * Time.deltaTime, ForceMode.VelocityChange);
      }
    }


    // if (Input.GetKey(KeyCode.J) || Input.GetMouseButton(0))
    // if (Input.GetKey(KeyCode.J))
    if (attackClick.isFight)
    {
      _animation.Play(anim.attackStrength.name);
      Invoke("stopFight", 0.3f);
      // _animation.CrossFade(anim.attackStrength.name, 0.3f);
    }

    if (Input.GetKey(KeyCode.K))
    {
      _animation.CrossFade(anim.attackQuick.name, 0.3f);
    }

    // if (Input.GetKey(KeyCode.L) || Input.GetMouseButton(1))
    if (Input.GetKey(KeyCode.L))
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
