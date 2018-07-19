using UnityEngine;
using System.Collections;

namespace ar4477.A07
{
  // Script modeled after Unity tutorial
  public class Billboard : MonoBehaviour
  {

      void Update()
      {
          transform.LookAt(Camera.main.transform);
      }
  }
}
