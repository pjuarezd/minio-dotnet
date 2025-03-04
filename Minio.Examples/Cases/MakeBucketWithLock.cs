/*
 * MinIO .NET Library for Amazon S3 Compatible Cloud Storage, (C) 2020 MinIO, Inc.
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

namespace Minio.Examples.Cases;

public static class MakeBucketWithLock
{
    // Make a bucket
    public static async Task Run(IMinioClient minio,
        string bucketName = "my-bucket-name", string loc = "us-east-1")
    {
        try
        {
            Console.WriteLine("Running example for API: MakeBucketAsync");
            await minio.MakeBucketAsync(
                new MakeBucketArgs()
                    .WithBucket(bucketName)
                    .WithLocation(loc)
                    .WithObjectLock()
            ).ConfigureAwait(false);
            Console.WriteLine($"Created bucket {bucketName} with lock.");
            Console.WriteLine();
        }
        catch (Exception e)
        {
            Console.WriteLine($"[Bucket]  Exception: {e}");
        }
    }
}