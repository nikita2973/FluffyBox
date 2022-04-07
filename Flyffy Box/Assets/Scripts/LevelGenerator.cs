using UnityEngine;
[RequireComponent(typeof(PlatformContener))]
public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private BoxContainer _boxContainer;

    [SerializeField] private Platform _platform;
    [SerializeField] private Box _box;

    [SerializeField] private Vector2[] _pointForBox;
    [SerializeField] private Vector2[] _pointForBoxInit;

    
    [SerializeField]private PlatformMap _platformMap;

    private  Platform[][] _platformMatrix;
    private  bool[][] _platformCheckerMatrix;


    private void Start()
    {
        if (_platformMap == null)
        {
            _platformMap = GetComponent<PlatformMap>();
        }
        Generation();
    }
    public void Generation()
    {
       CheckComponent();
       
        for (int x = 0; x < _platformMap.columns.Length; x++) {
            _platformMatrix[x] = new Platform[_platformMap.columns[x].rows.Length];
            _platformCheckerMatrix[x] = new bool[_platformMap.columns[x].rows.Length];
            for (int y = 0; y < _platformMap.columns[x].rows.Length; y++)
            {
                _platformCheckerMatrix[x][y] = _platformMap.columns[x].rows[y];
                if (_platformMap.columns[x].rows[y])
                {
                    Platform platform = Instantiate(_platform, transform);
                    platform.transform.position = new Vector3(x, 0, y);
                    platform.name = x + "," + y;
                    _platformMatrix[x][y] = platform;
                    
                        for (int s = 0; s < _pointForBox.Length; s++)
                        {
                        platform.pos = new Vector2Int(x, y);
                            if (_pointForBox[s].x == x && _pointForBox[s].y == y)
                            {
                                platform.SelectPoint();
                               
                            }
                            if (s < _pointForBoxInit.Length)
                            {
                                if (_pointForBoxInit[s].x == x && _pointForBoxInit[s].y == y)
                                {
                                    platform.box = Instantiate(_box, new Vector3(x, 0.3f, y), Quaternion.identity,_boxContainer.transform);
                                _boxContainer.AddBox(platform.box);
                                }
                            }
                        }
                    
                    
                }

            }
        }
        if (Application.isPlaying)
        {
           
            GetComponent<PlatformContener>().GetPlatforms(_platformMatrix,_platformCheckerMatrix);
            _platformMatrix = null;
            _platformCheckerMatrix = null;
            Destroy(_platformMap);
            Destroy(this);
        }

    }

    private void CheckComponent()
    {
        _platformMatrix = null;
        _platformCheckerMatrix = null;
        if (_platformMap.columns.Length > 0)
        {
            _platformMatrix = new Platform[_platformMap.columns.Length][];
            _platformCheckerMatrix = new bool[_platformMap.columns.Length][];
        }

    }

    public void Clear()
    {
        if (_platformMatrix != null)
        {

            for (int x = 0; x < _platformMatrix.Length; x++)
                for (int y = 0; y < _platformMatrix[x].Length; y++)
                {
                    if(_platformMatrix[x][y]!=null)
                        DestroyImmediate(_platformMatrix[x][y].gameObject);
                }
        }
        if (_boxContainer != null)
        {
            _boxContainer.ClearBox();
        }
    }

}
