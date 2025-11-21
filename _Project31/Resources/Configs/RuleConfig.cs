using UnityEngine;

namespace _Project31.Scripts
{
    [CreateAssetMenu(fileName = "RuleConfig", menuName = "Config/RuleConfig")]
    public class RuleConfig : ScriptableObject
    {
        [field: SerializeField] public TypeWin TypeWin { get; private set; }
        [field: SerializeField] public TypeDefeat TypeDefeat { get; private set; }

        public void SetRandomTypes()
        {
            TypeWin = (TypeWin)Random.Range(0, System.Enum.GetValues(typeof(TypeWin)).Length);
            TypeDefeat = (TypeDefeat)Random.Range(0, System.Enum.GetValues(typeof(TypeDefeat)).Length);
        }
    }
}