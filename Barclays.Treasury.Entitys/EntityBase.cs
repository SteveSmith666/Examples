// -----------------------------------------------------------------------
// <copyright file="EntityBase.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Barclays.Treasury.Entitys
{
    using System;

    using Barclays.Treasury.ChangeSets;

    public class EntityBase: ChangeSetBase
    {
        public Guid Id
        {
            get
            {
                return base.Id;
            }

            set
            {
                base.Id = value;
            }
        }
    }
}
