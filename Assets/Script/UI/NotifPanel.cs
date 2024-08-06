using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TestBR.UI
{
    public class NotifPanel : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI texMesh;


        public void SetText(string text)
        {
            texMesh.text = text;
        }
    }
}
