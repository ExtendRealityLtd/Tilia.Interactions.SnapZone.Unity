namespace Tilia.Interactions.SnapZone
{
    using System;
    using System.Collections.Generic;
    using Tilia.Interactions.Interactables.Interactables;
    using UnityEngine;
    using UnityEngine.Events;
    using Zinnia.Data.Attribute;
    using Zinnia.Extension;

    /// <summary>
    /// Determines if the collided SnapZone is valid for activation based on whether another SnapZone is already holding the activated state.
    /// </summary>
    public class ActivationValidator : MonoBehaviour
    {
        /// <summary>
        /// Defines the event with the <see cref="GameObject"/>.
        /// </summary>
        [Serializable]
        public class UnityEvent : UnityEvent<GameObject> { }

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

        /// <summary>
        /// Emitted when the SnapZone activation is validated.
        /// </summary>
        public UnityEvent Validated = new UnityEvent();

        /// <summary>
        /// Determines if the SnapZone is currently activated.
        /// </summary>
        public bool IsActivated { get; protected set; }

        /// <summary>
        /// A unique reference for a listener based upon the interactable and SnapZone being activated.
        /// </summary>
        protected struct ListenerKey
        {
            private readonly GameObject interactable;
            private readonly SnapZoneActivator zone;

            public ListenerKey(GameObject interactable, SnapZoneActivator zone)
            {
                this.interactable = interactable;
                this.zone = zone;
            }
        }

        /// <summary>
        /// The <see cref="GameObject"/> that is currently activating this SnapZone.
        /// </summary>
        protected GameObject currentActivatingGameObject;
        /// <summary>
        /// The <see cref="InteractableFacade"/> associated to the <see cref="GameObject"/> that is currently activating this SnapZone.
        /// </summary>
        protected InteractableFacade currentActivatingInteractable;
        /// <summary>
        /// A collection of listeners registered with the SnapZone that is being activated by a given interactable <see cref="GameObject"/>.
        /// </summary>
        protected Dictionary<ListenerKey, UnityAction<GameObject>> activatingZoneListeners = new Dictionary<ListenerKey, UnityAction<GameObject>>();
        /// <summary>
        /// A collection of listeners registered with this SnapZone.
        /// </summary>
        protected Dictionary<ListenerKey, UnityAction<GameObject>> currentZoneListeners = new Dictionary<ListenerKey, UnityAction<GameObject>>();
        /// <summary>
        /// A collection of found snap zone collisions that are actually invalid and not colliding.
        /// </summary>
        List<GameObject> invalidSnapZoneCollisions = new List<GameObject>();

        /// <summary>
        /// Attempts to activate the SnapZone if the colliding <see cref="GameObject"/> is not already activating another SnapZone.
        /// </summary>
        /// <param name="activator">The colliding interactable.</param>
        public virtual void Activate(GameObject activator)
        {
            IsActivated = false;
            TrySetInteractableFacade(activator);
            if (currentActivatingInteractable == null || Facade.Configuration.ActivationArea == null || !Facade.Configuration.CollidingObjectsList.Contains(currentActivatingInteractable.gameObject))
            {
                return;
            }

            currentActivatingInteractable.Configuration.ActiveCollisions.AddUnique(Facade.Configuration.ActivationArea.gameObject);
            invalidSnapZoneCollisions.Clear();

            foreach (GameObject collidingObject in currentActivatingInteractable.Configuration.ActiveCollisions.SubscribableElements)
            {
                if (collidingObject == null)
                {
                    continue;
                }

                SnapZoneActivator activatingZone = collidingObject.GetComponent<SnapZoneActivator>();
                if (activatingZone == null)
                {
                    continue;
                }

                if (!activatingZone.Facade.Configuration.CollidingObjectsList.Contains(currentActivatingInteractable.gameObject))
                {
                    invalidSnapZoneCollisions.Add(activatingZone.Facade.Configuration.ActivationArea.gameObject);
                    continue;
                }

                if (activatingZone == Facade.Configuration.ActivationArea)
                {
                    if (!IsActivated)
                    {
                        Facade.Configuration.EmitActivated(activator);
                    }
                    IsActivated = true;
                    Validated?.Invoke(activator);
                    ClearInvalidSnapZoneCollisions(currentActivatingInteractable, ref invalidSnapZoneCollisions);
                    break;
                }
                else
                {
                    ListenerKey listenerKey = new ListenerKey(activator, activatingZone);

                    if (!activatingZoneListeners.ContainsKey(listenerKey))
                    {
                        UnityAction<GameObject> onExitActivatingZoneListener = activatingInteractable => AttemptReactivation(activatingInteractable, activatingZone);
                        activatingZone.Facade.Exited.AddListener(onExitActivatingZoneListener);
                        activatingZoneListeners.Add(listenerKey, onExitActivatingZoneListener);
                    }

                    if (!currentZoneListeners.ContainsKey(listenerKey))
                    {
                        UnityAction<GameObject> onExitCurrentZoneListener = activatingInteractable => CancelAttemptReactivation(activatingInteractable, activatingZone);
                        Facade.Exited.AddListener(onExitCurrentZoneListener);
                        currentZoneListeners.Add(listenerKey, onExitCurrentZoneListener);
                    }
                    ClearInvalidSnapZoneCollisions(currentActivatingInteractable, ref invalidSnapZoneCollisions);
                    break;
                }
            }

            ClearInvalidSnapZoneCollisions(currentActivatingInteractable, ref invalidSnapZoneCollisions);
        }

        /// <summary>
        /// Attempts to Deactivate the SnapZone if it is already activated.
        /// </summary>
        /// <param name="deactivator">The interactable that is no longer colliding with the SnapZone.</param>
        public virtual void Deactivate(GameObject deactivator)
        {
            if (IsActivated)
            {
                IsActivated = false;
                Facade.Configuration.EmitDeactivated(deactivator);
            }

            InteractableFacade deactivatingInteractable = TryGetInteractable(deactivator);
            if (deactivatingInteractable != null)
            {
                deactivatingInteractable.Configuration.ActiveCollisions.Remove(Facade.Configuration.ActivationArea.gameObject);
            }
        }

        /// <summary>
        /// Clears any invalid SnapZone collision that still may be stored on the activating Interactable.
        /// </summary>
        /// <param name="interactable">The activating interactable.</param>
        /// <param name="invalidCollisions">The collection of invalid SnapZone collisions.</param>
        protected virtual void ClearInvalidSnapZoneCollisions(InteractableFacade interactable, ref List<GameObject> invalidCollisions)
        {
            foreach (GameObject invalidCollision in invalidCollisions)
            {
                interactable.Configuration.ActiveCollisions.Remove(invalidCollision);
            }
            invalidCollisions.Clear();
        }

        /// <summary>
        /// Attempts activate this SnapZone with the given <see cref="GameObject"/>.
        /// </summary>
        /// <param name="activator">The colliding interactable.</param>
        /// <param name="activatingZone">The SnapZone that was previously being activated by the colliding interactable.</param>
        protected virtual void AttemptReactivation(GameObject activator, SnapZoneActivator activatingZone)
        {
            InteractableFacade foundInteractable = activator.TryGetComponent<InteractableFacade>(true, true);
            if (foundInteractable != null)
            {
                foundInteractable.Configuration.ActiveCollisions.Remove(activatingZone.Facade.Configuration.ActivationArea.gameObject);
            }

            ListenerKey listenerKey = new ListenerKey(activator, activatingZone);
            activatingZoneListeners.TryGetValue(listenerKey, out UnityAction<GameObject> activatingZoneListener);
            if (activatingZoneListener != null)
            {
                activatingZone.Facade.Exited.RemoveListener(activatingZoneListener);
            }
            activatingZoneListeners.Remove(listenerKey);
            Activate(activator);
        }

        /// <summary>
        /// Cancels the attempt to activate the SnapZone upon the previous activating SnapZone becoming deactivated.
        /// </summary>
        /// <param name="activator">The colliding interactable.</param>
        /// <param name="activatingZone">The SnapZone that was previously being activated by the colliding interactable.</param>
        protected virtual void CancelAttemptReactivation(GameObject activator, SnapZoneActivator activatingZone)
        {
            ListenerKey listenerKey = new ListenerKey(activator, activatingZone);

            activatingZoneListeners.TryGetValue(listenerKey, out UnityAction<GameObject> onExitActivatingZoneListener);
            if (onExitActivatingZoneListener != null)
            {
                activatingZone.Facade.Exited.RemoveListener(onExitActivatingZoneListener);
                activatingZoneListeners.Remove(listenerKey);
            }

            currentZoneListeners.TryGetValue(listenerKey, out UnityAction<GameObject> onExitCurrentZoneListener);
            if (onExitCurrentZoneListener != null)
            {
                Facade.Exited.RemoveListener(onExitCurrentZoneListener);
                currentZoneListeners.Remove(listenerKey);
            }
        }

        /// <summary>
        /// Attempts to set the cache for the <see cref="InteractableFacade"/> associated with the given valid snappable <see cref="GameObject"/>.
        /// </summary>
        /// <param name="container">The colliding interactable.</param>
        protected virtual void TrySetInteractableFacade(GameObject container)
        {
            if ((container != null && container != currentActivatingGameObject) || currentActivatingInteractable == null)
            {
                currentActivatingGameObject = container;
                currentActivatingInteractable = TryGetInteractable(currentActivatingGameObject);
            }

            if (currentActivatingInteractable == null)
            {
                throw new NullReferenceException("The given container must contain an InteractableFacade.");
            }
        }

        /// <summary>
        /// Attempts to retrieve the <see cref="InteractableFacade"/> associated with the given valid snappable <see cref="GameObject"/>.
        /// </summary>
        /// <param name="container">The colliding interactable.</param>
        /// <returns>The interactable associated with the snappable object.</returns>
        protected virtual InteractableFacade TryGetInteractable(GameObject container)
        {
            return container != null ? container.TryGetComponent<InteractableFacade>(true, true) : null;
        }
    }
}