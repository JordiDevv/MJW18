using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Client", menuName = "Scriptable/Client", order = 0)]
    public class ScriptableClient : ScriptableObject
    {
        public string clientName;
        public string clientDialogue;
     
        public List<string> hate;

        bool IsSpeaking { get; set; } = false;
    }
}