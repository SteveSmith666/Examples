using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StreamingDemo.Client
{
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Media;

    using StreamingDemo.Client.serviceProxy;
    public partial class Form1 : Form
    {
        SoundPlayer mediaPlayer = new SoundPlayer();
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The TCP media streaming proxy.
        /// </summary>
        //// private MediaStreamingContractClient mediaStreamingProxy = new MediaStreamingContractClient("NetTcpBinding_MediaStreamingContract");

        /// <summary>
        /// The BasicHttp media streaming proxy.
        /// </summary>
        private MediaStreamingContractClient mediaStreamingProxy = new MediaStreamingContractClient("BasicHttpBinding_MediaStreamingContract");

        /// <summary>
        /// The TCP data streaming proxy.
        /// </summary>
        //// private serviceProxy.DataStreamingContractClient dataStreamingProxy = new DataStreamingContractClient("NetTcpBinding_DataStreamingContract");

        /// <summary>
        /// The BasicHttp data streaming proxy.
        /// </summary>
        private serviceProxy.DataStreamingContractClient dataStreamingProxy = new DataStreamingContractClient("BasicHttpBinding_DataStreamingContract");

        /// <summary>
        /// The Play button was clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The eventArgs.</param>
        private void BtnPlayClick(object sender, EventArgs eventArgs)
        {
            //var mediaFile = "MovieStar.wav"; // file is 21367354 bytes long
            //var mediaFile = "TheJimiHendrixTheory.wav";
            var mediaFile = "Amsterdam.wav";

            Stream serverStream = this.mediaStreamingProxy.GetMediaAsStream(mediaFile);

            var sw = new Stopwatch();
            var size = string.Empty;
            sw.Start();

            using (var sr = new StreamReader(serverStream))
            {
                var contents = sr.ReadToEnd();
                size = contents.Length.ToString(CultureInfo.InvariantCulture);
            }
            
            this.lblBytes.Text = size;
            sw.Stop();

            this.lblMilliseconds.Text = sw.ElapsedMilliseconds.ToString(CultureInfo.InvariantCulture);
            
            //this.mediaPlayer.Stream = serverStream;

            //this.mediaPlayer.Play();
        }
    }
}
