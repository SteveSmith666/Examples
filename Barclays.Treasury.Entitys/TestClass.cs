namespace Barclays.Treasury.Entitys
{
    using System;

    using Barclays.Treasury.ChangeSets;

    public class TestClass : EntityBase
    {
        public TestClass()
        {
            base.Id = Guid.NewGuid();
        }

        public TestClass(ChangeSet changeSet1)
        {
            base.Id = changeSet1.GuidId;
            base.ApplyChangeSet(changeSet1);
        }

        public string AString { get; set; }
        public int AInt { get; set; }

        private string bString = "";
        public string BString
        {
            get
            {
                return this.bString;
            }

            set
            {
                if (this.bString != value)
                {
                    StoreAndEventChange(() => this.BString, this.bString, value);
                    this.bString = value;
                }
            }
        }
    }
}
