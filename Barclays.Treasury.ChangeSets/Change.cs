// -----------------------------------------------------------------------
// <copyright file="Change.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Barclays.Treasury.ChangeSets
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Text;

    using Barclays.Treasury.Cryptography;

    /// <summary>
    /// Individual change record.
    /// </summary>
    [DataContract]
    public class Change
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
        private const string EncodingType = "iso-8859-1";

        /// <summary>
        /// Initializes a new instance of the <see cref="Change"/> class.
        /// </summary>
        public Change()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Change"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="originalValue">The original value.</param>
        /// <param name="newValue">The new value.</param>
        public Change(string propertyName, object originalValue, object newValue)
        {
            this.PropertyName = propertyName;
            this.OriginalValue = originalValue;
            this.NewValue = newValue;
            this.TimeStamp = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Local);     // just use local clock as our timestamp
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Change"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="originalValue">The original value.</param>
        /// <param name="newValue">The new value.</param>
        /// <param name="utcTimeStamp">The UTC time stamp. MUST BE OF KIND UTC!!!!</param>
        public Change(string propertyName, object originalValue, object newValue, DateTime utcTimeStamp)
        {
            this.PropertyName = propertyName;
            this.OriginalValue = originalValue;
            this.NewValue = newValue;
            if (utcTimeStamp.Kind != DateTimeKind.Utc)
            {
                this.TimeStamp = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Local);     // we just use local clock as our timestamp
            }
            else
            {
                this.TimeStamp = DateTime.Parse(utcTimeStamp.ToString(CultureInfo.InvariantCulture)); // we got the utc time given to us, so we store it as utc
                this.TimeStamp = DateTime.SpecifyKind(this.TimeStamp, DateTimeKind.Utc);
            }
        }

        /// <summary>
        /// Name of the property that the change is for
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1623:PropertySummaryDocumentationMustMatchAccessors", Justification = "Reviewed. Suppression is OK here.")]
        [DataMember(IsRequired = true)]
        public string PropertyName { get; private set; }

        /// <summary>
        /// The original value of the property before the change was made
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1623:PropertySummaryDocumentationMustMatchAccessors", Justification = "Reviewed. Suppression is OK here.")]
        [DataMember(IsRequired = true)]
        public object OriginalValue { get; private set; }

        /// <summary>
        /// The new value of the property after the change was made
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1623:PropertySummaryDocumentationMustMatchAccessors", Justification = "Reviewed. Suppression is OK here.")]
        [DataMember(IsRequired = true)]
        public object NewValue { get; private set; }

        /// <summary>
        /// Gets the time stamp that this change was made at.
        /// NOTE: Test the 'Kind' property to determine if the returned value is UTC or local machine time.... 
        /// </summary>
        /// <value>The time stamp.</value>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1623:PropertySummaryDocumentationMustMatchAccessors", Justification = "Reviewed. Suppression is OK here.")]
        [DataMember(IsRequired = true)]
        public DateTime TimeStamp { get; private set; }

        #region Serialialize/deserialize functions

        /// <summary>
        /// Gets or sets the original value as an XML string.
        /// Note that when 'setting' the submitted string in the set is expected to be ISO-Latin-1 encoded
        /// </summary>
        /// <value>The original value as XML.</value>
        public string OriginalValueAsXML
        {
            get
            {
               return this.Encrypt(this.SerializeObjectToString(this.OriginalValue));
            }

            set
            {
                this.OriginalValue = this.DeSerializeObjectFromstring(this.Decrypt(value));
            }
        }

        /// <summary>
        /// Gets or sets the new value as an XML string.
        /// Note that when 'setting' the submitted string in the set is expected to be ISO-Latin-1 encoded
        /// </summary>
        /// <value>The original value as XML.</value>
        public string NewValueAsXML
        {
            get
            {
                return this.Encrypt(this.SerializeObjectToString(this.NewValue));
            }

            set
            {
                this.NewValue = this.DeSerializeObjectFromstring(this.Decrypt(value));
            }
        }

        /// <summary>De-serialize object from string.</summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="object"/>.</returns>
        private object DeSerializeObjectFromstring(string value)
        {
            // rehydrate the string to it's full length (see Serialize method below)
            value = value.Replace("Schema", "http://schemas.microsoft.com/2003/10/Serialization/");

            var serializer = new NetDataContractSerializer();
            var byteArray = Encoding.GetEncoding(EncodingType).GetBytes(value);  // use the ISO-Latin-1 encoding
            var stream = new MemoryStream(byteArray);
            return serializer.Deserialize(stream);
        }

        /// <summary>Serialize object to string.</summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private string SerializeObjectToString(object value)
        {
            int count = 0;
            var serializer = new NetDataContractSerializer();
            var stream = new MemoryStream();

            // Serialize into MemoryStream
            serializer.Serialize(stream, value);

            // Read from the start
            stream.Seek(0, SeekOrigin.Begin);

            // Size the byteArray
            var byteArray = new byte[stream.Length];

            // Read all the bytes, byte by byte, into the array.
            while (count < stream.Length)
            {
                byteArray[count++] = Convert.ToByte(stream.ReadByte());
            }

            // Decode the byte array into a char array
            var charArray = new char[Encoding.GetEncoding(EncodingType).GetCharCount(byteArray, 0, count)];
            Encoding.GetEncoding(EncodingType).GetDecoder().GetChars(byteArray, 0, count, charArray, 0);

            var longString = new string(charArray);

            var shortString = longString.Replace("http://schemas.microsoft.com/2003/10/Serialization/", "Schema");

            return shortString;
        }

        /// <summary>The encryption method.</summary>
        /// <param name="data">The data string.</param>
        /// <returns>The encrypted string.</returns>
        private string Encrypt(string data)
        {
            // Return Crypto.EncryptString(data, "aesRijndael");
            return Crypto.Encrypt(data, true);
        }

        /// <summary>The decryption method.</summary>
        /// <param name="data">The encrypted data string.</param>
        /// <returns>The UN-encrypted string.</returns>
        private string Decrypt(string data)
        {
            // Return Crypto.DecryptString(data, "aesRijndael");
            return Crypto.Decrypt(data, true);
        }
        #endregion
    }
}