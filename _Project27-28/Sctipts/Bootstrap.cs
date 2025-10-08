using UnityEngine;
using UnityEngine.Serialization;

namespace _Project27_28.Scripts
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Storage _storage;
        [FormerlySerializedAs("_coinsUpdater")] [SerializeField] private CoinsView coinsView;
        private void Awake()
        {
            _storage.Initialize(new Wallet());
            coinsView.OnChanged();
        }
    }
}