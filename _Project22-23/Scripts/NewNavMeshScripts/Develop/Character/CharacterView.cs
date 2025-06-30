using UnityEngine;

namespace _Project22_23.Scripts.NewNavMeshScripts
{
    public class CharacterView: MonoBehaviour
    {
        private readonly int IsRuningKey = Animator.StringToHash("IsRun");
        
        [SerializeField] private Character _character;
        [SerializeField] private Animator _animator;

        private void Update()
        {
            if(_character.IsMoved)
                SetAnimationRun();
            else
                SetAnimationIdle();
        }

        private void SetAnimationRun()
            =>_animator.SetBool(IsRuningKey, true);
        
        private void  SetAnimationIdle()
            =>_animator.SetBool(IsRuningKey, false);
    }
}