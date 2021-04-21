namespace Tilia.Interactions.SnapZone
{
    using Tilia.Interactions.Interactables.Interactables;
    using UnityEngine;
    using Zinnia.Extension;

    /// <summary>
    /// A helper class for managing scene snap zones.
    /// </summary>
    public class SnapZoneManager : MonoBehaviour
    {
        /// <summary>
        /// Determines if the given Interactable is in a Snap Zone and optionally returns the Snap Zone if it is one.
        /// </summary>
        /// <param name="interactable">The Interactable to search on.</param>
        /// <param name="snapZoneFacade">The found Snap Zone to return.</param>
        /// <returns>Whether the given Interactable is in a Snap Zone.</returns>
        public virtual bool IsInSnapZone(InteractableFacade interactable, out SnapZoneFacade snapZoneFacade)
        {
            snapZoneFacade = null;

            if (interactable == null)
            {
                return false;
            }

            foreach (GameObject activeCollision in interactable.Configuration.ActiveCollisions.NonSubscribableElements)
            {
                SnapZoneActivator foundActivator = activeCollision.TryGetComponent<SnapZoneActivator>();
                if (foundActivator != null && foundActivator.Facade != null)
                {
                    snapZoneFacade = foundActivator.Facade;
                    break;
                }
            }

            return snapZoneFacade != null;
        }

        /// <summary>
        /// Determines if the given Interactable is in a Snap Zone.
        /// </summary>
        /// <param name="interactable">The Interactable to search on.</param>
        /// <returns>Whether the given Interactable is in a Snap Zone.</returns>
        public virtual bool IsInSnapZone(InteractableFacade interactable)
        {
            return IsInSnapZone(interactable, out SnapZoneFacade _);
        }

        /// <summary>
        /// Attempts to unsnap the given Interactable if it is snapped into a snap zone.
        /// </summary>
        /// <param name="interactable">The Interactable to attempt to unsnap.</param>
        public virtual void UnsnapInteractable(InteractableFacade interactable)
        {
            if (!IsInSnapZone(interactable, out SnapZoneFacade foundSnapZone))
            {
                return;
            }

            if (foundSnapZone != null)
            {
                foundSnapZone.Unsnap();
            }
        }
    }
}