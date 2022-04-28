namespace Tilia.Interactions.SnapZone
{
    using System.Collections;
    using Tilia.Interactions.Interactables.Interactables;
    using Tilia.Interactions.Interactables.Interactables.Grab;
    using UnityEngine;
    using Zinnia.Data.Attribute;
    using Zinnia.Data.Collection.List;
    using Zinnia.Data.Type;
    using Zinnia.Event.Proxy;
    using Zinnia.Extension;
    using Zinnia.Rule;
    using Zinnia.Rule.Collection;
    using Zinnia.Tracking.Modification;

    /// <summary>
    /// Sets up the Interactions SnapZone Prefab based on the provided user settings.
    /// </summary>
    public class SnapZoneConfigurator : MonoBehaviour
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
        #endregion

        #region Reference Settings
        [Header("Reference Settings")]
        [Tooltip("The RuleContainerObservableList that determines the valid snappable Interactables.")]
        [SerializeField]
        [Restricted]
        private RuleContainerObservableList validCollisionRules;
        /// <summary>
        /// The <see cref="RuleContainerObservableList"/> that determines the valid snappable Interactables.
        /// </summary>
        public RuleContainerObservableList ValidCollisionRules
        {
            get
            {
                return validCollisionRules;
            }
            protected set
            {
                validCollisionRules = value;
            }
        }
        [Tooltip("The AllRule that takes the ValidCollisionRules.")]
        [SerializeField]
        [Restricted]
        private AllRule allValidRules;
        /// <summary>
        /// The <see cref="AllRule"/> that takes the <see cref="ValidCollisionRules"/>.
        /// </summary>
        public AllRule AllValidRules
        {
            get
            {
                return allValidRules;
            }
            protected set
            {
                allValidRules = value;
            }
        }
        [Tooltip("The InteractableGrabStateEmitter that processes if the interactable entering the zone is being grabbed.")]
        [SerializeField]
        [Restricted]
        private InteractableGrabStateEmitter grabStateEmitter;
        /// <summary>
        /// The <see cref="InteractableGrabStateEmitter"/> that processes if the interactable entering the zone is being grabbed.
        /// </summary>
        public InteractableGrabStateEmitter GrabStateEmitter
        {
            get
            {
                return grabStateEmitter;
            }
            protected set
            {
                grabStateEmitter = value;
            }
        }
        [Tooltip("The SnapZoneActivator that determines if the activation area.")]
        [SerializeField]
        [Restricted]
        private SnapZoneActivator activationArea;
        /// <summary>
        /// The <see cref="SnapZoneActivator"/> that determines if the activation area.
        /// </summary>
        public SnapZoneActivator ActivationArea
        {
            get
            {
                return activationArea;
            }
            protected set
            {
                activationArea = value;
            }
        }
        [Tooltip("The ActivationValidator that determines if the activation of the zone is valid.")]
        [SerializeField]
        [Restricted]
        private ActivationValidator activationValidator;
        /// <summary>
        /// The <see cref="ActivationValidator"/> that determines if the activation of the zone is valid.
        /// </summary>
        public ActivationValidator ActivationValidator
        {
            get
            {
                return activationValidator;
            }
            protected set
            {
                activationValidator = value;
            }
        }
        [Tooltip("The TransformPropertyApplier that transitions the Interactable to the snapped destination.")]
        [SerializeField]
        [Restricted]
        private TransformPropertyApplier propertyApplier;
        /// <summary>
        /// The <see cref="TransformPropertyApplier"/> that transitions the Interactable to the snapped destination.
        /// </summary>
        public TransformPropertyApplier PropertyApplier
        {
            get
            {
                return propertyApplier;
            }
            protected set
            {
                propertyApplier = value;
            }
        }
        [Tooltip("The GameObjectObservableList containing the list of objects that are currently colliding with the zone.")]
        [SerializeField]
        [Restricted]
        private GameObjectObservableList collidingObjectsList;
        /// <summary>
        /// The <see cref="GameObjectObservableList"/> containing the list of objects that are currently colliding with the zone.
        /// </summary>
        public GameObjectObservableList CollidingObjectsList
        {
            get
            {
                return collidingObjectsList;
            }
            protected set
            {
                collidingObjectsList = value;
            }
        }
        [Tooltip("The GameObjectObservableList containing the list of Interactables that can be snapped.")]
        [SerializeField]
        [Restricted]
        private GameObjectObservableList validSnappableInteractablesList;
        /// <summary>
        /// The <see cref="GameObjectObservableList"/> containing the list of Interactables that can be snapped.
        /// </summary>
        public GameObjectObservableList ValidSnappableInteractablesList
        {
            get
            {
                return validSnappableInteractablesList;
            }
            protected set
            {
                validSnappableInteractablesList = value;
            }
        }
        [Tooltip("The GameObjectObservableList containing the list of snapped Interactables.")]
        [SerializeField]
        [Restricted]
        private GameObjectObservableList snappedInteractablesList;
        /// <summary>
        /// The <see cref="GameObjectObservableList"/> containing the list of snapped Interactables.
        /// </summary>
        public GameObjectObservableList SnappedInteractablesList
        {
            get
            {
                return snappedInteractablesList;
            }
            protected set
            {
                snappedInteractablesList = value;
            }
        }
        [Tooltip("The GameObjectEventProxyEmitter that is responsible for processing the snap of a valid dropped Interactable.")]
        [SerializeField]
        [Restricted]
        private GameObjectEventProxyEmitter snapDroppedInteractableProcess;
        /// <summary>
        /// The <see cref="GameObjectEventProxyEmitter"/> that is responsible for processing the snap of a valid dropped Interactable.
        /// </summary>
        public GameObjectEventProxyEmitter SnapDroppedInteractableProcess
        {
            get
            {
                return snapDroppedInteractableProcess;
            }
            protected set
            {
                snapDroppedInteractableProcess = value;
            }
        }
        [Tooltip("The GameObjectEventProxyEmitter that is responsible for forcing an unsnap of the snapped Interactable.")]
        [SerializeField]
        [Restricted]
        private GameObjectEventProxyEmitter forceUnsnapInteractableProcess;
        /// <summary>
        /// The <see cref="GameObjectEventProxyEmitter"/> that is responsible for forcing an unsnap of the snapped Interactable.
        /// </summary>
        public GameObjectEventProxyEmitter ForceUnsnapInteractableProcess
        {
            get
            {
                return forceUnsnapInteractableProcess;
            }
            protected set
            {
                forceUnsnapInteractableProcess = value;
            }
        }
        [Tooltip("The GameObject that determines the snap destination location.")]
        [SerializeField]
        [Restricted]
        private GameObject destinationLocation;
        /// <summary>
        /// The <see cref="GameObject"/> that determines the snap destination location.
        /// </summary>
        public GameObject DestinationLocation
        {
            get
            {
                return destinationLocation;
            }
            protected set
            {
                destinationLocation = value;
            }
        }
        [Tooltip("The GameObject that contains the auto snap logic.")]
        [SerializeField]
        [Restricted]
        private GameObject autoSnapLogicContainer;
        /// <summary>
        /// The <see cref="GameObject"/> that contains the auto snap logic.
        /// </summary>
        public GameObject AutoSnapLogicContainer
        {
            get
            {
                return autoSnapLogicContainer;
            }
            protected set
            {
                autoSnapLogicContainer = value;
            }
        }
        [Tooltip("The initial duration to transition the default Interactable to the SnapZone.")]
        [SerializeField]
        private float initialTransitionDuration;
        /// <summary>
        /// The initial duration to transition the default Interactable to the SnapZone.
        /// </summary>
        public float InitialTransitionDuration
        {
            get
            {
                return initialTransitionDuration;
            }
            set
            {
                initialTransitionDuration = value;
            }
        }
        #endregion

        /// <summary>
        /// Returns the collection of <see cref="GameObject"/>s that are currently colliding with the snap zone and are valid to be snapped.
        /// </summary>
        public virtual HeapAllocationFreeReadOnlyList<GameObject> SnappableInteractables => ValidSnappableInteractablesList.NonSubscribableElements;
        /// <summary>
        /// Returns the currently snapped <see cref="GameObject"/>.
        /// </summary>
        public virtual GameObject SnappedInteractable => SnappedInteractablesList.NonSubscribableElements.Count > 0 ? SnappedInteractablesList.NonSubscribableElements[0] : null;

        /// <summary>
        /// An instruction for yielding at the end of the current frame.
        /// </summary>
        protected YieldInstruction EndOfFrameInstruction = new WaitForEndOfFrame();
        /// <summary>
        /// The <see cref="Coroutine"/> for managing the default initial snap.
        /// </summary>
        protected Coroutine SnapDefaultInteractableRoutine;

        /// <summary>
        /// An offset to apply upon snap if the snapped <see cref="GameObject"/> is in the same position as the <see cref="DestinationLocation"/> to ensure the follower works correctly.
        /// </summary>
        private const float InitialOffset = 0.05f;

        /// <summary>
        /// Attempts to snap a given <see cref="GameObject"/> to the snap zone.
        /// </summary>
        /// <param name="objectToSnap">The object to attempt to snap.</param>
        public virtual void Snap(GameObject objectToSnap)
        {
            if (!AllValidRules.Accepts(objectToSnap))
            {
                return;
            }

            InteractableFacade snappableInteractable = objectToSnap.TryGetComponent<InteractableFacade>(true, true);
            if (snappableInteractable == null || SnappedInteractable != null)
            {
                return;
            }

            foreach (GameObject collidingWith in snappableInteractable.Configuration.ActiveCollisions.SubscribableElements)
            {
                SnapZoneActivator activatingZone = collidingWith.GetComponent<SnapZoneActivator>();

                if (activatingZone == null)
                {
                    continue;
                }

                activatingZone.Facade.Unsnap();
                break;
            }

            if (objectToSnap.transform.position.ApproxEquals(DestinationLocation.transform.position))
            {
                objectToSnap.transform.position += Vector3.forward * InitialOffset;
            }

            SnapDroppedInteractableProcess.Receive(objectToSnap);
        }

        /// <summary>
        /// Attempts to unsnap any existing <see cref="InteractableFacade"/> that is currently snapped to the snap zone.
        /// </summary>
        public virtual void Unsnap()
        {
            if (SnappedInteractable == null)
            {
                return;
            }

            ForceUnsnapInteractableProcess.Receive(SnappedInteractable.gameObject);
        }

        /// <summary>
        /// Emits the Entered event.
        /// </summary>
        /// <param name="entered">The <see cref="GameObject"/> that has entered the zone.</param>
        public virtual void EmitEntered(GameObject entered)
        {
            if (entered == null)
            {
                return;
            }

            Facade.Entered?.Invoke(entered);
        }

        /// <summary>
        /// Emits the Exited event.
        /// </summary>
        /// <param name="exited">The <see cref="GameObject"/> that has exited the zone.</param>
        public virtual void EmitExited(GameObject exited)
        {
            if (exited == null)
            {
                return;
            }

            Facade.Exited?.Invoke(exited);
        }

        /// <summary>
        /// Emits the Activated event.
        /// </summary>
        /// <param name="activator">The <see cref="GameObject"/> that has activated the zone.</param>
        public virtual void EmitActivated(GameObject activator)
        {
            if (activator == null)
            {
                return;
            }

            Facade.Activated?.Invoke(activator);
        }

        /// <summary>
        /// Emits the Deactivated event.
        /// </summary>
        /// <param name="deactivator">The <see cref="GameObject"/> that has deactivated the zone.</param>
        public virtual void EmitDeactivated(GameObject deactivator)
        {
            if (deactivator == null)
            {
                return;
            }

            Facade.Deactivated?.Invoke(deactivator);
        }

        /// <summary>
        /// Emits the Snapped event.
        /// </summary>
        /// <param name="snapped">The <see cref="GameObject"/> is snapped to the zone.</param>
        public virtual void EmitSnapped(GameObject snapped)
        {
            if (snapped == null)
            {
                return;
            }

            Facade.Snapped?.Invoke(snapped);
        }

        /// <summary>
        /// Emits the Unsnapped event.
        /// </summary>
        /// <param name="unsnapped">The <see cref="GameObject"/> is unsnapped from the zone.</param>
        public virtual void EmitUnsnapped(GameObject unsnapped)
        {
            if (unsnapped == null)
            {
                return;
            }

            Facade.Unsnapped?.Invoke(unsnapped);
        }

        /// <summary>
        /// Configures the validity rules for the snap zone.
        /// </summary>
        public virtual void ConfigureValidityRules()
        {
            if (ValidCollisionRules.NonSubscribableElements.Count > 1)
            {
                ValidCollisionRules.RunWhenActiveAndEnabled(() => ValidCollisionRules.RemoveAt(1));
            }
            if (Facade.SnapValidity.Interface != null)
            {
                ValidCollisionRules.RunWhenActiveAndEnabled(() => ValidCollisionRules.Add(Facade.SnapValidity));
            }
        }

        /// <summary>
        /// Configures the transition duration for the snapping process.
        /// </summary>
        public virtual void ConfigurePropertyApplier()
        {
            PropertyApplier.RunWhenActiveAndEnabled(() => PropertyApplier.TransitionDuration = Facade.TransitionDuration);
        }

        /// <summary>
        /// Configures the auto snap logic.
        /// </summary>
        public virtual void ConfigureAutoSnap()
        {
            AutoSnapLogicContainer.SetActive(Facade.AutoSnapThrownObjects);
        }

        /// <summary>
        /// Attempts to process any other valid snappable objects against any other potential SnapZones if their primary activating zone is snapped by another object.
        /// </summary>
        public virtual void ProcessOtherSnappablesOnSnap()
        {
            foreach (GameObject snappable in SnappableInteractables)
            {
                if (snappable == null || snappable == SnappedInteractable)
                {
                    continue;
                }

                InteractableFacade snappableInteractable = snappable.TryGetComponent<InteractableFacade>(true, true);

                if (snappableInteractable == null)
                {
                    continue;
                }

                foreach (GameObject collidingWith in snappableInteractable.Configuration.ActiveCollisions.SubscribableElements)
                {
                    SnapZoneActivator activatingZone = collidingWith.GetComponent<SnapZoneActivator>();

                    if (activatingZone == null || activatingZone == ActivationArea || activatingZone.Facade.ZoneState == SnapZoneFacade.SnapZoneState.ZoneIsActivated)
                    {
                        continue;
                    }

                    activatingZone.Facade.Configuration.GrabStateEmitter.DoIsGrabbed(snappableInteractable);
                    break;
                }
            }
        }

        protected virtual void OnEnable()
        {
            ConfigureValidityRules();
            ConfigurePropertyApplier();
            ConfigureAutoSnap();
            SnapDefaultInteractableRoutine = StartCoroutine(SnapInitialAtEndOfFrame());

            if (SnappedInteractable != null)
            {
                SnappedInteractable.gameObject.SetActive(true);
            }
        }

        protected virtual void OnDisable()
        {
            if (SnappedInteractable != null)
            {
                SnappedInteractable.gameObject.SetActive(false);
            }

            if (SnapDefaultInteractableRoutine != null)
            {
                StopCoroutine(SnapDefaultInteractableRoutine);
            }
        }

        /// <summary>
        /// Snaps the <see cref="Facade.SnapInitialAtEndOfFrame"/> to the snap zone at the end of the frame.
        /// </summary>
        /// <returns>An Enumerator to manage the running of the Coroutine.</returns>
        protected virtual IEnumerator SnapInitialAtEndOfFrame()
        {
            yield return EndOfFrameInstruction;
            if (SnappedInteractable == null && Facade.InitialSnappedInteractable != null)
            {
                float cachedDuration = Facade.TransitionDuration;
                Facade.TransitionDuration = InitialTransitionDuration;
                Facade.Snap(Facade.InitialSnappedInteractable);
                yield return new WaitForSeconds(InitialTransitionDuration);
                Facade.TransitionDuration = cachedDuration;
            }
            SnapDefaultInteractableRoutine = null;
        }
    }
}