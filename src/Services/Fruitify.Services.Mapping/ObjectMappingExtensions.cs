﻿namespace Fruitify.Services.Mapping
{
    using System;

    public static class ObjectMappingExtensions
    {
        public static T To<T>(this object origin)
        
        {
            if (origin == null)
            {
                throw new ArgumentNullException(nameof(origin));
            }

            return AutoMapperConfig.MapperInstance.Map<T>(origin);
        }
    }
}
