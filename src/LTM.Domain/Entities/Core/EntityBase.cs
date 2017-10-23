using System;

namespace LTM.Domain.Entities.Core
{
    /// <summary>
    /// Classe base, criada para ser a base de todas entidades, tudo que é comum entre elas
    /// </summary>
    public abstract class EntityBase
    {
        #region properties
        public Guid Id { get; private set; }
        #endregion

        #region constructors
        public EntityBase(Guid id)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
        }
        #endregion
    }
}
