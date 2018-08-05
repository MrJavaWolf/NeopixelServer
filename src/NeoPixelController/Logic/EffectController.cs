﻿using MathNet.Numerics.Interpolation;
using NeoPixelController.Interface;
using NeoPixelController.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using WebSocketSharp;

namespace NeoPixelController.Logic
{
    public class EffectController
    {

        public AnimationType AnimationType { get; set; } = AnimationType.HermitCurve;

        private List<INeoPixelEffect> effects = new List<INeoPixelEffect>();
        private Stopwatch stopwatch = new Stopwatch();
        private EffectTime time = new EffectTime();

        public void RunEffect()
        {
            UpdateTime();
            foreach (var effect in effects)
            {
                effect.Update(time);
            }
        }

        public void AddEffect(INeoPixelEffect effect)
        {
            effects.Add(effect);
        }

        public void RemoveEffect(INeoPixelEffect effect)
        {
            effects.Remove(effect);
        }

        public IReadOnlyList<INeoPixelEffect> GetEffects()
        {
            return effects;
        }
 
        private void UpdateTime()
        {
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();
                time.DeltaTime = 16;
                time.Time = 0;
            }
            else
            {
                time.DeltaTime = stopwatch.ElapsedMilliseconds - time.Time;
                time.Time = stopwatch.ElapsedMilliseconds;
            }
        }
    }
}
