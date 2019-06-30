using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class attackClick : MonoBehaviour, IPointerClickHandler
{

  public static bool isFight = false;
  public void OnPointerClick(PointerEventData eventData)
  {
    this.gameObject.GetComponent<Image>().color = new Color((119 / 255f), (136 / 255f), (153 / 255f), 0.5f);
    isFight = true;
  }

  private void Update()
  {
    if (!isFight)
    {
      this.gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
    }
  }
}