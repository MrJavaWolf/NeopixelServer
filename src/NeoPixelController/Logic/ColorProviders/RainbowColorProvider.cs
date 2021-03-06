﻿using NeoPixelController.Interface;
using NeoPixelController.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace NeoPixelController.Logic.ColorProviders
{
    public class RainbowColorProvider : IColorProvider
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; } = nameof(RainbowColorProvider);

        public float Speed { get; set; }
        private float offset = 0;

        public RainbowColorProvider(float speed)
        {
            this.Speed = speed;
        }

        public void Reset()
        {
            offset = 0;
        }

        public Color GetColor(EffectTime time)
        {

            //https://stackoverflow.com/questions/2288498/how-do-i-get-a-rainbow-color-gradient-in-c
            float div = (Math.Abs(offset % 1) * 6);
            int ascending = (int)((div % 1) * 255);
            int descending = 255 - ascending;
            switch ((int)div)
            {
                case 0:
                    return Color.FromArgb(255, 255, ascending, 0);
                case 1:
                    return Color.FromArgb(255, descending, 255, 0);
                case 2:
                    return Color.FromArgb(255, 0, 255, ascending);
                case 3:
                    return Color.FromArgb(255, 0, descending, 255);
                case 4:
                    return Color.FromArgb(255, ascending, 0, 255);
                default: // case 5:
                    return Color.FromArgb(255, 255, 0, descending);
            }
        }

        public void Update(EffectTime time)
        {
            offset += Speed * time.DeltaTime / 1000.0f;
        }
    }
}
