using System;
using System.Collections.Generic;
using System.Text;

namespace Wishes.Core.Entities
{
    public class RenderData
    {
        //TODO: Add rotation to this data.
        public Texture2D Image;
        public string Text;
        public Vector2 Position;
        public float Layer;

        public RenderData(Texture2D image, string text, Vector2 position, float layer)
        {
            Image = image;
            Text = text;
            Position = position;
            Layer = layer;
        }

        public bool IsValid()
        {
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
