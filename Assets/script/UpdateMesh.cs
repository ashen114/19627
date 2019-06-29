using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMesh : MonoBehaviour
{
  private SkinnedMeshRenderer meshRenderer;
  private MeshCollider meshCollider;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    Mesh colliderMesh = new Mesh();
    meshRenderer = transform.GetComponent<SkinnedMeshRenderer>();
    meshCollider = transform.GetComponent<MeshCollider>();
    meshRenderer.BakeMesh(colliderMesh); //更新mesh
    meshCollider.sharedMesh = null;
    meshCollider.sharedMesh = colliderMesh; //将新的mesh赋给meshcollider
  }
}
