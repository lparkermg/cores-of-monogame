using System;
using System.Collections.Generic;
using System.Text;

namespace Wishes.Core.Entities
{
    public class MenuRenderData
    {
        public Texture2D Image;
        public string Text;
        public bool Selected;
        public Vector2 Position;
        public float Layer;

        public MenuRenderData(Texture2D image, string text, bool selected, Vector2 position, float layer)
        {
            Image = image;
            Text = text;
            Selected = selected;
            Position = position;
            Layer = layer;
        }

        public bool IsValid()
        {
            if (Image != null && Selected)
                return false;

            if (Image == null && String.IsNullOrWhiteSpace(Text))
                return false;

            if (Image != null && !String.IsNullOrWhiteSpace(Text))
                return false;

            if (Layer < 0.0f || Layer > 1.0f)
                return false;

            return true;
        }
    }
}
