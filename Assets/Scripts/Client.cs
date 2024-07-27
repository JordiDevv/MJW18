using System.Collections;
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

        void Start()
        {
            StartCoroutine(MoveTo(orderPoint));
        }

        IEnumerator MoveTo(Vector3 counter)
        {
            while (transform.position != counter)
            {
                transform.position = Vector3.MoveTowards(transform.position, counter, 0.3f);
                yield return new WaitForSeconds(0.1f);
            }
        }

        void Update()
        {
            if (client != null && transform.position == orderPoint)
            {
                if (dialogueText != null)
                {
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