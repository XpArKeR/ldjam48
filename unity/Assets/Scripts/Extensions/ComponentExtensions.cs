using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace Assets.Scripts.Extensions
{
    public static class ComponentExtensions
    {        
        public static T GetChildComponentByName<T>(this Component component, String name) where T : Component
        {
            if (component != default)
            {
                foreach (T childComponent in component.GetComponentsInChildren<T>(true))
                {
                    if (childComponent.gameObject.name == name)
                    {
                        return childComponent;
                    }
                }
            }

            return default;
        }
    }
}
