using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PersecutionGameAssemble.Components
{
    [Serializable]
    public struct Persecution
    {
        public Transform OurTransform;
        public Transform target;
        public float speed;
    }
}
