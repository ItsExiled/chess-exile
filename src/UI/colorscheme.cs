using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using System.Drawing;

public class ColorScheme
{
    public string Name { get; set; }
    public Color LightSquare { get; set; }
    public Color DarkSquare { get; set; }
    public Color UIBackground { get; set; }
    public Color UIText { get; set; }
}

public class ColorSchemeManager
{
    private List<ColorScheme> presets;
    public ColorScheme CurrentScheme { get; private set; }
    
    public ColorSchemeManager()
    {
        presets = new List<ColorScheme>
        {
            new ColorScheme { Name = "Classic", LightSquare = Color.Beige, DarkSquare = Color.Brown, UIBackground = Color.Gray, UIText = Color.White },
            new ColorScheme { Name = "Dark Mode", LightSquare = Color.Gray, DarkSquare = Color.Black, UIBackground = Color.Black, UIText = Color.White },
            new ColorScheme { Name = "Blue Ocean", LightSquare = Color.LightBlue, DarkSquare = Color.DarkBlue, UIBackground = Color.Navy, UIText = Color.White }
        };
        CurrentScheme = presets[0]; // Default scheme
    }

    public List<ColorScheme> GetPresets() => presets;

    public void SetScheme(ColorScheme scheme)
    {
        CurrentScheme = scheme;
        ApplyScheme();
    }

    public void ImportScheme(string filePath)
    {
        try
        {
            string json = File.ReadAllText(filePath);
            ColorScheme customScheme = JsonSerializer.Deserialize<ColorScheme>(json);
            if (customScheme != null)
            {
                presets.Add(customScheme);
                SetScheme(customScheme);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error importing color scheme: " + ex.Message);
        }
    }

    private void ApplyScheme()
    {
        // This method should update the UI elements with the chosen colors
        // Example:
        Application.OpenForms[0].BackColor = CurrentScheme.UIBackground;
        foreach (Control ctrl in Application.OpenForms[0].Controls)
        {
            ctrl.ForeColor = CurrentScheme.UIText;
        }
    }
}
