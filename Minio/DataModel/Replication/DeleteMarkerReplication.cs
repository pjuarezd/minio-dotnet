/*
 * MinIO .NET Library for Amazon S3 Compatible Cloud Storage, (C) 2021 MinIO, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Xml.Serialization;

/*
 * DeleteMarkerReplication class used within ReplicationRule to specify whether the service should replicate delete markers.
 * Please refer:
 * https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetBucketReplication.html
 * https://docs.aws.amazon.com/AmazonS3/latest/API/API_PutBucketReplication.html
 * https://docs.aws.amazon.com/AmazonS3/latest/API/API_DeleteBucketReplication.html
 */

namespace Minio.DataModel.Replication;

[Serializable]
[XmlRoot(ElementName = "DeleteMarkerReplication")]
public class DeleteMarkerReplication
{
    public const string StatusEnabled = "Enabled";
    public const string StatusDisabled = "Disabled";

    public DeleteMarkerReplication(string status)
    {
        if (string.IsNullOrEmpty(status) || string.IsNullOrWhiteSpace(status))
            throw new ArgumentNullException(nameof(Status) + " cannot be null or empty.");
        Status = status;
    }

    public DeleteMarkerReplication()
    {
    }

    [XmlElement("Status")] public string Status { get; set; }
}