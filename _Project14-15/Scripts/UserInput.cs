using UnityEngine;

namespace _Project14_15.Scripts
{
    [RequireComponent(typeof(Character))]
    
    public class UserInput : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";
        
        [SerializeField] private Character _character;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
                _character.TryUseItem();
            
            float moveX = Input.GetAxisRaw(HorizontalAxis);
            float moveZ = Input.GetAxisRaw(VerticalAxis);
            Vector3 direction = new Vector3(moveX, 0, moveZ).normalized;

            if (direction != Vector3.zero)
                _character.Move(direction);
        }
    }
}