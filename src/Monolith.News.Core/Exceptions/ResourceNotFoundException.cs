﻿using System.Runtime.Serialization;

namespace Monolith.News.Core.Exceptions
{
    [Serializable]
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string resourceName) : base($"resource: {resourceName} not found")
        {
        }

        protected ResourceNotFoundException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
