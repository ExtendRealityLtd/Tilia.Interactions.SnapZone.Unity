namespace Tilia.Interactions.SnapZone
{
    using System;
    using Tilia.Interactions.Interactables.Interactables;
    using UnityEngine;
    using UnityEngine.Events;
    using Zinnia.Data.Attribute;
    using Zinnia.Data.Type;
    using Zinnia.Extension;
    using Zinnia.Rule;

    /// <summary>
    /// The public interface into the Interactions SnapZone Prefab.
    /// </summary>
    public class SnapZoneFacade : MonoBehaviour
    {
        /// <summary>
        /// Defines the event with the <see cref="GameObject"/>.
        /// </summary>
        [Serializable]
        public class UnityEvent : UnityEvent<GameObject> { }

        /// <summary>
        /// The state the SnapZone is in.
        /// </summary>
        public enum SnapZoneState
        {
            /// <summary>
            /// No valid <see cref="GameObject"/> is colliding with the SnapZone and nothing has been snapped into the SnapZone.
            /// </summary>
            ZoneIsEmpty,
            /// <summary>
            /// At least one valid <see cref="GameObject"/> is colliding with the SnapZone but nothing has been snapped into the SnapZone.
            /// </summary>
            ZoneIsActivated,
            /// <summary>
            /// A valid <see cref="GameObject"/> has been snapped into the SnapZone.
            /// </summary>
            ZoneIsSnapped
        }

        #region Snap Settings
        [Header("Snap Settings")]
        [Tooltip("The rules that determine which GameObject can be snapped to this snap zone.")]
        [SerializeField]
        private RuleContainer snapValidity;
        /// <summary>
        /// The rules that determine which <see cref="GameObject"/> can be snapped to this snap zone.
        /// </summary>
        public RuleContainer SnapValidity
        {
            get
            {
                return snapValidity;
            }
            set
            {
                snapValidity = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterSnapValidityChange();
                }
            }
        }
        [Tooltip("The duration for the transition of the snapped GameObject to reach the snap zone destination.")]
        [SerializeField]
        private float transitionDuration;
        /// <summary>
        /// The duration for the transition of the snapped <see cref="GameObject"/> to reach the snap zone destination.
        /// </summary>
        public float TransitionDuration
        {
            get
            {
                return transitionDuration;
            }
            set
            {
                transitionDuration = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterTransitionDurationChange();
                }
            }
        }
        [Tooltip("An optional InteractableFacade to snap into the snap zone when the snap zone is enabled.")]
        [SerializeField]
        private InteractableFacade initialSnappedInteractable;
        /// <summary>
        /// An optional <see cref="InteractableFacade"/> to snap into the snap zone when the snap zone is enabled.
        /// </summary>
        public InteractableFacade InitialSnappedInteractable
        {
            get
            {
                return initialSnappedInteractable;
            }
            set
            {
                initialSnappedInteractable = value;
            }
        }
        [Tooltip("Whether to apply the scale of the snap zone to the target that is snapped into it.")]
        [SerializeField]
        private bool applySnapZoneScale = true;
        /// <summary>
        /// Whether to apply the scale of the snap zone to the target that is snapped into it.
        /// </summary>
        public bool ApplySnapZoneScale
        {
            get
            {
                return applySnapZoneScale;
            }
            set
            {
                applySnapZoneScale = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterApplySnapZoneScaleChange();
                }
            }
        }
        [Tooltip("Whether the snap zone highlight is always active or only active when the snap zone is actively hovered in.")]
        [SerializeField]
        private bool highlightAlwaysActive;
        /// <summary>
        /// Whether the snap zone highlight is always active or only active when the snap zone is actively hovered in.
        /// </summary>
        public bool HighlightAlwaysActive
        {
            get
            {
                return highlightAlwaysActive;
            }
            set
            {
                highlightAlwaysActive = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterHighlightAlwaysActiveChange();
                }
            }
        }
        [Tooltip("Whether to auto snap a thrown GameObject into this snap zone even if the GameObject is not being held as it enters the collision area.")]
        [SerializeField]
        private bool autoSnapThrownObjects;
        /// <summary>
        /// Whether to auto snap a thrown <see cref="GameObject"/> into this snap zone even if the <see cref="GameObject"/> is not being held as it enters the collision area.
        /// </summary>
        public bool AutoSnapThrownObjects
        {
            get
            {
                return autoSnapThrownObjects;
            }
            set
            {
                autoSnapThrownObjects = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterAutoSnapThrownObjectsChange();
                }
            }
        }
        #endregion

        #region Reference Settings
        [Header("Reference Settings")]
        [Tooltip("The linked Configurator Setup.")]
        [SerializeField]
        [Restricted]
        private SnapZoneConfigurator configuration;
        /// <summary>
        /// The linked Configurator Setup.
        /// </summary>
        public SnapZoneConfigurator Configuration
        {
            get
            {
                return configuration;
            }
            set
            {
                configuration = value;
            }
        }
        #endregion

        #region Zone Events
        /// <summary>
        /// Emitted when a valid <see cref="GameObject"/> enters the zone.
        /// </summary>
        [Header("Zone Events")]
        public UnityEvent Entered = new UnityEvent();
        /// <summary>
        /// Emitted when a valid <see cref="GameObject"/> exits the zone.
        /// </summary>
        public UnityEvent Exited = new UnityEvent();
        /// <summary>
        /// Emitted when a valid <see cref="GameObject"/> activates the zone.
        /// </summary>
        public UnityEvent Activated = new UnityEvent();
        /// <summary>
        /// Emitted when a valid <see cref="GameObject"/> deactivates the zone.
        /// </summary>
        public UnityEvent Deactivated = new UnityEvent();
        /// <summary>
        /// Emitted when a valid <see cref="GameObject"/> is snapped to the zone.
        /// </summary>
        public UnityEvent Snapped = new UnityEvent();
        /// <summary>
        /// Emitted when a valid <see cref="GameObject"/> is unsnapped from the zone.
        /// </summary>
        public UnityEvent Unsnapped = new UnityEvent();
        #endregion

        /// <summary>
        /// Returns the collection of <see cref="GameObject"/>s that are currently colliding with the snap zone and are valid to be snapped.
        /// </summary>
        public virtual HeapAllocationFreeReadOnlyList<GameObject> SnappableGameObjects => Configuration.SnappableInteractables;
        /// <summary>
        /// Returns the currently snapped <see cref="GameObject"/>.
        /// </summary>
        public virtual GameObject SnappedGameObject => Configuration.SnappedInteractable;
        /// <summary>
        /// The state of the snap zone.
        /// </summary>
        public virtual SnapZoneState ZoneState
        {
            get
            {
                if (SnappedGameObject != null)
                {
                    return SnapZoneState.ZoneIsSnapped;
                }
                else if (SnappableGameObjects.Count > 0)
                {
                    return SnapZoneState.ZoneIsActivated;
                }

                return SnapZoneState.ZoneIsEmpty;
            }
        }
        /// <summary>
        /// Whether the snap zone is visible or not.
        /// </summary>
        public virtual bool IsVisible
        {
            get
            {
                return gameObject.activeInHierarchy;
            }
            set
            {
                if (gameObject.activeInHierarchy)
                {
                    Configuration.Hide();
                }
                else
                {
                    Configuration.Show();
                }
            }
        }

        /// <summary>
        /// Clears <see cref="SnapValidity"/>.
        /// </summary>
        public virtual void ClearSnapValidity()
        {
            if (!this.IsValidState())
            {
                return;
            }

            SnapValidity = default;
        }

        /// <summary>
        /// Attempts to snap a given <see cref="InteractableFacade"/> to the snap zone.
        /// </summary>
        /// <param name="interactableToSnap">The interactable to attempt to snap.</param>
        public virtual void Snap(InteractableFacade interactableToSnap)
        {
            Snap(interactableToSnap.gameObject);
        }

        /// <summary>
        /// Attempts to snap a given <see cref="GameObject"/> to the snap zone.
        /// </summary>
        /// <param name="objectToSnap">The object to attempt to snap.</param>
        public virtual void Snap(GameObject objectToSnap)
        {
            Configuration.Snap(objectToSnap);
        }

        /// <summary>
        /// Attempts to unsnap any existing <see cref="GameObject"/> that is currently snapped to the snap zone.
        /// </summary>
        public virtual void Unsnap()
        {
            Configuration.Unsnap();
        }

        /// <summary>
        /// Prevents the snapped object from being grabbed.
        /// </summary>
        public virtual void PreventSnappedObjectGrab()
        {
            ToggleSnappedObjectGrab(false);
        }

        /// <summary>
        /// Allows the snapped object to be grabbed.
        /// </summary>
        public virtual void AllowSnappedObjectGrab()
        {
            ToggleSnappedObjectGrab(true);
        }

        /// <summary>
        /// Toggles the grabbed state of the snapped object.
        /// </summary>
        /// <param name="allow">Whether to allow the snapped object to be grabbed.</param>
        protected virtual void ToggleSnappedObjectGrab(bool allow)
        {
            if (SnappedGameObject == null)
            {
                return;
            }

            InteractableFacade interactable = SnappedGameObject.GetComponent<InteractableFacade>();

            if (interactable == null)
            {
                return;
            }

            if (allow)
            {
                interactable.EnableGrab();
            }
            else
            {
                interactable.DisableGrab();
            }
        }

        /// <summary>
        /// Called after <see cref="SnapValidity"/> has been changed.
        /// </summary>
        protected virtual void OnAfterSnapValidityChange()
        {
            Configuration.ConfigureValidityRules();
        }

        /// <summary>
        /// Called after <see cref="TransitionDuration"/> has been changed.
        /// </summary>
        protected virtual void OnAfterTransitionDurationChange()
        {
            Configuration.ConfigurePropertyApplier();
        }

        /// <summary>
        /// Called after <see cref="HighlightAlwaysActive"/> has been changed.
        /// </summary>
        protected virtual void OnAfterHighlightAlwaysActiveChange()
        {
            Configuration.ConfigureHighlightLogic();
        }

        /// <summary>
        /// Called after <see cref="ApplySnapZoneScale"/> has been changed.
        /// </summary>
        protected virtual void OnAfterApplySnapZoneScaleChange()
        {
            Configuration.ConfigureSnapZoneScaling();
        }

        /// <summary>
        /// Called after <see cref="AutoSnapThrownObjects"/> has been changed.
        /// </summary>
        protected virtual void OnAfterAutoSnapThrownObjectsChange()
        {
            Configuration.ConfigureAutoSnap();
        }
    }
}