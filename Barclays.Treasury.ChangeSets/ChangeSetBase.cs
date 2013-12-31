// -----------------------------------------------------------------------
// <copyright file="ChangeSetBase.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Barclays.Treasury.ChangeSets
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ChangeSetBase
    {
        public Guid Id { get; set; }

        #region Changeset functionality

        protected void StoreAndEventChange<T>(Expression<Func<T>> property, object originalValue, object newValue)
        {
            var memberExpression = (property.Body as MemberExpression);

            if (memberExpression != null)
            {
                var propertyInfo = memberExpression.Member as PropertyInfo;

                Debug.Assert(propertyInfo != null,
                             "Error, property  " + property + " does not exist on " + this.GetType().Name + " object.");

                var propertyName = propertyInfo.Name;
                var change = new Change(propertyName, originalValue, newValue);
                ChangeSet.AddChange(change);
                // EventChangeToObject(propertyName, change);
            }
            else
            {
                throw new InvalidOperationException("Invalid usage of StoreAndEventChange");
            }
        }

        ///// <summary>
        ///// Merges the item supplied into this instance provided it is of the same type.
        ///// Only properties marked with the 
        ///// </summary>
        ///// <param name="item"></param>
        ///// <param name="makeChangeset"></param>
        //public virtual void Merge(CDSType item, bool makeChangeset = false)
        //{
        //    // Check item is not null and that it is a child of this type.
        //    if (item != null && this.GetType().IsInstanceOfType(item))
        //    {
        //        // Get only the properties with the merge attribute applied to them.
        //        var propertiesToMerge = GetType().GetProperties().Where(p => Attribute.GetCustomAttribute(p, typeof(MergePropertyAttribute)) != null);

        //        foreach (var propertyToMerge in propertiesToMerge)
        //        {
        //            propertyToMerge.SetValue(this, propertyToMerge.GetValue(item, null), null);
        //        }

        //        // Delete the changeset if requested.
        //        if (!makeChangeset && changeSet != null)
        //        {
        //            changeSet.ClearChanges();
        //        }

        //        EventBusinessObjectChanged(this);
        //    }
        //}

        /// <summary>
        /// Applies the complete ChangeSet.
        /// </summary>
        /// <param name="changes">The ChangeSet.</param>
        public virtual void ApplyChangeSet(ChangeSet changes)
        {
            foreach (var change in changes.Changes)
            {
                ApplyChange(change);
            }
        }

        /// <summary>
        /// Applies the supplied change to this instance.
        /// </summary>
        /// <param name="change">The change.</param>
        public virtual void ApplyChange(Change change)
        {
            var propertyToChange = this.GetType().GetProperty(change.PropertyName);
            if (propertyToChange == null)
            {
                throw new ArgumentException(this.GetType() + " does not have a property " + change.PropertyName);
            }

            propertyToChange.SetValue(this, change.NewValue, null);
        }

        /// <summary>
        /// Re-Applies the original value to this instance
        /// </summary>
        /// <param name="change">The change.</param>
        public void RemoveChange(Change change)
        {
            var propertyToChange = this.GetType().GetProperty(change.PropertyName);
            if (propertyToChange == null)
            {
                throw new ArgumentException(this.GetType() + " does not have a property " + change.PropertyName);
            }

            propertyToChange.SetValue(this, change.OriginalValue, null);
        }

        /// <summary>
        /// Gets a value indicating whether this instance is dirty.
        /// </summary>
        /// <value><c>true</c> if this instance is dirty; otherwise, <c>false</c>.</value>
        public bool IsDirty
        {
            get
            {
                if (this.changeSet == null)
                {
                    this.changeSet = new ChangeSet(this.Id);
                }

                if (this.changeSet.Count > 0)
                {
                    return true;
                }

                return false;
            }
        }

        protected ChangeSet changeSet;
        
        /// <summary>
        /// Gets the ChangeSet for this Client.
        /// </summary>
        /// <value>The change set.</value>
        public ChangeSet ChangeSet
        {
            get
            {
                if (this.changeSet == null)
                {
                    this.changeSet = new ChangeSet(this.Id);
                }
                return this.changeSet;
            }
        }

        #endregion
    }
}
