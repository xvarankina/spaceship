﻿using Settings.Enums;
using UnityEngine;

namespace Settings.Scriptables
{
    [CreateAssetMenu(menuName = "SpaceshipSettings/New Module Settings", fileName = "NewModuleSettings")]
    public class ModuleSettings : ComponentSettings
    {
        [SerializeField] private string _statName;
        [SerializeField] private ValueType _valueType;
        [SerializeField] private int _value;

        public string StatName => _statName;
        public ValueType ValueType => _valueType;
        public int Value => _value;
    }
}