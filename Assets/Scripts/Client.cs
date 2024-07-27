using System;
using UnityEditor.Tilemaps;
using UnityEngine;

namespace DefaultNamespace
{
    public class Client : MonoBehaviour
    {
        public ScriptableObjects.ScriptableClient client;
        [SerializeField] TMPro.TextMeshProUGUI dialogueText;

        int scoreService;
        readonly Vector3 orderPoint = Vector3.zero;
        bool asdf;


        void Awake()
        {
            dialogueText = FindObjectOfType<TMPro.TextMeshProUGUI>().name == "DialogueText"
                ? FindObjectOfType<TMPro.TextMeshProUGUI>()
                : null;
            Debug.Log(dialogueText.name);
        }

        void Update()
        {
            if (client != null && transform.position == orderPoint)
            {
                if (dialogueText != null)
                {
                    Debug.Log("asdf");
                    client.SayOrder();
                    if (!asdf)
                        ShowDialog();
                }
            }

            // if (OrderTaken)
            //     Satisfy("agua");
        }

        void ShowDialog()
        {
                asdf = true;
                StartCoroutine(dialogueText.GetComponent<ClientText>().TypeText(client.clientDialogue));
        }
        // if (order.Contains(client.hate[0]))
        // {
        //     Debug.Log("contiene agua");
        //     scoreService -= 10;
        // }
    }
}