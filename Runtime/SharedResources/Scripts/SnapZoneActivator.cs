namespace Tilia.Interactions.SnapZone
{
    using UnityEngine;
    using Zinnia.Data.Attribute;
    using Zinnia.Tracking.Collision;

    /// <summary>
    /// Holds the linked settings for a Interactions SnapZone.
    /// </summary>
    public class SnapZoneActivator : MonoBehaviour
    {
        #region Facade Settings
        [Header("Facade Settings")]
        [Tooltip("The public interface facade.")]
        [SerializeField]
        [Restricted]
        private SnapZoneFacade facade;
        /// <summary>
        /// The public interface facade.
        /// </summary>
        public SnapZoneFacade Facade
        {
            get
            {
                return facade;
            }
            protected set
            {
                facade = value;
            }
        }
        [Tooltip("The CollisionTracker used for tracking collisions on the zone.")]
        [SerializeField]
        [Restricted]
        private CollisionTracker collisionTracker;
        /// <summary>
        /// The <see cref="CollisionTracker"/> used for tracking collisions on the zone.
        /// </summary>
        public CollisionTracker CollisionTracker
        {
            get
            {
                return collisionTracker;
            }
            protected set
            {
                collisionTracker = value;
            }
        }
        [Tooltip("The Collider that is used to determine the collidable area for the zone.")]
        [SerializeField]
        private Collider collider;
        /// <summary>
        /// The <see cref="Collider"/> that is used to determine the collidable area for the zone.
        /// </summary>
        public Collider Collider
        {
            get
            {
                return collider;
            }
            set
            {
                collider = value;
            }
        }
        #endregion
    }
}