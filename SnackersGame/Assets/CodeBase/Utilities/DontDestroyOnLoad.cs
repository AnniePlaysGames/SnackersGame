using UnityEngine;

namespace CodeBase.Utilities
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void OnEnable() 
            => DontDestroyOnLoad(gameObject);
    }
}
