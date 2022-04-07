using UnityEngine;

public class PlayerConroller : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void MoveTO(Vector3 targetPos)
    {
        transform.LookAt(targetPos);

        while (transform.position != targetPos)
        {
            transform.position = targetPos ;
        }
        _audioSource.PlayOneShot(_audioSource.clip);
    }
   
}
