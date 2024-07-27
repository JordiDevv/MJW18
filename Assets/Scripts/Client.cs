using System.Collections;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class Client : MonoBehaviour
    {
        public ScriptableObjects.ScriptableClient client;
        [SerializeField] TMPro.TextMeshProUGUI dialogueText;

        int scoreService = 100;
        readonly Vector3 orderPoint = Vector3.zero;
        bool speaking;


        void Awake()
        {
            dialogueText = FindObjectOfType<TMPro.TextMeshProUGUI>().name == "DialogueText"
                ? FindObjectOfType<TMPro.TextMeshProUGUI>()
                : null;
        }

        void Start()
        {
            StartCoroutine(MoveTo(orderPoint));
        }

        IEnumerator MoveTo(Vector3 where)
        {
            while (transform.position != where)
            {
                transform.position = Vector3.MoveTowards(transform.position, where, 0.3f);
                yield return new WaitForSeconds(0.1f);
            }
        }

        void Update()
        {
            if (client && transform.position == orderPoint)
            {
                if (dialogueText)
                {
                    client.SayOrder();
                    if (!speaking)
                        ShowDialog();
                }

                WaitUntilOrder();

                if (OrderTaken)
                    Satisfy("agua");
            }
        }

        void WaitUntilOrder()
        {
            if (dialogueText.text == client.clientDialogue)
            {
                OrderTaken = true;
                speaking = false;
            }
        }

        void Satisfy(string order)
        {
            foreach (var item in client.hate.Where(item => item.Contains(order)))
            {
                scoreService -= 10;
            }

            StartCoroutine(MoveTo(where: new Vector3(500, 0, 0)));
        }

        bool OrderTaken { get; set; }

        void ShowDialog()
        {
            speaking = true;
            StartCoroutine(dialogueText.GetComponent<ClientText>().TypeText(client.clientDialogue));
        }
    }
}