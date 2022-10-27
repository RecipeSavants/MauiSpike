﻿namespace MauiPlanets.Models;

public class Planet
{
    public string Name { get; set; }
    public string Subtitle { get; set; }
    public string HeroImage { get; set; }
    public string Description { get; set; }
    public Color AccentColorStart { get; set; }
    public Color AccentColorEnd { get; set; }
    public List<string> Images { get; set; }
    public int Age { get; set; }
    public string Location { get; set; }
    public string Hood { get; set; }
    public string When { get; set; }
    public string Where { get; set; }
    public int Feet { get; set; }
    public int Inches { get; set; }
    public int Weight { get; set; }

    // Background
    public Brush Background
    {
        get
        {
            var gradientStops = new GradientStopCollection();
            gradientStops.Add(new GradientStop(AccentColorStart, 0.0f));
            gradientStops.Add(new GradientStop(AccentColorEnd, 1.0f));

            var bgBrush = new LinearGradientBrush(
                gradientStops,
                new Point(0.0, 0.0),
                new Point(1.0, 1.0));

            return bgBrush;
        }
    }    
}
