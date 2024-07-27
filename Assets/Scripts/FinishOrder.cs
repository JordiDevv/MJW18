using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class FinishOrder : MonoBehaviour
    {
        [SerializeField] Client client;
        
        void OnButtonClick()
        {
            client.OrderTaken = true;
        }
    }
}