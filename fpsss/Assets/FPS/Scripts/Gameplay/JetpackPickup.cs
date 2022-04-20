using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class JetpackPickup : Pickup
    {
        [Tooltip("Time after which pickup will be reactivated (in seconds)")]
        public float reactivateTime;

        protected override void OnPicked(PlayerCharacterController byPlayer)
        {
            var jetpack = byPlayer.GetComponent<Jetpack>();
            if (!jetpack)
                return;

            if (jetpack.TryUnlock())
            {
                PlayPickupFeedback();
                gameObject.SetActive(false);
                Invoke("reactivePickup", reactivateTime);
            }
        }
    }
}