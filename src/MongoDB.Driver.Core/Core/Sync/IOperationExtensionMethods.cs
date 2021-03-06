﻿/* Copyright 2013-2014 MongoDB Inc.
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
using System.Threading;
using MongoDB.Driver.Core.Bindings;
using MongoDB.Driver.Core.Clusters;
using MongoDB.Driver.Core.Operations;

namespace MongoDB.Driver.Core.SyncExtensionMethods
{
    public static class IOperationExtensionMethods
    {
        // static methods
        public static TResult Execute<TResult>(this IReadOperation<TResult> operation, IConnectionSourceHandle connectionSource, ReadPreference readPreference, TimeSpan timeout = default(TimeSpan), CancellationToken cancellationToken = default(CancellationToken))
        {
            return operation.ExecuteAsync(connectionSource, readPreference, timeout, cancellationToken).GetAwaiter().GetResult();
        }

        public static TResult Execute<TResult>(this IReadOperation<TResult> operation, IReadBinding binding, TimeSpan timeout = default(TimeSpan), CancellationToken cancellationToken = default(CancellationToken))
        {
            return operation.ExecuteAsync(binding, timeout, cancellationToken).GetAwaiter().GetResult();
        }

        public static TResult Execute<TResult>(this IWriteOperation<TResult> operation, IConnectionSourceHandle connectionSource, TimeSpan timeout = default(TimeSpan), CancellationToken cancellationToken = default(CancellationToken))
        {
            return operation.ExecuteAsync(connectionSource, timeout, cancellationToken).GetAwaiter().GetResult();
        }

        public static TResult Execute<TResult>(this IWriteOperation<TResult> operation, IWriteBinding binding, TimeSpan timeout = default(TimeSpan), CancellationToken cancellationToken = default(CancellationToken))
        {
            return operation.ExecuteAsync(binding, timeout, cancellationToken).GetAwaiter().GetResult();
        }
    }
}
