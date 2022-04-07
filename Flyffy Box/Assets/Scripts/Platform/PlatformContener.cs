using System;
using UnityEngine;
public class PlatformContener : MonoBehaviour {
    private Platform[][] _platformMatrix;
    public Platform[][] platformMatrix=>_platformMatrix;

    private bool[][] _platformCheckerMatrix;

    public void GetPlatforms(Platform[][] PlatformMatrix,bool[][] platformCheckerMatrix )
    {
        _platformMatrix = PlatformMatrix;
        _platformCheckerMatrix = platformCheckerMatrix;
    }

    public bool Hasindex(int x, int y)
    {
        try
        {
            if (_platformCheckerMatrix.Length > x && _platformCheckerMatrix[x].Length > y)
                return _platformCheckerMatrix[x][y];
            else
                return false;
        }
        catch
        {
            return false;
        }
    }
}
