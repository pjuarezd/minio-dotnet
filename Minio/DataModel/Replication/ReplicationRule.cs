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
 * ReplicationRule class used within ReplicationConfiguration to encapsulate a rule used within replication configuration.
 * Please refer:
 * https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetBucketReplication.html
 * https://docs.aws.amazon.com/AmazonS3/latest/API/API_PutBucketReplication.html
 * https://docs.aws.amazon.com/AmazonS3/latest/API/API_DeleteBucketReplication.html
 */

namespace Minio.DataModel.Replication;

[Serializable]
[XmlRoot(ElementName = "Rule")]
public class ReplicationRule
{
    public const string StatusEnabled = "Enabled";
    public const string StatusDisabled = "Disabled";

    public ReplicationRule()
    {
    }

    public ReplicationRule(DeleteMarkerReplication deleteMarkerReplication, ReplicationDestination destination,
        ExistingObjectReplication existingObjectReplication, RuleFilter filter, DeleteReplication deleteReplication,
        uint priority, string id, string prefix, SourceSelectionCriteria sourceSelectionCriteria, string status)
    {
        if (string.IsNullOrEmpty(status) || string.IsNullOrWhiteSpace(status))
            throw new ArgumentNullException(nameof(Status) + " cannot be null or empty.");
        if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            throw new ArgumentNullException(nameof(ID) + " cannot be null or empty.");
        DeleteMarkerReplication = deleteMarkerReplication;
        Destination = destination ?? throw new ArgumentNullException(nameof(Destination) + " cannot be null or empty.");
        ExistingObjectReplication = existingObjectReplication;
        Filter = filter;
        Priority = priority;
        DeleteReplication = deleteReplication ??
                            throw new ArgumentNullException(nameof(DeleteReplication) + " cannot be null or empty.");
        ID = id;
        Prefix = prefix;
        SourceSelectionCriteria = sourceSelectionCriteria;
        Status = status;
    }

    [XmlElement(ElementName = "DeleteMarkerReplication", IsNullable = true)]
    public DeleteMarkerReplication DeleteMarkerReplication { get; set; }

    [XmlElement("Destination")] public ReplicationDestination Destination { get; set; }

    [XmlElement(ElementName = "ExistingObjectReplication", IsNullable = true)]
    public ExistingObjectReplication ExistingObjectReplication { get; set; }

    [XmlElement(ElementName = "Filter", IsNullable = true)]
    public RuleFilter Filter { get; set; }

    [XmlElement("Priority")] public uint Priority { get; set; }

    [XmlElement("ID")] public string ID { get; set; }

    [XmlElement(ElementName = "Prefix", IsNullable = true)]
    public string Prefix { get; set; }

    [XmlElement("DeleteReplication")] public DeleteReplication DeleteReplication { get; set; }

    [XmlElement(ElementName = "SourceSelectionCriteria", IsNullable = true)]
    public SourceSelectionCriteria SourceSelectionCriteria { get; set; }

    [XmlElement("Status")] public string Status { get; set; }
}