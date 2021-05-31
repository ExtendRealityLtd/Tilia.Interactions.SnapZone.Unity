# Class SnapZoneManager

A helper class for managing scene snap zones.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Methods]
  * [IsInSnapZone(InteractableFacade)]
  * [IsInSnapZone(InteractableFacade, out SnapZoneFacade)]
  * [UnsnapInteractable(InteractableFacade)]

## Details

##### Inheritance

* System.Object
* SnapZoneManager

##### Namespace

* [Tilia.Interactions.SnapZone]

##### Syntax

```
public class SnapZoneManager : MonoBehaviour
```

### Methods

#### IsInSnapZone(InteractableFacade)

Determines if the given Interactable is in a Snap Zone.

##### Declaration

```
public virtual bool IsInSnapZone(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| InteractableFacade | interactable | The Interactable to search on. |

##### Returns

| Type | Description |
| --- | --- |
| System.Boolean | Whether the given Interactable is in a Snap Zone. |

#### IsInSnapZone(InteractableFacade, out SnapZoneFacade)

Determines if the given Interactable is in a Snap Zone and optionally returns the Snap Zone if it is one.

##### Declaration

```
public virtual bool IsInSnapZone(InteractableFacade interactable, out SnapZoneFacade snapZoneFacade)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| InteractableFacade | interactable | The Interactable to search on. |
| [SnapZoneFacade] | snapZoneFacade | The found Snap Zone to return. |

##### Returns

| Type | Description |
| --- | --- |
| System.Boolean | Whether the given Interactable is in a Snap Zone. |

#### UnsnapInteractable(InteractableFacade)

Attempts to unsnap the given Interactable if it is snapped into a snap zone.

##### Declaration

```
public virtual void UnsnapInteractable(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| InteractableFacade | interactable | The Interactable to attempt to unsnap. |

[Tilia.Interactions.SnapZone]: README.md
[SnapZoneFacade]: SnapZoneFacade.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Methods]: #Methods
[IsInSnapZone(InteractableFacade)]: #IsInSnapZoneInteractableFacade
[IsInSnapZone(InteractableFacade, out SnapZoneFacade)]: #IsInSnapZoneInteractableFacade-out SnapZoneFacade
[UnsnapInteractable(InteractableFacade)]: #UnsnapInteractableInteractableFacade
