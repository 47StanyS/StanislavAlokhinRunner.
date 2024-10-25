using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource _musicSourse;
   // [SerializeField] AudioSource _SFXSourse;

    public AudioClip[] _backgroundClips;
    //public AudioClip _jumpSaund;

    private void Start()
    {
        if (_backgroundClips.Length > 0)
        {
            _musicSourse.clip = _backgroundClips[0];
            _musicSourse.Play();
        }

    }
}
