using UnityEngine;

namespace CodeBase.Coins
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;
        
        private void Update()
        {
            transform.Rotate(0, 0, _rotationSpeed * Time.deltaTime);
        }
    }
}