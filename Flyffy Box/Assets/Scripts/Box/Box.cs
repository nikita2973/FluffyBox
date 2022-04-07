using UnityEngine;

public class Box : MonoBehaviour
{
    private bool _onPlace=false;

    public void BoxStayOnPlace(bool stayOnPlace)
    {
        if (_onPlace != stayOnPlace)
        {
            _onPlace = stayOnPlace;
            transform.parent.GetComponent<BoxContainer>().BoxStayOnPlaceUpdate(_onPlace);
        }
    }

    public void MoveTO(Vector3 targetPosition)
    {
        transform.LookAt(targetPosition);
        if (transform.position != targetPosition)
        {
            transform.position = targetPosition;
        }
    }
}
