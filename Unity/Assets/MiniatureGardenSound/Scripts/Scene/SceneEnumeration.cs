using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MiniatureGardenSound.Data;
using Zenject;

namespace MiniatureGardenSound.Scene
{
    public class SceneEnumeration : IComparable, IInitializable
    {

        private Scenes scenes;
        private SceneList list;
    
        public int Id { get; private set; }
        public string Name { get; private set; }
        public SceneConstitution Value { get; private set; }
    
        [Inject]
        private void Injection(SceneList list)
        {
            this.list = list;
        }
    
        public SceneEnumeration(Scenes scenes)
        {
            this.scenes = scenes;
        }

        public override string ToString() => Name;
    
        public void Initialize()
        {
            Id = (int) scenes;
            Name = scenes.ToString();
            Value = list.Get(scenes);
        }

        public static IEnumerable<T> GetAll<T>() where T : SceneEnumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public |
                                             BindingFlags.Static |
                                             BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SceneEnumeration otherValue))
                return false;

            var typeMatches = GetType() == obj.GetType();
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public int CompareTo(object other) => Id.CompareTo(((SceneEnumeration)other).Id);

    }
}