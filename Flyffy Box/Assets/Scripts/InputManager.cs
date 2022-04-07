using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerConroller _player;
    [SerializeField] private PlatformContener _platformController;

    #region Moving Buttons
    public void MoveForward()
    {
        Vector3 dir = _player.transform.forward;
        Moving(dir);
    }
    public void MoveLeft()
    {
        Vector3 dir = -_player.transform.right;
        Moving(dir);
    } 
    public void MoveRight()
    {
        Vector3 dir = _player.transform.right;
        Moving(dir);
    }
    #endregion

    private void Moving( Vector3 directionMove)
    {
        int X = (int)_player.transform.position.x;
        float Y=_player.transform.position.y;
        int Z = (int)_player.transform.position.z;
        

        int xTarget = (int)directionMove.x + X;
        float yTarget = Y;
        int zTarget = (int)directionMove.z + Z;
        
        if (_platformController.Hasindex(xTarget,zTarget))
        {
            if (_platformController.platformMatrix[xTarget][zTarget].box != null)
            {
            if (MoveBox(X, Y, Z, xTarget, zTarget))
                    _player.MoveTO(new Vector3(xTarget, yTarget, zTarget));
            }
            else
            {
            _player.MoveTO(new Vector3(xTarget, yTarget, zTarget));

            }
        }
    }

    private bool MoveBox(int X, float Y, int Z, int xTarget, int zTarget)
    {
            int nextBoxPositionX = (xTarget - X) + xTarget;
            int nextBoxPositionZ = (zTarget - Z) + zTarget;

            Vector3 TargetBoxPos = new Vector3(nextBoxPositionX, Y, nextBoxPositionZ);

            if (_platformController.Hasindex(nextBoxPositionX, nextBoxPositionZ))
            {
                if (_platformController.platformMatrix[nextBoxPositionX][nextBoxPositionZ].box == null )
                {
                    _platformController.platformMatrix[xTarget][zTarget].box.MoveTO(TargetBoxPos);
                    
                    _platformController.platformMatrix[nextBoxPositionX][nextBoxPositionZ].box = _platformController.platformMatrix[xTarget][zTarget].box;

                    _platformController.platformMatrix[nextBoxPositionX][nextBoxPositionZ].CheckPlatform();

                    _platformController.platformMatrix[xTarget][zTarget].box = null;

                return true;
                }
            }
            
        return false;
    }
}
