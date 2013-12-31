// -----------------------------------------------------------------------
// <copyright file="ChangeSet.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Barclays.Treasury.ChangeSets
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    /// <summary>
    /// The ChangeSet object.
    /// </summary>
    [DataContract]
    public class ChangeSet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeSet"/> class.
        /// </summary>
        /// <param name="instanceId">
        /// The instance id.
        /// </param>
        public ChangeSet(Guid instanceId)
        {
            this.GuidId = instanceId;
            this.IntegerId = 0;
            this.Changes = new List<Change>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeSet"/> class.
        /// </summary>
        /// <param name="instanceId">
        /// The instance id.
        /// </param>
        public ChangeSet(int instanceId)
        {
            this.GuidId = Guid.Empty;
            this.IntegerId = instanceId;
            this.Changes = new List<Change>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeSet"/> class.
        /// </summary>
        public ChangeSet()
        {
            this.Changes = new List<Change>();
        }

        /// <summary>
        /// Id of the business object that this changeset is for.
        /// </summary>
        /// <value>The id.</value>
        [DataMember(IsRequired = true)]
        public Guid GuidId { get; private set; }

        /// <summary>
        /// Id of the business object that this changeset is for.
        /// </summary>
        /// <value>The id.</value>
        [DataMember(IsRequired = true)]
        public int IntegerId { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether to delete the object.
        /// </summary>
        /// <value><c>true</c> if [delete flag]; otherwise, <c>false</c>.</value>
        [DataMember(IsRequired = true)]
        public bool DeleteFlag { get; set; }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get
            {
                if (null == this.Changes)
                {
                    this.Changes = new List<Change>();
                }

                return this.Changes.Count;
            }
        }

        /// <summary>
        /// The current list of Changes (ChangeSet).
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1623:PropertySummaryDocumentationMustMatchAccessors", Justification = "Reviewed. Suppression is OK here.")]
        [DataMember(IsRequired = true)]
        public List<Change> Changes { get; private set; }

        /// <summary>
        /// Clears the collection of changes recorded.
        /// </summary>
        /// <returns>true if successful, else false</returns>
        public bool ClearChanges()
        {
            this.Changes.Clear();
            if (this.Changes.Count > 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>Adds to the collection of changes recorded.</summary>
        /// <param name="change">The change that is being added to the collection.</param>
        /// <returns>true if successful, else false</returns>
        public bool AddChange(Change change)
        {
            try
            {
                this.Changes.Add(change);
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Removes the change from the list of changes recorded.
        /// </summary>
        /// <returns>true if successful, else false</returns>
        public bool RemoveChange(Change change)
        {
            return this.Changes.Remove(change);
        }

        /// <summary>
        /// Undoes the last change recorded.
        /// </summary>
        /// <returns>true if successful, else false</returns>
        public bool UndoLastChange()
        {
            try
            {
                this.Changes.RemoveAt(this.Changes.Count - 1);  // remove the last entry
                return true;
            }
            catch (System.ArgumentOutOfRangeException exception)
            {
                return false;
            }
        }
    }
}
