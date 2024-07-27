using UnityEditor.Rendering;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Client", menuName = "Scriptable/Client", order = 0)]
    public class ScriptableClient : ScriptableObject
    {
        public string clientName;
        public string clientDialogue;
        public GameObject clientSprite;
        public AudioSource clientVoice;

        public string[] order;
        public string[] hate;

        bool IsSpeaking { get; set; } = false;
        
        public void SayOrder()
        {
            if (clientVoice != null)
            {
                IsSpeaking = true;
                clientVoice.Play();
                
            }
        }
    }
}