﻿namespace OpenDis.Dis1995
{
    /// <summary>
    /// Each entity in a given DIS simulation application shall be given an entity identifier number
    /// unique to all other entities in that application. This identifier number is valid for the
    /// duration of the exercise; however, entity identifier numbers may be reused when all possible
    /// numbers have been exhausted. No entity shall have an entity identifier number of NO_ENTITY,
    /// ALL_ENTITIES, or RQST_ASSIGN_ID. The entity identifier number need not be registered or
    /// retained for future exercises. The entity identifier number shall be specified by a 16-bit
    /// unsigned integer. An entity identifier number equal to zero with valid site and application
    /// identification shall address a simulation application. An entity identifier number equal to
    /// ALL_ENTITIES shall mean all entities within the specified site and application. An entity
    /// identifier number equal to RQST_ASSIGN_ID allows the receiver of the create entity to define
    /// the entity identifier number of the new entity.
    /// </summary>
    public partial class EntityID
    {
        public override string ToString() => string.Format("{0:00}{1:00}{2:00}", Site, Application, Entity);
    }
}
