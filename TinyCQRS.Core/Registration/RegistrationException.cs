﻿using System;
using System.Runtime.Serialization;

namespace TinyCQRS.Core.Registration
{
    [Serializable]
    internal class RegistrationException : Exception
    {
        public RegistrationException()
        {
        }

        public RegistrationException(string message) : base(message)
        {
        }

        public RegistrationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RegistrationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}