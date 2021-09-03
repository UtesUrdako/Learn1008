using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverbTrigger : MonoBehaviour
{
    private AudioReverbZone _reverbZone;

    // Start is called before the first frame update
    void Awake()
    {
        _reverbZone = GetComponent<AudioReverbZone>();
        _reverbZone.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _reverbZone.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _reverbZone.enabled = false;
        }
    }
}
