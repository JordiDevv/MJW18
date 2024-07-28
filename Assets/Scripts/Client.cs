using System.Collections;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class Client : MonoBehaviour
    {
        public ScriptableObjects.ScriptableClient client;
        [SerializeField] TMPro.TextMeshProUGUI dialogueText;
        [SerializeField] TMPro.TextMeshProUGUI nameText;
        [SerializeField] GameObject displayTextPanel;

        readonly Vector3 orderPoint = Vector3.zero;
        bool speaking;

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
                    displayTextPanel.gameObject.SetActive(true);

                    if (!speaking)
                        ShowDialog();
                }

                WaitUntilOrder();
            }
        }

        void WaitUntilOrder()
        {
            if (GameManager.Instance.OrderTaken)
            {
                GameManager.Instance.OrderTaken = false;
                speaking = false;
                StartCoroutine(MoveTo(where: new Vector3(500, 0, 0)));
                GameManager.Instance.Satisfy(client.hate);
                Destroy(gameObject, 5f);
            }
        }



        void ShowDialog()
        {
            speaking = true;
            nameText.text = client.clientName;
            StartCoroutine(dialogueText.GetComponent<ClientText>().TypeText(client.clientDialogue));
        }
    }
}