using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class attackClick : MonoBehaviour, IPointerClickHandler
{

  public SourceController SourceController;

  public static bool isFight = false;
  public void OnPointerClick(PointerEventData eventData)
  {
    // AudioSource.PlayClipAtPoint(SourceController.player.audioAttackStrength, this.gameObject.transform.position);
    // AudioSource.PlayClipAtPoint(SourceController.audioAttackStrength, transform.position);
    // this.gameObject.GetComponent<AudioSource>().clip = SourceController.audioAttackStrength;
    this.gameObject.GetComponent<AudioSource>().volume = 0.2f;
    this.gameObject.GetComponent<AudioSource>().Play();
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