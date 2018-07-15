﻿using System;

namespace ServiceMonitor.Core.DataLayer.DataContracts
{
    public class ServiceWatcherItemDto
    {
        public ServiceWatcherItemDto()
        {
        }

        public Int32? ServiceID { get; set; }

        public Int32? ServiceEnvironmentID { get; set; }

        public String Environment { get; set; }

        public String ServiceName { get; set; }

        public Int32? Interval { get; set; }

        public String Url { get; set; }

        public String Address { get; set; }

        public String ConnectionString { get; set; }

        public String TypeName { get; set; }
    }
}
