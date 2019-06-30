using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class jumpClick : MonoBehaviour, IPointerClickHandler
{

  public static bool isJump = false;
  public void OnPointerClick(PointerEventData eventData)
  {
    Debug.Log("点击跳跃");
    this.gameObject.GetComponent<Image>().color = new Color((119 / 255f), (136 / 255f), (153 / 255f), 0.5f);
    isJump = true;
  }

  private void Update()
  {
    if (!isJump)
    {
      this.gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
    }
  }
}