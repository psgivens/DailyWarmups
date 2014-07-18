using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WriteToFileWindowsService
{
    public partial class FileWriteWindowsService : ServiceBase
    {
        private ServiceHost host;
        public FileWriteWindowsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8080/hello");
            // Create the ServiceHost.
            host = new ServiceHost(typeof(FileWriterService), baseAddress);

            // Enable metadata publishing.
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            host.Description.Behaviors.Add(smb);

            // Open the ServiceHost to start listening for messages. Since
            // no endpoints are explicitly configured, the runtime will create
            // one endpoint per base address for each service contract implemented
            // by the service.
            host.Open();            
        }

        protected override void OnStop()
        {
            host.Close();
            host = null;
        }

        internal void Start()
        {
            OnStart(new string[0]);
        }
    }
}
