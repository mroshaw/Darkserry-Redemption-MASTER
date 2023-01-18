using UnityEngine;

namespace DaftAppleGames.Common.Characters
{

    public class EyeSync : MonoBehaviour
    {
        [Header("Blendshapes Config")]
        public SkinnedMeshRenderer blendShapesSource;
        public string lookLeftBlendshape;
        public string lookRightBlendshape;
        public string lookUpBlendshape;
        public string lookDownBlendshape;

        private int leftBlendShapeIndex;
        private int rightBlendShapeIndex;
        private int upBlendShapeIndex;
        private int downBlendShapeIndex;

        private Vector3 _lookDir;
        private float _lookLeftRight;
        private float _lookUpDown;

        private void Start()
        {
            leftBlendShapeIndex = blendShapesSource.sharedMesh.GetBlendShapeIndex(lookLeftBlendshape);
            rightBlendShapeIndex = blendShapesSource.sharedMesh.GetBlendShapeIndex(lookRightBlendshape);
            upBlendShapeIndex = blendShapesSource.sharedMesh.GetBlendShapeIndex(lookUpBlendshape);
            downBlendShapeIndex = blendShapesSource.sharedMesh.GetBlendShapeIndex(lookDownBlendshape);

            Debug.Log($"{leftBlendShapeIndex}, {rightBlendShapeIndex}, {upBlendShapeIndex}, {downBlendShapeIndex}");
        }

        void Update()
        {
            // Move world look rotation to local rotation
            Quaternion localLookRot = Quaternion.Inverse(transform.rotation); // * Quaternion.Euler(EyesAnim.DeltaVectorClamped);

            // Define look vector
            _lookDir = localLookRot * Vector3.forward;

            _lookLeftRight = _lookDir.x;
            _lookUpDown = _lookDir.y;

            // Blendshapes
            if(_lookLeftRight == 0)
            {
                blendShapesSource.SetBlendShapeWeight(leftBlendShapeIndex, 0);
                blendShapesSource.SetBlendShapeWeight(rightBlendShapeIndex, 0);
            }
            else if(_lookLeftRight > 0)
            {

            }
            else
            {

            }

            if (_lookUpDown == 0)
            {
                blendShapesSource.SetBlendShapeWeight(upBlendShapeIndex, 0);
                blendShapesSource.SetBlendShapeWeight(downBlendShapeIndex, 0);
            }
            else if (_lookUpDown > 0)
            {

            }
            else
            {

            }

            
        }
    }
}