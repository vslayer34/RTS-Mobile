using UnityEngine;

public class FlagPoint : MonoBehaviour
{
    [SerializeField]
    private bool _flagPlaced;

    [SerializeField]
    private SpriteRenderer _spriterender;



    // Game Loop Methods---------------------------------------------------------------------------

    private void OnEnable()
    {
        
    }

    // Member Methods------------------------------------------------------------------------------

    // Signal Methods------------------------------------------------------------------------------

    public void GettingFlagReadyToBePlaced()
    {
        _spriterender.enabled = false;

    }

    public void PutTheFlagDown(Vector3 newPosition)
    {
        transform.position = newPosition;
        _spriterender.enabled = true;
    }
}
