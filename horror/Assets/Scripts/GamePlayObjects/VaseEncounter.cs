using MazeGame.Player;
using UnityEngine;

namespace MazeGame.GamePlayObjects
{
    public class VaseEncounter : MonoBehaviour
    {
        [SerializeField] private float treshold;
        [SerializeField] private GameObject brokenVersion, Echo;
        private void OnCollisionEnter(Collision other) 
        {
            if (other.relativeVelocity.magnitude > treshold)
            {
                int loud = Mathf.Clamp((int)other.relativeVelocity.magnitude ,3, 24);
                Instantiate(Echo, transform.position, Quaternion.identity).GetComponent<Echo>().SetSize(loud);
                Instantiate(brokenVersion, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    
    }
}
