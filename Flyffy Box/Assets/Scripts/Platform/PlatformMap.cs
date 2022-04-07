using UnityEngine;

public class PlatformMap : MonoBehaviour
{
    public static int X, Y;
    public Column[] columns = new Column[X];


}
    [System.Serializable]
    public class Column
    {
        public bool[] rows = new bool[PlatformMap.Y];
    }
