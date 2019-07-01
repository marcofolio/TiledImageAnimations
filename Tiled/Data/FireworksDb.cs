using System;
using System.Collections.Generic;
using Tiled.Models;

namespace Tiled.Data
{
    public static class FireworksDb
    {
        private static List<Firework> _fireworks;
        private static int _index = - 1;

        public static Firework Next()
        {
            if(_fireworks == null)
            {
                _fireworks = new List<Firework>();
                Populate(_fireworks);
            }

            _index++;
            if(_index == _fireworks.Count)
            {
                _index = 0;
            }

            return _fireworks[_index];
        }

        // https://www.popoptiq.com/types-of-fireworks/
        private static void Populate(List<Firework> list)
        {
            list.Add(new Firework()
            {
                Name = "Firecrackers",
                Description = "Arguably the most popular kinds of fireworks available commercially nowadays, firecrackers have become incredibly popular for a variety of reasons. If you visit any local store that sells party equipment and other miscellaneous stuff, you are likely to find firecrackers in their inventory as well.",
                Image = "https://raw.githubusercontent.com/marcofolio/TiledImageAnimations/master/_imgs/firecrackers.jpg"
            });
            list.Add(new Firework()
            {
                Name = "Smoke Bombs",
                Description = "For a kid with a wild imagination, no other kind of firework is better than a smoke bomb. By their very definition, smoke bombs are not designed to explode. However, there are numerous varieties available nowadays that tend to explode and then release smoke.",
                Image = "https://raw.githubusercontent.com/marcofolio/TiledImageAnimations/master/_imgs/smoke-bomb.jpg"
            });
            list.Add(new Firework()
            {
                Name = "Novelty Fireworks",
                Description = "Novelty fireworks are commonly used in many events, and even children love playing with them. Novelty fireworks are available in a variety of different shapes and sizes, ranging from small rockets to tiny eggs. When fired, these egg fireworks blast up into the sky and can form a variety of shapes.",
                Image = "https://raw.githubusercontent.com/marcofolio/TiledImageAnimations/master/_imgs/novelty.jpg"
            });
            list.Add(new Firework()
            {
                Name = "Fountains",
                Description = "If you are looking for fireworks that are relatively safe to use and don’t cost a lot of money, then the fountain is a good choice. Most of the fountains that are available through local stores are basically cone-shaped devices. They sit on the ground and when fired they start releasing a lot of sparks all around the device.",
                Image = "https://raw.githubusercontent.com/marcofolio/TiledImageAnimations/master/_imgs/fountains.jpg"
            });
            list.Add(new Firework()
            {
                Name = "Ground Spinners",
                Description = "Another popular type of firework that is mostly designed for use on the ground, ground spinners are ideal for children who want to shoot off some fireworks on the ground. The name used for these fireworks sums them up pretty well; they just spin on the ground when lit up, releasing sparks in all directions.",
                Image = "https://raw.githubusercontent.com/marcofolio/TiledImageAnimations/master/_imgs/ground-spinner.jpg"
            });
            list.Add(new Firework()
            {
                Name = "Sparklers",
                Description = "Sparklers have been around for quite some time, and anybody who has used fireworks as a kid will have used these at some point in their lives as well. Sparklers were mainly created with kids in mind and are generally safe as long as you know how to handle them properly.",
                Image = "https://raw.githubusercontent.com/marcofolio/TiledImageAnimations/master/_imgs/sparklers.jpg"
            });
        }
    }
}
