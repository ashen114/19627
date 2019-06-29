
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class TargetFollow : MonoBehaviour {
 
    private Transform target; //角色的Transform
    private Vector3 Offset;  //摄像机与角色的相对位置偏移
    private float smoothing = 3; //移动平滑度
	// Use this for initialization
	void Start () {
        //得到角色和偏移
        target = GameObject.FindWithTag("Player").transform;
        Offset = new Vector3(-0.2173055f, 3.476311f, -3.444581f);
	}
	
	/// <summary>
	/// 这里使用LateUpdate可以减少镜头晃动
	/// </summary>
	void LateUpdate () {
        //target.TransformDirection(Offset) 将偏移从局部坐标变为世界坐标,达到摄像机永远在角色背后的目的
        transform.position = Vector3.Lerp(transform.position, target.position + target.TransformDirection(Offset), Time.deltaTime * smoothing);
        //摄像机朝向角色
        transform.LookAt(target);
	}
}