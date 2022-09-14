﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Domain.Utilities
{
    /// <summary>
    /// Provides serialization and deserialization functionality to and from string values.
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Returns a object of the desired type, deserialized from the input string.
        /// </summary>
        T Deserialize<T>(string value, Type type);

        /// <summary>
        /// Returns the serialized string value for an object of a specific type.
        /// </summary>
        string Serialize<T>(T value);

        /// <summary>
        /// Returns the serialized string value for an object, excluding properties in the exclusions array.
        /// </summary>
        string Serialize(object command, string[] exclusions);
    }
}
