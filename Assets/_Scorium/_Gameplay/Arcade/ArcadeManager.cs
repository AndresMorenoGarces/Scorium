using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AndresMoreno;

namespace Scorium.Gameplay { 
    public class ArcadeManager : Gameplay {
        public GameObject ball;
        public void Ingravity(bool _isActive) { 
            Gravity2DController.InGravity(_isActive, new[] { ball });
        }
    }
}
