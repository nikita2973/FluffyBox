using System.Threading.Tasks;
using UnityEngine;
public class Platform : MonoBehaviour
{
    [SerializeField] private Material _materialForBoxPlants;
    public Box box;
    public bool isPlatformForBox;
    public Vector2Int pos;

    private Vector3 _startScale;
    
    private void Start()
    {
        _startScale = transform.localScale;
        transform.localScale = new Vector3(0, 0, 0);
        OpenPanel();
    }
    
    private async void OpenPanel()
    {
        while (transform.localScale.x <= _startScale.x)
        {
            await Task.Delay(15);
            transform.localScale = new Vector3(transform.localScale.x + 0.05f, _startScale.y, transform.localScale.z + 0.05f);
        }
    }
    public void CheckPlatform()
    {
      
            box.BoxStayOnPlace(isPlatformForBox);
        
    }

   public void SelectPoint()
    {
        isPlatformForBox = true;
        
            gameObject.GetComponent<MeshRenderer>().material = _materialForBoxPlants;
        
    }

}
