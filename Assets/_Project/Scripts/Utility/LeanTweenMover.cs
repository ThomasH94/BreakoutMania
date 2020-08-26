using UnityEngine;

namespace BrickBreak.Utility.Tweening
{
    public class LeanTweenMover : MonoBehaviour
    {
        public float xDirection;
        public float yDirection;
        public LeanTweenType easeType;
        public float timeToMove;
        public GameObject objectToTween;

        private void OnEnable()
        {
            LeanMove2D(objectToTween);
        }
        
        public void LeanMove2D(GameObject mover)
        {
            Vector2 moverPosition = mover.transform.localPosition;
            Vector2 moveVector = new Vector2(moverPosition.x + xDirection, moverPosition.y + yDirection);
            LeanTween.cancel(objectToTween);
            LeanTween.moveLocal(mover, moveVector, timeToMove).setEase(easeType);
        }
    }
}