﻿/* Copyright 2010-2014 MongoDB Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using MongoDB.Driver.Communication;
using MongoDB.Driver.Core.Clusters;
namespace MongoDB.Driver
{
    /// <summary>
    /// Represents a client to MongoDB.
    /// </summary>
    public class MongoClient
    {
        // private fields
        private readonly ICluster _cluster;
        private readonly MongoClientSettings _settings;

        // constructors
        /// <summary>
        /// Initializes a new instance of the MongoClient class.
        /// </summary>
        public MongoClient()
            : this(new MongoClientSettings())
        {
        }

        /// <summary>
        /// Initializes a new instance of the MongoClient class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public MongoClient(MongoClientSettings settings)
        {
            _settings = settings.FrozenCopy();
            _cluster = ClusterRegistry.Instance.GetOrCreateCluster(_settings);
        }

        /// <summary>
        /// Initializes a new instance of the MongoClient class.
        /// </summary>
        /// <param name="url">The URL.</param>
        public MongoClient(MongoUrl url)
            : this(MongoClientSettings.FromUrl(url))
        {
        }

        /// <summary>
        /// Initializes a new instance of the MongoClient class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public MongoClient(string connectionString)
            : this(ParseConnectionString(connectionString))
        {
        }

        // public properties
        /// <summary>
        /// Gets the cluster.
        /// </summary>
        /// <value>
        /// The cluster.
        /// </value>
        internal ICluster Cluster
        {
            get { return _cluster; }
        }

        /// <summary>
        /// Gets the client settings.
        /// </summary>
        public MongoClientSettings Settings
        {
            get { return _settings; }
        }

        // private static methods
        private static MongoClientSettings ParseConnectionString(string connectionString)
        {
            var url = new MongoUrl(connectionString);
            return MongoClientSettings.FromUrl(url);
        }

        // public methods
        /// <summary>
        /// Gets a MongoServer object using this client's settings.
        /// </summary>
        /// <returns>A MongoServer.</returns>
        public MongoServer GetServer()
        {
            var serverSettings = MongoServerSettings.FromClientSettings(_settings);
#pragma warning disable 618
            return MongoServer.Create(serverSettings);
#pragma warning restore
        }
    }
}
