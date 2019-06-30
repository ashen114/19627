using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attckCollison : MonoBehaviour
{
  private Transform scoreObject;
  private TextMesh scoreMesh;

  private string scoreText;
  private float score = 0.0f;

  private void Start()
  {
    scoreObject = GameObject.FindWithTag("score").transform;
    scoreMesh = scoreObject.GetComponent<TextMesh>();
    createOne();
  }

  private void createOne()
  {
    PrimitiveType newObjetctType = new PrimitiveType();
    float typeNum = Mathf.Round(Random.Range(1, 4));
    switch (typeNum)
    {
      case 0:
        newObjetctType = PrimitiveType.Sphere;
        break;
      case 1:
        newObjetctType = PrimitiveType.Capsule;
        break;
      case 2:
        newObjetctType = PrimitiveType.Cylinder;
        break;
      default:
        newObjetctType = PrimitiveType.Cube;
        break;
    }
    GameObject newOne = GameObject.CreatePrimitive(newObjetctType);
    newOne.transform.position = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
    newOne.name = "enemyObject" + scoreHero.score;
    newOne.tag = "enemy";
    newOne.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 0.5f));
    newOne.AddComponent<Rigidbody>();
    // newOne.AddComponent<ParticleSystem>();
  }

  private void OnCollisionEnter(Collision col)  // 碰撞检测
  {
    if (col.gameObject.tag == "enemy")  // 地面的标签(tag) 是 “Ground”
    {
      scoreHero.score = scoreHero.score + 1;
      scoreText = "斩杀BUG数:" + scoreHero.score;
      scoreMesh.text = scoreText;

      col.gameObject.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), (0.1f * Time.deltaTime));
      GameObject.Destroy(col.gameObject, 0.1f);
      createOne();
    }
  }
}