using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoxContainer : MonoBehaviour
{
    private List<Box> _boxes;
    private int _countBoxOnPlace;
    [SerializeField] private UnityEvent _openCompleteMenu;
    public void AddBox(Box box)
    {
        if (_boxes == null)
        {

            _boxes = new List<Box>();

        }
        _boxes.Add(box);
        box.name = $"box [{box.transform.position.x}] [{box.transform.position.z}]";
    }

    public void BoxStayOnPlaceUpdate(bool stay)
    {
        if (stay)
            _countBoxOnPlace++;
        else
            _countBoxOnPlace--;

        CheckCountBoxOnPlace();
    }

    private void CheckCountBoxOnPlace()
    {
        if (_countBoxOnPlace == _boxes.Count)
        {
            _openCompleteMenu.Invoke();
            Debug.Log("GameOver");
        }
    }

    public void ClearBox()
    {
        Box[] boxes = GetComponentsInChildren<Box>();
        foreach (Box box in boxes)
        {
            DestroyImmediate(box.gameObject);
        }
    }
}
